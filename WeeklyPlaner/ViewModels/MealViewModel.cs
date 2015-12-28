using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeeklyPlaner.Models;

namespace WeeklyPlaner.ViewModels
{
    public class MealViewModel
    {
        public int MealID { get; set; }
        public string Title { get; set; }
        //public virtual MealAdditionalInfo MealAdditionalInfo { get; set; }
        public virtual ICollection<MealAssignedCourseData> Courses { get; set; }
    }
}