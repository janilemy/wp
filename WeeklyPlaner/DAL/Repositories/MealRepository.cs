using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeeklyPlaner.Models;
using WeeklyPlaner.ViewModels;

namespace WeeklyPlaner.DAL.Repositories
{
    public class MealRepository : GenericRepository<Meal>
    {
        public MealRepository(WeeklyPlanerContext context)
            : base(context)
        { }

        public void AddOrUpdateMealCourses(Meal meal, IEnumerable<MealAssignedCourseData> assignedMealCourses)
        {
            var mealCourses = new HashSet<int>(meal.Courses.Select(c => c.ID));
            
            foreach(var mealCourse in assignedMealCourses)
            {
                // check if meal course is checked
                if(mealCourse.Assigned)
                {
                    // add meal course if doesn`t already exist
                    if (!mealCourses.Contains(mealCourse.CourseID))
                    {
                        var course = new Course { ID = mealCourse.CourseID };
                        context.Course.Attach(course);
                        meal.Courses.Add(course);
                    }
                }
                // remove meal course if exist
                else
                {                    
                    if (mealCourses.Contains(mealCourse.CourseID))
                    {
                        meal.Courses.Remove(context.Course.Find(mealCourse.CourseID));
                    }
                }
            }

            context.SaveChanges();           
        }
        
        public void UpdateMealCalories(int mealId, int calories)
        {
            var meal = context.Meal.Find(mealId);
            meal.MealAdditionalInfo.Calories = calories;
            context.SaveChanges();
        }
    }
}