using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeeklyPlaner.Models;

namespace WeeklyPlaner.ViewModels
{
    public class MealViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        //public virtual MealAdditionalInfo MealAdditionalInfo { get; set; }
        public virtual ICollection<MealAssignedCourseData> Courses { get; set; }
    }

    public class MealAssignedCourseData
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public bool Assigned { get; set; }
    }
}