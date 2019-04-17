using System.Collections.Generic;
using WeeklyPlaner.Models;

namespace WeeklyPlaner.DAL
{
    public class WeeklyPlanerInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<WeeklyPlanerContext>
    {
        // INITIAL VALUES FOR TESTING PURPOSES
        protected override void Seed(WeeklyPlanerContext context)
        {
            // Set default courses
            var courses = new List<Course>
            {
                new Course { ID = 1, Title="Zajtrk" },
                new Course { ID = 2, Title="Malica" },
                new Course { ID = 3, Title="Kosilo" },
                new Course { ID = 4, Title="Večerja" },
            };

            courses.ForEach(c => context.Course.Add(c));
            context.SaveChanges();

            var unitTypes = new List<UnitType>
            {
                new UnitType { ID = 1, Title="Tekočine"},
                new UnitType { ID = 2, Title="Mass"}
            };

            unitTypes.ForEach(ut => context.UnitType.Add(ut));
            context.SaveChanges();

            var units = new List<Unit>
            {
                new Unit { Symbol="ml", Name="Mililiter", UnitTypeId=1},
                new Unit { Symbol="l", Name="Liter", UnitTypeId=1},
                new Unit { Symbol="mg", Name="Miligram", UnitTypeId=2},
                new Unit { Symbol="g", Name="Gram", UnitTypeId=2},
                new Unit { Symbol="dag", Name="Dekagram", UnitTypeId=2},
                new Unit { Symbol="kg", Name="Kilogram", UnitTypeId=2}
            };

            units.ForEach(u => context.Unit.Add(u));
            context.SaveChanges();

            // Set default categories
            var itemCategories = new List<ItemCategory>
            {
                new ItemCategory { Category="Sadje" },
                new ItemCategory { Category="Zelenjava"},
                new ItemCategory { Category="Meso" },
                new ItemCategory { Category="Mlečni izdelki" },
                new ItemCategory { Category="Olja in maščobe" },
                new ItemCategory { Category="Testenine in kosmiči" },
                new ItemCategory { Category="Riž" },
                new ItemCategory { Category="Oreščki in semena" },
                new ItemCategory { Category="Zelišča" },
                new ItemCategory {  Category="Pijače" },
                new ItemCategory {  Category="Čistila" }
            };

            itemCategories.ForEach(ic => context.ItemCategory.Add(ic));
            context.SaveChanges();

            // Set default meals
            var meals = new List<Meal>
            {
                new Meal { ID=1, Title="Omleta" },
                new Meal { ID=2, Title="Ovseni kosmiči z borovnicami in banano"},
                new Meal { ID=3, Title="Špageti bolognese"},
                new Meal { ID=4, Title="Tortilije s piščančjim mesom"}
            };

            meals.ForEach(m => context.Meal.Add(m));
            context.SaveChanges();

            // Set default meal items
            var mealItems = new List<MealItem>
            {
                new MealItem { ID=1, MealId=2, UnitId=4, Quantity=200, ItemId=1 },
                new MealItem { ID=2, MealId=2, UnitId=4, Quantity=30, ItemId=3 },
                new MealItem { ID=2, MealId=2, UnitId=4, Quantity=50, ItemId=5 }
            };

            mealItems.ForEach(mi => context.MealItem.Add(mi));
            context.SaveChanges();

            var mealAdditionalInfo = new List<MealAdditionalInfo>
            {
                new MealAdditionalInfo { MealId=1, Calories=468, CarbonHidrates=6, Fats=42, Protein=53, Fibers=0 },
                new MealAdditionalInfo { MealId=2, Calories=310, CarbonHidrates=52, Fats=6, Protein=11, Fibers=0 }
            };

            mealAdditionalInfo.ForEach(mai => context.MealAdditionalInfo.Add(mai));
            context.SaveChanges();
        }
    }
}