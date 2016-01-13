using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeeklyPlaner.Models;

namespace WeeklyPlaner.ViewModels
{
    public class ShoppingListViewModel
    {
        public int ID { get; set; }
        public List<Item> ItemSuggestions { get; set; }
        public List<Item> Items { get; set; }
    }
}