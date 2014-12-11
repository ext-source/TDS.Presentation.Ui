using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

using TDS.DataAccess.EntityModels;
using TDS.DataAccess.Implementation;

namespace TDS.Presentation.Ui.Controllers
{
    public class ProviderController : Controller
    {
        private AppContext db = new AppContext();

        public ActionResult Index()
        {
            return View(db.Providers.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProviderEntity providerentity = db.Providers.Find(id);
            if (providerentity == null)
            {
                return HttpNotFound();
            }
            return View(providerentity);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ProviderEntityId,Name,Address,RegisterDate,IndividualNumber")] ProviderEntity providerentity)
        {
            if (ModelState.IsValid)
            {
                db.Providers.Add(providerentity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(providerentity);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProviderEntity providerentity = db.Providers.Find(id);
            if (providerentity == null)
            {
                return HttpNotFound();
            }
            return View(providerentity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ProviderEntityId,Name,Address,RegisterDate,IndividualNumber")] ProviderEntity providerentity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(providerentity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(providerentity);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProviderEntity providerentity = db.Providers.Find(id);
            if (providerentity == null)
            {
                return HttpNotFound();
            }
            return View(providerentity);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProviderEntity providerentity = db.Providers.Find(id);
            db.Providers.Remove(providerentity);
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
