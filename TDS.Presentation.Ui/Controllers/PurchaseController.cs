using System;
using System.Linq;
using System.Web.Mvc;

using Microsoft.AspNet.Identity;

using TDS.Business.Services.Interface;
using TDS.DataAccess.EntityModels;
using TDS.DataAccess.Implementation;

namespace TDS.Presentation.Ui.Controllers
{
    [Authorize]
    public class PurchaseController : Controller
    {
        private readonly ICartService cartService;
        private readonly IPurchaseService purchaseService;
        private readonly IPaymentSystem paymentSystem;

        private AppContext db = new AppContext();

        public PurchaseController(
            ICartService cartService,
            IPurchaseService purchaseService,
            IPaymentSystem paymentSystem)
        {
            this.cartService = cartService;
            this.purchaseService = purchaseService;
            this.paymentSystem = paymentSystem;
        }

        public ActionResult Index()
        {
            string identity = User.Identity.GetUserId();
            
            return View(purchaseService.GetByAllIdentity(identity));
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
