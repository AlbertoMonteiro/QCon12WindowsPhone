using System.Data;
using System.Web.Mvc;
using QCon12.Models;

namespace QCon12.Controllers
{
    public class TrackController : Controller
    {
        private readonly QCon12Context db = QCon12Context.Instance;

        public ActionResult Index()
        {
            return View(db.Tracks);
        }

        public ActionResult Details(int id = 0)
        {
            var track = db.Tracks.Find(id);
            if (track == null)
                return HttpNotFound();
            return View(track);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Track track)
        {
            if (ModelState.IsValid)
            {
                db.Tracks.Add(track);
                return RedirectToAction("Index");
            }

            return View(track);
        }

        public ActionResult Edit(int id = 0)
        {
            var track = db.Tracks.Find(id);
            if (track == null)
                return HttpNotFound();
            return View(track);
        }

        [HttpPost]
        public ActionResult Edit(Track track)
        {
            if (ModelState.IsValid)
            {
                db.Entry(track).State = EntityState.Modified;
                return RedirectToAction("Index");
            }
            return View(track);
        }

        public ActionResult Delete(int id = 0)
        {
            var track = db.Tracks.Find(id);
            if (track == null)
                return HttpNotFound();
            return View(track);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var track = db.Tracks.Find(id);
            db.Tracks.Remove(track);
            return RedirectToAction("Index");
        }
    }
}