using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

using AutoMapper;

using TDS.DataAccess.EntityModels;
using TDS.DataAccess.Implementation;
using TDS.Presentation.Ui.Models;

namespace TDS.Presentation.Ui.Controllers
{
    public class DeliveryController : Controller
    {
        private AppContext db = new AppContext();

        public ActionResult Index()
        {
            ICollection<DeliveryViewModel> viewModels = new List<DeliveryViewModel>();

            db.Products.Load();
            db.Providers.Load();
            
            foreach (DeliveryEntity delivery in db.Deliveries.ToList())
            {
                DeliveryViewModel viewModel = Mapper.Map<DeliveryViewModel>(delivery);
                viewModel.CurrentProvider = Mapper.Map<ProviderViewModel>(db.Providers.Find(delivery.ProviderEntityId));
                viewModel.CurrentProduct = Mapper.Map<ProductViewModel>(db.Products.Find(delivery.ProductEntityId));

                viewModels.Add(viewModel);
            }
            
            return View(viewModels);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryEntity deliveryentity = db.Deliveries.Find(id);
            if (deliveryentity == null)
            {
                return HttpNotFound();
            }
            return View(deliveryentity);
        }

        public ActionResult Create()
        {
            DeliveryViewModel viewModel = new DeliveryViewModel
            {
                Products =  Mapper.Map<ICollection<ProductEntity>, ICollection<ProductViewModel>>(db.Products.ToList()),
                Providers = Mapper.Map<ICollection<ProviderEntity>, ICollection<ProviderViewModel>>(db.Providers.ToList())
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include="DeliveryEntityId,ProductEntityId,ProviderEntityId,Count,Cost")] 
            DeliveryEntity deliveryentity)
        {
            if (ModelState.IsValid)
            {
                deliveryentity.UpdateDate = DateTime.Now;
                db.Deliveries.Add(deliveryentity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Mapper.Map<DeliveryViewModel>(deliveryentity));
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryEntity deliveryentity = db.Deliveries.Find(id);
            
            DeliveryViewModel viewModel = Mapper.Map<DeliveryViewModel>(deliveryentity);
            
            viewModel.Products = Mapper.Map<ICollection<ProductEntity>, ICollection<ProductViewModel>>(
                db.Products.ToList());

            viewModel.Providers = Mapper.Map<ICollection<ProviderEntity>, ICollection<ProviderViewModel>>(
                db.Providers.ToList());
            
            if (deliveryentity == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include="DeliveryEntityId,ProductEntityId,ProviderEntityId,Count,Cost")] 
            DeliveryEntity deliveryentity)
        {
            if (ModelState.IsValid)
            {
                deliveryentity.UpdateDate = DateTime.Now;
                db.Entry(deliveryentity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Mapper.Map<DeliveryViewModel>(deliveryentity));
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryEntity deliveryentity = db.Deliveries.Find(id);
            if (deliveryentity == null)
            {
                return HttpNotFound();
            }
            return View(deliveryentity);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeliveryEntity deliveryentity = db.Deliveries.Find(id);
            db.Deliveries.Remove(deliveryentity);
            db.SaveChanges();
            return RedirectToAction("Index");
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
