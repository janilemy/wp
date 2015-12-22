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
    public class FavouriteItemsController : Controller
    {
        private WeeklyPlanerContext db = new WeeklyPlanerContext();

        // GET: FavouriteItems
        public ActionResult Index()
        {
            var favouriteItem = db.FavouriteItem.Include(f => f.Item);
            return View(favouriteItem.ToList());
        }

        // GET: FavouriteItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FavouriteItem favouriteItem = db.FavouriteItem.Find(id);
            if (favouriteItem == null)
            {
                return HttpNotFound();
            }
            return View(favouriteItem);
        }

        // GET: FavouriteItems/Create
        public ActionResult Create()
        {
            ViewBag.ItemId = new SelectList(db.Item, "ID", "ItemName");
            return View();
        }

        // POST: FavouriteItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserId,ItemId")] FavouriteItem favouriteItem)
        {
            if (ModelState.IsValid)
            {
                db.FavouriteItem.Add(favouriteItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemId = new SelectList(db.Item, "ID", "ItemName", favouriteItem.ItemId);
            return View(favouriteItem);
        }

        // GET: FavouriteItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FavouriteItem favouriteItem = db.FavouriteItem.Find(id);
            if (favouriteItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemId = new SelectList(db.Item, "ID", "ItemName", favouriteItem.ItemId);
            return View(favouriteItem);
        }

        // POST: FavouriteItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserId,ItemId")] FavouriteItem favouriteItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(favouriteItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemId = new SelectList(db.Item, "ID", "ItemName", favouriteItem.ItemId);
            return View(favouriteItem);
        }

        // GET: FavouriteItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FavouriteItem favouriteItem = db.FavouriteItem.Find(id);
            if (favouriteItem == null)
            {
                return HttpNotFound();
            }
            return View(favouriteItem);
        }

        // POST: FavouriteItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FavouriteItem favouriteItem = db.FavouriteItem.Find(id);
            db.FavouriteItem.Remove(favouriteItem);
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
