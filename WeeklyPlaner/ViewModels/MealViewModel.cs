using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WeeklyPlaner.Models;

namespace WeeklyPlaner.ViewModels
{
    public class MealViewModel
    {
        [Key]
        public int ID { get; set; }
        [Display(Name="Ime obroka")]
        public string Title { get; set; }
        
        [Display(Name="Sestavine")]
        public List<MealItemView> MealItems { get; set; }
        [Display(Name="Postopek")]
        public MealPreparation MealPreparation { get; set; }

        //public virtual MealAdditionalInfo MealAdditionalInfo { get; set; }
        [Display(Name="Tip obroka")]
        public virtual ICollection<MealAssignedCourseData> Courses { get; set; }        
    }

    public class MealAssignedCourseData
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public bool Assigned { get; set; }
    }
}