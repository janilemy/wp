using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeeklyPlaner.Models
{
    /// <summary>
    /// Class for units
    /// </summary>
    public class Unit
    {
        public int ID { get; set; }
        public int UnitTypeId { get; set; }
        [Display(Name = "Kratica")]
        public string Symbol { get; set; }
        [Display(Name = "Enota")]
        public string Name { get; set; }

        public virtual UnitType UnitType { get; set; }
        public virtual ICollection<MealItem> MealItem { get; set; }
        public virtual ICollection<ItemAdditionalInfo> ItemAdditionalInfo { get; set; }
    }

    public class UnitType
    {
        public int ID { get; set; }
        [Display(Name = "Tip enote")]
        public string Title {get; set;}

        public virtual ICollection<Unit> Unit  {get; set;}
    }
}