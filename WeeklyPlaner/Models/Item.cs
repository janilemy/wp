using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WeeklyPlaner.Models
{    
    /// <summary>
    ///  Class for all items
    /// </summary>
    public class Item
    {
        public int ID { get; set; }
        [Display(Name = "Kategorija")]
        public int ItemCategoryId { get; set; }
        [Display(Name = "Izdelek")]
        public string Name { get; set; }     

        public virtual ItemCategory ItemCategory { get; set; }
        public virtual ICollection<ItemAdditionalInfo> ItemAdditionalInfo { get; set; }
        public virtual ICollection<MealItem> MealItem { get; set; }
        public virtual ICollection<FavouriteItem> FavouriteItem { get; set; }
    }

    /// <summary>
    ///  Class for item categories
    /// </summary>
    public class ItemCategory
    {
        [Display(Name = "Kategorija")]
        public int ID { get; set; }
        [Display(Name = "Kategorija")]
        public string Category { get; set; }

        public virtual ICollection<Item> Item { get; set; }
    }

    /// <summary>
    /// Class for item additional information
    /// </summary>
    public class ItemAdditionalInfo
    {        
        public int ID { get; set; }        
        [Display(Name = "Enota")]
        public int? UnitId { get; set; }
        [Display(Name = "Izdelek")]
        public int ItemId { get; set; }
        [Display(Name = "Količina")]
        public double? Quantity { get; set; }        
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
        [Display(Name="Cena")]
        public decimal? ItemPrice { get; set; }
        [Display(Name = "Proizvajalec")]
        public string Manufacturer { get; set; }         

        public virtual Item Item { get; set; }
        public virtual Unit Unit { get; set; }        
    }

    public class FavouriteItem
    {
        public int ID { get; set; }

        [Display(Name="Uporabnik")]
        public int UserId { get; set; }
        [Display(Name = "Izdelek")]      
        public int ItemId { get; set; }
        [Display(Name = "Izdelek")]
        public Item Item { get; set; }
    }
}