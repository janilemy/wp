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
        public ActionResult Create(MealViewModel mealViewModel)
        {
            if (ModelState.IsValid)
            {
                var meal = new Meal { Title = mealViewModel.Title };

                unitOfWork.MealRepository.AddOrUpdateMealCourses(meal, mealViewModel.Courses);
                unitOfWork.MealRepository.Insert(meal);
                unitOfWork.MealRepository.InsertMealItems(mealViewModel.MealItems);

                return RedirectToAction("Index");
            }

            return View(mealViewModel);
        }

        private ICollection<MealAssignedCourseData> PopulateMealCourseData()
        {
            var courses = unitOfWork.CourseRepository.Get().ToList();
            var assignedCourses = new List<MealAssignedCourseData>();

            foreach (var item in courses)
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

        private ICollection<MealAssignedCourseData> PopulateMealAssignedCourseData(Meal meal)
        {
            var allCourses = unitOfWork.CourseRepository.Get();
            var mealCourses = new HashSet<int>(meal.Courses.Select(c => c.ID));            
            var assignedCourses = new List<MealAssignedCourseData>();

            foreach (var item in allCourses)
            {
                assignedCourses.Add(new MealAssignedCourseData
                {
                    CourseID = item.ID,
                    Title = item.Title,
                    Assigned = mealCourses.Contains(item.ID)
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

            var mealViewModel = new MealViewModel { ID = meal.ID, Title = meal.Title, Courses = PopulateMealAssignedCourseData(meal) };

            if (meal == null)
            {
                return HttpNotFound();
            }            

            return View(mealViewModel);
        }

        // POST: Meals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MealViewModel mealViewModel)
        {
            var meal = unitOfWork.MealRepository.GetByID(mealViewModel.ID);

            if (ModelState.IsValid)
            {                                
                unitOfWork.MealRepository.Update(meal);

                unitOfWork.MealRepository.AddOrUpdateMealCourses(meal, mealViewModel.Courses);

                return RedirectToAction("Index");
            }

            PopulateMealAssignedCourseData(meal);

            return View(mealViewModel);
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
