using System;
using System.Collections.Generic;

namespace WeeklyPlaner.Models
{
    public class ShoppingList
    {
        public int ID { get; set; }

        public DateTime Timestamp { get; set; }

        public virtual ICollection<ShoppingListItem> ShoppingListItems { get; set; }
    }

    public class ShoppingListItem
    {
        public int ID { get; set; }

        public int ShoppingListId { get; set; }

        public int ItemId { get; set; }

        public double Quantity { get; set; }

        public int? UnitId { get; set; }

        public virtual ShoppingList ShoppingList { get; set; }

        public virtual Item Item { get; set; }

        public virtual Unit Unit { get; set; }

    }
}