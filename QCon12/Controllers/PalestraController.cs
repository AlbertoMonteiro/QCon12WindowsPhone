﻿using System.Data;
using System.Linq;
using System.Web.Mvc;
using QCon12.Models;

namespace QCon12.Controllers
{
    public class PalestraController : Controller
    {
        private readonly QCon12Context db = QCon12Context.Instance;

        public ActionResult Index()
        {
            return View(db.Palestras.Include("Palestrante").Include("Track").ToList());
        }

        public ActionResult Details(int id = 0)
        {
            var palestra = db.Palestras.Find(id);
            if (palestra == null)
                return HttpNotFound();
            return View(palestra);
        }

        public ActionResult Create()
        {
            LoadPalestrantesAndTracksToViewBag();
            return View();
        }

        private void LoadPalestrantesAndTracksToViewBag(Palestrante palestrante = null, Track track = null)
        {
            var palestrantes = db.Palestrantes.ToList();
            var find = palestrantes.SingleOrDefault(x => palestrante != null && x.Id == palestrante.Id);
            ViewBag.Palestrantes = new SelectList(palestrantes, "Id", "Nome", find);
            ViewBag.Tracks = new SelectList(db.Tracks, "Id", "Nome", track);
        }

        [HttpPost]
        public ActionResult Create(Palestra palestra)
        {
            if (ModelState.IsValid)
            {
                db.Palestras.Add(palestra);
                return RedirectToAction("Index");
            }
            LoadPalestrantesAndTracksToViewBag();
            return View(palestra);
        }

        public ActionResult Edit(int id = 0)
        {
            var palestra = db.Palestras.Find(id);
            if (palestra == null)
                return HttpNotFound();
            LoadPalestrantesAndTracksToViewBag(palestra.Palestrante, palestra.Track);
            return View(palestra);
        }

        [HttpPost]
        public ActionResult Edit(Palestra palestra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(palestra).State = EntityState.Modified;
                return RedirectToAction("Index");
            }
            LoadPalestrantesAndTracksToViewBag();
            return View(palestra);
        }

        public ActionResult Delete(int id = 0)
        {
            var palestra = db.Palestras.Find(id);
            if (palestra == null)
                return HttpNotFound();
            return View(palestra);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var palestra = db.Palestras.Find(id);
            db.Palestras.Remove(palestra);
            return RedirectToAction("Index");
        }
    }
}