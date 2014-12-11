using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

using AutoMapper;

using TDS.Business.Services.Interface;
using TDS.DataAccess.EntityModels;
using TDS.Presentation.Ui.Models;

namespace TDS.Presentation.Ui.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService<ProductEntity> productsService;
        private readonly ICategoryService<CategoryEntity> categoryService;
        private readonly IDeliveryService<DeliveryEntity> deliveryService;
        private readonly IProviderService<ProviderEntity> providerService;

        public ProductsController(
            IProductsService<ProductEntity> productsService,
            ICategoryService<CategoryEntity> categoryService,
            IDeliveryService<DeliveryEntity> deliveryService,
            IProviderService<ProviderEntity> providerService)
        {
            this.productsService = productsService;
            this.categoryService = categoryService;
            this.deliveryService = deliveryService;
            this.providerService = providerService;
        }

        public ActionResult Index()
        {
            List<ProductViewModel> viewsModels = new List<ProductViewModel>();

            foreach (ProductEntity product in productsService.GetAll())
            {
                foreach (DeliveryEntity delivery in deliveryService.GetByProductId(product.ProductEntityId))
                {
                    ProductViewModel viewModel = Mapper.Map<ProductViewModel>(product);
                    
                    viewModel.Cost = delivery.Cost;
                    viewModel.IsExists = delivery.Count > 0;
                    viewModel.Provider = Mapper.Map<ProviderViewModel>(providerService.GetById(delivery.ProviderEntityId));

                    viewsModels.Add(viewModel);
                }
            }
            return View(viewsModels);
        }

        public ActionResult Details(int? id)
        {
            ActionResult result = new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            if (id != null)
            {
                ProductEntity productObject = productsService.GetById(id.Value);
                if (productObject != null)
                {
                    ProductViewModel viewModel = Mapper.Map<ProductViewModel>(productObject);
                    result = View(viewModel);
                }
                else
                {
                    result = HttpNotFound();
                }
            }

            return result;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductEntityId,Name,ProductInfo")] ProductEntity entity)
        {
            if (ModelState.IsValid)
            {
                productsService.Create(entity);
                return RedirectToAction("Index");
            }

            return View(entity);
        }

        public ActionResult Edit(int? id)
        {
            ActionResult result = new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            if (id != null)
            {
                ProductEntity entity = productsService.GetById(id.Value);

                if (entity != null)
                {
                    ProductViewModel viewModel = Mapper.Map<ProductViewModel>(entity);

                    ViewData["Categories"] = Mapper
                        .Map<ICollection<CategoryEntity>, ICollection<CategoryViewModel>>(
                            categoryService.GetAll());

                    result = View(viewModel);
                }
                else
                {
                    result = HttpNotFound();
                }
            }

            return result;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "ProductEntityId,Name,ProductInfo,CategoryId")] 
            ProductViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                ProductEntity entityToUpdate = Mapper.Map<ProductEntity>(viewModel);
                entityToUpdate.Categories = categoryService.GetById(viewModel.CategoryId);
                productsService.Update(entityToUpdate);

                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        public ActionResult Delete(int? id)
        {
            ActionResult result = new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            if (id != null)
            {
                ProductEntity entity = productsService.GetById(id.Value);

                if (entity != null)
                {
                    ProductViewModel viewModel = Mapper.Map<ProductViewModel>(entity);

                    result = View(viewModel);
                }
                else
                {
                    result = HttpNotFound();
                }
            }

            return result;
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            productsService.Delete(id);

            return RedirectToAction("Index");
        }

        public ActionResult Search(string content)
        {
            List<ProductViewModel> viewsModels = new List<ProductViewModel>();

            foreach (ProductEntity product in productsService.Search(content))
            {
                foreach (DeliveryEntity delivery in deliveryService.GetByProductId(product.ProductEntityId))
                {
                    ProductViewModel viewModel = Mapper.Map<ProductViewModel>(product);

                    viewModel.Cost = delivery.Cost;
                    viewModel.IsExists = delivery.Count > 0;
                    viewModel.Provider = Mapper.Map<ProviderViewModel>(providerService.GetById(delivery.ProviderEntityId));

                    viewsModels.Add(viewModel);
                }
            }

            return View("Index", viewsModels);
        }
    }
}
