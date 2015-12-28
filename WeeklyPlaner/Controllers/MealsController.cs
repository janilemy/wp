using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WeeklyPlaner.DAL;
using WeeklyPlaner.DAL.Repositories;
using WeeklyPlaner.Models;
using WeeklyPlaner.ViewModels;

namespace WeeklyPlaner.Controllers
{
    public class MealsController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: Meals
        public ActionResult Index()
        {
            //var meal = db.Meal.Include(m => m.MealAdditionalInfo);

            // Get list of meals with unitOfWork
            var meal = unitOfWork.MealRepository.Get(includeProperties: "Courses, MealAdditionalInfo");
            return View(meal.ToList());
        }

        // GET: Meals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Meal meal = unitOfWork.MealRepository.GetByID(id);
            if (meal == null)
            {
                return HttpNotFound();
            }
            return View(meal);
        }

        // GET: Meals/Create
        public ActionResult Create()
        {            
            var mealViewModel = new MealViewModel { Courses = PopulateMealCourseData() };

            return View(mealViewModel);
        }

        // POST: Meals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MealViewModel mealViewModel)
        {
            if (ModelState.IsValid)
            {
                var meal = new Meal { Title = mealViewModel.Title };

                unitOfWork.MealRepository.AddOrUpdateMealCourses(meal, mealViewModel.Courses);
                unitOfWork.MealRepository.Insert(meal);

                return RedirectToAction("Index");
            }
            
            return View(mealViewModel);
        }

        private ICollection<MealAssignedCourseData> PopulateMealCourseData()
        {
            var courses = unitOfWork.CourseRepository.Get().ToList();
            var assignedCourses = new List<MealAssignedCourseData>();

            foreach(var item in courses)
            {
                assignedCourses.Add(new MealAssignedCourseData
                    {
                        CourseID = item.ID,   
                        Title = item.Title,
                        Assigned = false
                    });
            }

            return assignedCourses;
        }

        // GET: Meals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meal meal = unitOfWork.MealRepository.GetByID(id);
            if (meal == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(unitOfWork.MealRepository.context.MealAdditionalInfo, "MealId", "MealId", meal.ID);
            return View(meal);
        }

        // POST: Meals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserID,Title")] Meal meal)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.MealRepository.Update(meal);
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(unitOfWork.MealRepository.context.MealAdditionalInfo, "MealId", "MealId", meal.ID);
            return View(meal);
        }

        // GET: Meals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meal meal = unitOfWork.MealRepository.GetByID(id);
            if (meal == null)
            {
                return HttpNotFound();
            }
            return View(meal);
        }

        // POST: Meals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Meal meal = unitOfWork.MealRepository.GetByID(id);
            unitOfWork.MealRepository.Delete(meal);
            return RedirectToAction("Index");
        }

        // POST: Meals/UpdateMealCalories
        public ActionResult UpdateMealCalories(int mealId, int calories)
        {
            unitOfWork.MealRepository.UpdateMealCalories(mealId, calories);

            return View();
        }
    }
}
