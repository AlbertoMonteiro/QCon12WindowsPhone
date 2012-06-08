#region

using System.Data;
using System.Linq;
using System.Web.Mvc;
using QCon12.Models;

#endregion

namespace QCon12.Controllers
{
    public class PalestraController : Controller
    {
        private readonly QCon12Context db = new QCon12Context();

        //
        // GET: /Palestra/

        public ActionResult Index()
        {
            return View(db.Palestras.ToList());
        }

        //
        // GET: /Palestra/Details/5

        public ActionResult Details(int id = 0)
        {
            var palestra = db.Palestras.Find(id);
            if (palestra == null)
                return HttpNotFound();
            return View(palestra);
        }

        //
        // GET: /Palestra/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Palestra/Create

        [HttpPost]
        public ActionResult Create(Palestra palestra)
        {
            if (ModelState.IsValid)
            {
                db.Palestras.Add(palestra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(palestra);
        }

        //
        // GET: /Palestra/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var palestra = db.Palestras.Find(id);
            if (palestra == null)
                return HttpNotFound();
            return View(palestra);
        }

        //
        // POST: /Palestra/Edit/5

        [HttpPost]
        public ActionResult Edit(Palestra palestra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(palestra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(palestra);
        }

        //
        // GET: /Palestra/Delete/5

        public ActionResult Delete(int id = 0)
        {
            var palestra = db.Palestras.Find(id);
            if (palestra == null)
                return HttpNotFound();
            return View(palestra);
        }

        //
        // POST: /Palestra/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var palestra = db.Palestras.Find(id);
            db.Palestras.Remove(palestra);
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