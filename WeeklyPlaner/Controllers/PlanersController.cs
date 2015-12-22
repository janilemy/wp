using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WeeklyPlaner.DAL;
using WeeklyPlaner.Models;

namespace WeeklyPlaner
{
    public class PlanersController : Controller
    {
        private WeeklyPlanerContext db = new WeeklyPlanerContext();

        // GET: Planers
        public ActionResult Index()
        {
            return View(db.Planer.ToList());
        }

        // GET: Planers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planer planer = db.Planer.Find(id);
            if (planer == null)
            {
                return HttpNotFound();
            }
            return View(planer);
        }

        // GET: Planers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Planers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PlanedOn")] Planer planer)
        {
            if (ModelState.IsValid)
            {
                db.Planer.Add(planer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(planer);
        }

        // GET: Planers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planer planer = db.Planer.Find(id);
            if (planer == null)
            {
                return HttpNotFound();
            }
            return View(planer);
        }

        // POST: Planers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PlanedOn")] Planer planer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(planer);
        }

        // GET: Planers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planer planer = db.Planer.Find(id);
            if (planer == null)
            {
                return HttpNotFound();
            }
            return View(planer);
        }

        // POST: Planers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Planer planer = db.Planer.Find(id);
            db.Planer.Remove(planer);
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
