using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WeeklyPlaner.Models
{
    /// <summary>
    /// Class for meals
    /// </summary>
    public class Meal
    {
        public int ID { get; set; }
        [Display(Name = "Uporabnik")]
        public int UserID { get; set; }
        [Display(Name = "Obrok")]
        public string Title { get; set; }

        public Meal()
        {
            Courses = new List<Course>();
        }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual MealAdditionalInfo MealAdditionalInfo { get; set; }
        public virtual ICollection<MealItem> MealItem { get; set; }        
        public virtual ICollection<Planer> Planer { get; set; }
    }

    public class MealAdditionalInfo
    {
        [Key, ForeignKey("Meal")]
        public int MealId { get; set; }
        [Display(Name = "Beljakovine")]
        public double? Protein { get; set; }
        [Display(Name = "Ogljikovi hidrati")]
        public double? CarbonHidrates { get; set; }
        [Display(Name = "Maščobe")]
        public double? Fats { get; set; }
        [Display(Name = "Vlaknine")]
        public double? Fibers { get; set; }
        [Display(Name = "Kalorije")]
        public int? Calories { get; set; }

        [Display(Name = "Cena")]
        public decimal? Price { get; set; }

        public virtual Meal Meal { get; set; }
    }

    // Class for meal ingredients
    public class MealItem
    {
        public int ID { get; set; }
        [Display(Name = "Obrok")]
        public int MealId { get; set; }
        [Display(Name = "Sestavina")]
        public int ItemId { get; set; }

        [Display(Name = "Enota")]
        public int UnitId { get; set; }
        [Display(Name = "Količina")]
        public double Quantity { get; set; }

        public virtual Meal Meal { get; set; }
        public virtual Unit Unit { get; set; }
        public virtual Item Item { get; set; }        
    }

    public class MealItemView
    {
        public int ID { get; set; }
        public int MealId { get; set; }
        public int ItemId { get; set; }
        public int UnitId { get; set; }
        public double Quantity { get; set; }
    }

    
}