#region

using System.Data;
using System.Linq;
using System.Web.Mvc;
using QCon12.Models;

#endregion

namespace QCon12.Controllers
{
    public class TrackController : Controller
    {
        private readonly QCon12Context db = new QCon12Context();

        //
        // GET: /Track/

        public ActionResult Index()
        {
            return View(db.Tracks.ToList());
        }

        //
        // GET: /Track/Details/5

        public ActionResult Details(int id = 0)
        {
            var track = db.Tracks.Find(id);
            if (track == null)
                return HttpNotFound();
            return View(track);
        }

        //
        // GET: /Track/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Track/Create

        [HttpPost]
        public ActionResult Create(Track track)
        {
            if (ModelState.IsValid)
            {
                db.Tracks.Add(track);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(track);
        }

        //
        // GET: /Track/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var track = db.Tracks.Find(id);
            if (track == null)
                return HttpNotFound();
            return View(track);
        }

        //
        // POST: /Track/Edit/5

        [HttpPost]
        public ActionResult Edit(Track track)
        {
            if (ModelState.IsValid)
            {
                db.Entry(track).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(track);
        }

        //
        // GET: /Track/Delete/5

        public ActionResult Delete(int id = 0)
        {
            var track = db.Tracks.Find(id);
            if (track == null)
                return HttpNotFound();
            return View(track);
        }

        //
        // POST: /Track/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var track = db.Tracks.Find(id);
            db.Tracks.Remove(track);
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