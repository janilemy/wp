using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeeklyPlaner.Models;

namespace WeeklyPlaner.DAL.Repositories
{
    public class MealRepository : GenericRepository<Meal>
    {
        public MealRepository(WeeklyPlanerContext context)
            : base(context)
        { }

        public void AddOrUpdateMealCourses(Meal meal, IEnumerable<MealAssignedCourseData> assignedMealCourses)
        {
            foreach(var assignedMealCourse in assignedMealCourses)
            {
                if(assignedMealCourse.Assigned)
                {
                    var course = new Course { ID = assignedMealCourse.CourseID };
                    context.Course.Attach(course);
                    meal.Courses.Add(course);
                }
            }                                       
        }
        
        public void UpdateMealCalories(int mealId, int calories)
        {
            var meal = context.Meal.Find(mealId);
            meal.MealAdditionalInfo.Calories = calories;
            context.SaveChanges();
        }
    }
}