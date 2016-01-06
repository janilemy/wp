using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WeeklyPlaner.Models;

namespace WeeklyPlaner.ViewModels
{
    public class ItemViewModel
    {
        public int ID { get; set; }
        [Display(Name = "Kategorija")]
        public int ItemCategoryId { get; set; }
        [Display(Name = "Izdelek")]
        public string Name { get; set; }
        [Display(Name = "Proizvajalec")]
        public string Manufacturer { get; set; }

        public ItemAdditionalInfo ItemAdditionalInfo { get; set; }
    }
}