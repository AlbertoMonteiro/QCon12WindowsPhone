#region

using System.Data;
using System.Linq;
using System.Web.Mvc;
using QCon12.Models;

#endregion

namespace QCon12.Controllers
{
    public class PalestranteController : Controller
    {
        private readonly QCon12Context db = new QCon12Context();

        //
        // GET: /Default1/

        public ActionResult Index()
        {
            return View(db.Palestrantes.ToList());
        }

        //
        // GET: /Default1/Details/5

        public ActionResult Details(int id = 0)
        {
            var palestrante = db.Palestrantes.Find(id);
            if (palestrante == null)
                return HttpNotFound();
            return View(palestrante);
        }

        //
        // GET: /Default1/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Default1/Create

        [HttpPost]
        public ActionResult Create(Palestrante palestrante)
        {
            if (ModelState.IsValid)
            {
                db.Palestrantes.Add(palestrante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(palestrante);
        }

        //
        // GET: /Default1/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var palestrante = db.Palestrantes.Find(id);
            if (palestrante == null)
                return HttpNotFound();
            return View(palestrante);
        }

        //
        // POST: /Default1/Edit/5

        [HttpPost]
        public ActionResult Edit(Palestrante palestrante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(palestrante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(palestrante);
        }

        //
        // GET: /Default1/Delete/5

        public ActionResult Delete(int id = 0)
        {
            var palestrante = db.Palestrantes.Find(id);
            if (palestrante == null)
                return HttpNotFound();
            return View(palestrante);
        }

        //
        // POST: /Default1/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var palestrante = db.Palestrantes.Find(id);
            db.Palestrantes.Remove(palestrante);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}