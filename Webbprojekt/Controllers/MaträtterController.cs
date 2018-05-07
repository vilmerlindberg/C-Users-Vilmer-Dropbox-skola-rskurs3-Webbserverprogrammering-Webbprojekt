using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Webbprojekt.Models;

namespace Webbprojekt.Controllers
{
    public class MaträtterController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: Maträtter
        public ActionResult Index()
        {
            var maträtter = db.Maträtter.Include(m => m.kategori);
            return View(maträtter.ToList());
        }

        // GET: Maträtter/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maträtt maträtt = db.Maträtter.Find(id);
            if (maträtt == null)
            {
                return HttpNotFound();
            }
            return View(maträtt);
        }

        // GET: Maträtter/Create
        public ActionResult Create()
        {
            ViewBag.kategoriID = new SelectList(db.Kategorier, "ID", "Name");
            return View();
        }

        // POST: Maträtter/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,Price,kategoriID")] Maträtt maträtt)
        {
            if (ModelState.IsValid)
            {
                db.Maträtter.Add(maträtt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.kategoriID = new SelectList(db.Kategorier, "ID", "Name", maträtt.kategoriID);
            return View(maträtt);
        }

        // GET: Maträtter/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maträtt maträtt = db.Maträtter.Find(id);
            if (maträtt == null)
            {
                return HttpNotFound();
            }
            ViewBag.kategoriID = new SelectList(db.Kategorier, "ID", "Name", maträtt.kategoriID);
            return View(maträtt);
        }

        // POST: Maträtter/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,Price,kategoriID")] Maträtt maträtt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maträtt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.kategoriID = new SelectList(db.Kategorier, "ID", "Name", maträtt.kategoriID);
            return View(maträtt);
        }

        // GET: Maträtter/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maträtt maträtt = db.Maträtter.Find(id);
            if (maträtt == null)
            {
                return HttpNotFound();
            }
            return View(maträtt);
        }

        // POST: Maträtter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Maträtt maträtt = db.Maträtter.Find(id);
            db.Maträtter.Remove(maträtt);
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
