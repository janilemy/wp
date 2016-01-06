using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeeklyPlaner.Models
{    
    /// <summary>
    /// Class for planed meals
    /// </summary>
    public class Planer
    {
        public int ID { get; set; }
        [Display(Name = "Datum"), DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime PlanedOn { get; set; }
        public virtual ICollection<PlanerMeals> PlanerMeals { get; set; }
    }

    public class PlanerMeals
    {
        public int PlanerMealsId { get; set; }
        public int PlanerId { get; set; }
        public int MealId { get; set; }
        public int CourseId { get; set; }
        public virtual Meal Meal { get; set; }
        public virtual Course Course { get; set; }
        public virtual Planer Planer { get; set; }
    }

    /// <summary>
    /// Class for meal courses
    /// </summary>
    public class Course
    {
        public int ID { get; set; }
        [Display(Name = "Tip obroka")]
        public string Title { get; set; }

        public ICollection<Planer> Planer { get; set; }
        public ICollection<Meal> Meal { get; set; }
    }
}