using System;
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

        public ProductsController(
            IProductsService<ProductEntity> productsService,
            ICategoryService<CategoryEntity> categoryService)
        {
            if (productsService == null)
            {
                throw new ArgumentNullException("productsService");
            }
            if (categoryService == null)
            {
                throw new ArgumentNullException("categoryService");
            }
            this.productsService = productsService;
            this.categoryService = categoryService;
        }

        public ActionResult Index()
        {
            IEnumerable<ProductViewModel> products = 
                Mapper.Map<ICollection<ProductEntity>, ICollection<ProductViewModel>>(
                    productsService.GetAll());

            return View(products);
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
        public ActionResult Create([Bind(Include="ProductEntityId,Name,ProductInfo")] ProductEntity entity)
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
                    viewModel.Categories = Mapper.Map<ICollection<CategoryEntity>, ICollection<CategoryViewModel>>(categoryService.GetAll());
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
        public ActionResult Edit([Bind(Include="ProductEntityId,Name,ProductInfo")] ProductViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                ProductEntity entityToUpdate = Mapper.Map<ProductEntity>(viewModel);

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
    }
}
