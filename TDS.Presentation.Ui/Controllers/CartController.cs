using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

using AutoMapper;

using Microsoft.AspNet.Identity;

using TDS.Business.Services.Interface;
using TDS.DataAccess.EntityModels;
using TDS.DataAccess.Implementation;
using TDS.Presentation.Ui.Models;

namespace TDS.Presentation.Ui.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private AppContext db = new AppContext();
        private readonly ICartService cartService;
        private readonly IPaymentService paymentService;
        private readonly IPurchaseService purchaseService;
        private readonly IPaymentSystem paymentSystem;
        private readonly IProductsService<ProductEntity> productService;

        public CartController(
            ICartService cartService,
            IPaymentService paymentService,
            IPurchaseService purchaseService,
            IPaymentSystem paymentSystem,
            IProductsService<ProductEntity> productService)
        {
            this.cartService = cartService;
            this.paymentService = paymentService;
            this.purchaseService = purchaseService;
            this.paymentSystem = paymentSystem;
            this.productService = productService;
        }

        public ActionResult Index()
        {
            CartEntity cart = cartService.GetOrCreate(User.Identity.GetUserId());
            
            List<CartViewModel> viewModels = new List<CartViewModel>();
            
            foreach (IGrouping<int, DeliveryEntity> deliveryGroup in cart.Deliveries.GroupBy(e => e.ProductEntityId))
            {
                ProductEntity product = productService.GetById(deliveryGroup.Key);

                CartViewModel cartViewModel = new CartViewModel
                {
                    CartEntityId = cart.CartEntityId,
                    ProductsName = product.Name,
                    Cost = deliveryGroup.Select(e => e.Cost).Sum(),
                    Total = deliveryGroup.Count(),
                };

                viewModels.Add(cartViewModel);
            }
            return View(viewModels);
        }

        public ActionResult Apply()
        {
            string identity = User.Identity.GetUserId();
            CartEntity cart = cartService.GetOrCreate(identity);

            purchaseService.Create(new PurchaseEntity
            {
                UserIdentity = identity,
                CreationDate = DateTime.Now,
                Deliveries = cart.Deliveries,
                Total = cart.Deliveries.Select(e => e.Cost).Sum()
            });

            PurchaseEntity purchase = purchaseService.GetByIdentity(identity);

            paymentSystem.MakeTransaction(
                paymentService.GetPaymentNumber(identity), 
                purchase.Total);

            cartService.ClearCart(identity);

            return RedirectToAction("Index", "Products");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartEntity cartentity = db.Carts.Find(id);
            if (cartentity == null)
            {
                return HttpNotFound();
            }
            return View(cartentity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CartEntityId,Total,Count,UpdateDate")] CartEntity cartentity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cartentity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cartentity);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
