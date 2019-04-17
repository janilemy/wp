using PagedList;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WeeklyPlaner.DAL;
using WeeklyPlaner.DAL.Repositories;
using WeeklyPlaner.Models;
using WeeklyPlaner.ViewModels;

namespace WeeklyPlaner.Controllers
{
    public class ItemsController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private WeeklyPlanerContext db = new WeeklyPlanerContext();
        public const int pageSize = 25;

        // GET: Items
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            // must be included in the paging links in order to keep the sort order while paging
            ViewBag.CurrentSort = sortOrder;
            ViewBag.CategorySortParm = sortOrder == "Category" ? "category_desc" : "Category";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            var item = db.Item.Include(i => i.ItemCategory);

            // in order to maintain the filter settings during paging, we need to include the value and restored to the text box when page is redisplayed
            if(searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            if(!String.IsNullOrEmpty(searchString))
            {
                // filter by search string
                item = item.Where(i => i.Name.Contains(searchString));
            }

            // sort items by sort order
            switch(sortOrder)
            {
                case "category_desc":
                    item = item.OrderByDescending(i => i.ItemCategoryId);
                    break;
                case "Category":
                    item = item.OrderBy(i => i.ItemCategoryId);
                    break;
                case "name_desc":
                    item = item.OrderByDescending(i => i.Name);
                    break;
                default:
                    item = item.OrderBy(i => i.Name);
                    break;
            }

            int pageNumber = (page ?? 1);

            // ToPagedList extension method that converts list to single page list wich is passed to the view
            return View(item.ToPagedList(pageNumber, pageSize));
        }

        // GET: Items/Details/5
        // Changed with attribute routing to Item/5
        [Route("Item/{id:int}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Item.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            ViewBag.ItemCategoryId = new SelectList(db.ItemCategory, "ID", "Category");
            return View();
        }

        // POST: Items/Create
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ItemViewModel itemViewModel)
        {
                if (ModelState.IsValid)
                {
                    //unitOfWork.ItemRepository.InsertItemWithAdditionalInfo(itemViewModel);
                    return RedirectToAction("Index");
                }

                ViewBag.ItemCategoryId = new SelectList(db.ItemCategory, "ID", "Category", itemViewModel.ItemCategoryId);
                return View(itemViewModel);
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var item = db.Item.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            ViewBag.ItemCategoryId = new SelectList(db.ItemCategory, "ID", "Category", item.ItemCategoryId);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ItemCategoryId,Name,Protein,CarbonHidrates,Fats,Fibers,Calories")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemCategoryId = new SelectList(db.ItemCategory, "ID", "Category", item.ItemCategoryId);
            return View(item);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError=false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if(saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persist contact administrator";
            }

            Item itemToDelete = db.Item.Find(id);
            if (itemToDelete == null)
            {
                return HttpNotFound();
            }
            return View(itemToDelete);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item itemToDelete = new Item() { ID = id };
            db.Entry(itemToDelete).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //public JsonResult AutocompleteItems(string searchString)
        //{
        //    var result = unitOfWork.ItemRepository.Get(i => i.Name.StartsWith(searchString)).Select(i => new { id = i.ID, value = i.Name }).ToList();
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        public JsonResult AutocompleteUnits(string searchString)
        {
            var result = unitOfWork.UnitRepository.Get(i => i.Name.StartsWith(searchString)).Select(i => new { id = i.ID, value = i.Name }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
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
