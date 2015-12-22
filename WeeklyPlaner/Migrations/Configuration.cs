namespace WeeklyPlaner.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WeeklyPlaner.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WeeklyPlaner.DAL.WeeklyPlanerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "WeeklyPlaner.DAL.WeeklyPlanerContext";
        }

        protected override void Seed(WeeklyPlaner.DAL.WeeklyPlanerContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            // Set default courses
            var courses = new List<Course>
            {
                new Course { ID = 1, Title="Zajtrk" },
                new Course { ID = 2, Title="Malica" },
                new Course { ID = 3, Title="Kosilo" },
                new Course { ID = 4, Title="Veèerja" },
            };

            courses.ForEach(c => context.Course.AddOrUpdate(c));
            context.SaveChanges();

            var unitTypes = new List<UnitType>
            {
                new UnitType { ID = 1, Title="Tekoèine"},
                new UnitType { ID = 2, Title="Težinske enote"}
            };

            unitTypes.ForEach(ut => context.UnitType.AddOrUpdate(ut));
            context.SaveChanges();

            var units = new List<Unit>
            {
                new Unit { ID = 1, Symbol="ml", Title="Mililiter", UnitTypeId=1},
                new Unit { ID = 2, Symbol="l", Title="Liter", UnitTypeId=1},                
                new Unit { ID = 3, Symbol="mg", Title="Miligram", UnitTypeId=2},
                new Unit { ID = 4, Symbol="g", Title="Gram", UnitTypeId=2},
                new Unit { ID = 5, Symbol="dag", Title="Dekagram", UnitTypeId=2},
                new Unit { ID = 6, Symbol="kg", Title="Kilogram", UnitTypeId=2}                
            };             
 
            units.ForEach(u => context.Unit.AddOrUpdate(u));
            context.SaveChanges();

            // Set default categories
            var itemCategories = new List<ItemCategory>
            {
                new ItemCategory { ID = 1, Category="Sadje" },
                new ItemCategory { ID = 2, Category="Zelenjava"},
                new ItemCategory { ID = 3, Category="Meso" },
                new ItemCategory { ID = 4, Category="Mleèni izdelki" },
                new ItemCategory { ID = 5, Category="Olja in mašèobe" },
                new ItemCategory { ID = 6, Category="Testenine in kosmièi" },                
                new ItemCategory { ID = 7, Category="Kruh in krušni izdelki" }, 
                new ItemCategory { ID = 8, Category="Riž" },
                new ItemCategory { ID = 9, Category="Kruh in krušni izdelki" },
                new ItemCategory { ID = 10, Category="Zelišèa" },
                new ItemCategory { ID = 11, Category="Pijaèe" },
                new ItemCategory { ID = 12, Category="Èistila" }
            };

            itemCategories.ForEach(ic => context.ItemCategory.AddOrUpdate(ic));
            context.SaveChanges();

            // Set default items
            var items = new List<Item>
            {
                new Ingredient { ID = 1, ItemCategoryId=1, ItemName="Banana", Calories=89, Protein=1.09, CarbonHidrates=22.84, Fats=0.33, Fibers=3  },
                new Ingredient { ID = 2, ItemCategoryId=1, ItemName="Jabolko", Calories=52, Protein=0.26, CarbonHidrates=13.81, Fats=0.17, Fibers=2 },
                new Ingredient { ID = 3, ItemCategoryId=1, ItemName="Borovnice", Calories=57 , Protein=0.74, CarbonHidrates=14.49, Fats=0.33, Fibers=2 },
                new Ingredient { ID = 4, ItemCategoryId=4, ItemName="Jajce", Calories=196, Protein=13.63, CarbonHidrates=0.88, Fats=15.31, Fibers=0 },
                new Ingredient { ID = 5, ItemCategoryId=4, ItemName="Jajce, beljak", Calories=52, Protein=10.9, CarbonHidrates=0.73, Fats=0.17, Fibers=0 },
                new Ingredient { ID = 6, ItemCategoryId=4, ItemName="Jajce, rumenjak", Calories=322, Protein=15.86, CarbonHidrates=3.59, Fats=26.54, Fibers=0 },
                new Ingredient { ID = 7, ItemCategoryId=4, ItemName="Sir, edamec", Calories=357, Protein=24.99, CarbonHidrates=1.43, Fats=27.8, Fibers=0 },
                new Ingredient { ID = 8, ItemCategoryId=4, ItemName="Sir, gavda", Calories=356, Protein=24.94, CarbonHidrates=2.22, Fats=27.44, Fibers=0 },
                new Ingredient { ID = 9, ItemCategoryId=4, ItemName="Skuta, nepasirana light", Calories=70, Protein=13, CarbonHidrates=3, Fats=0, Fibers=0 },
                new Ingredient { ID = 9, ItemCategoryId=6, ItemName="Ovseni kosmièi", Calories=372, Protein=13.5, CarbonHidrates=58.7, Fats=7, Fibers=10},
                new Ingredient { ID = 10, ItemCategoryId=3, ItemName="Pišèanec, prsa", Calories=110, Protein=23.09, CarbonHidrates=0, Fats=1.24, Fibers=0},
                new Ingredient { ID = 11, ItemCategoryId=3, ItemName="Puran, prsa", Calories=115, Protein=23.56, CarbonHidrates=0, Fats=1.56, Fibers=0},
                new Ingredient { ID = 12, ItemCategoryId=3, ItemName="Govedina, mleta", Calories=254, Protein=17.17, CarbonHidrates=0, Fats=20, Fibers=0},
                new Ingredient { ID = 13, ItemCategoryId=2, ItemName="Brokoli", Calories=34, Protein=2.82, CarbonHidrates=6.64, Fats=0.37, Fibers=2.6 },
                new Ingredient { ID = 14, ItemCategoryId=2, ItemName="Cvetaèa", Calories=25, Protein=1.98, CarbonHidrates=5.3, Fats=0.1, Fibers=2.5 },
                new Ingredient { ID = 15, ItemCategoryId=2, ItemName="Kumara", Calories=12, Protein=0.59, CarbonHidrates=2.16, Fats=0.16, Fibers=0.7 },
                new Ingredient { ID = 16, ItemCategoryId=2, ItemName="Grah", Calories=81, Protein=5.42, CarbonHidrates=14.46, Fats=0.4, Fibers=5.1 },
                new Ingredient { ID = 17, ItemCategoryId=2, ItemName="Krompir", Calories=93, Protein=1.96, CarbonHidrates=21.55, Fats=0.1, Fibers=1.5 },
                new Ingredient { ID = 18, ItemCategoryId=2, ItemName="Špinaèa", Calories=23, Protein=2.86, CarbonHidrates=3.63, Fats=0.39, Fibers=2.2 },
                new Ingredient { ID = 19, ItemCategoryId=2, ItemName="Buèka", Calories=16, Protein=1.21, CarbonHidrates=3.35, Fats=0.18, Fibers=1.1 },
                new Ingredient { ID = 20, ItemCategoryId=2, ItemName="Korenje", Calories=35, Protein=0.64, CarbonHidrates=8.24, Fats=0.13, Fibers=2.9 },
                new Ingredient { ID = 21, ItemCategoryId=8, ItemName="Mandlji", Calories=578, Protein=21.26, CarbonHidrates=19.74, Fats=50.64, Fibers=11.8 },
                new Ingredient { ID = 22, ItemCategoryId=8, ItemName="Lešniki", Calories=628, Protein=14.95, CarbonHidrates=16.7, Fats=60.75, Fibers=9.7 },
                new Ingredient { ID = 23, ItemCategoryId=8, ItemName="Makadamija", Calories=718, Protein=7.91, CarbonHidrates=13.82, Fats=75.77, Fibers=8.6 },
                new Ingredient { ID = 24, ItemCategoryId=8, ItemName="Pistacija", Calories=557, Protein=20.61, CarbonHidrates=27.97, Fats=44.44, Fibers=10.3 },
                new Ingredient { ID = 25, ItemCategoryId=8, ItemName="Arašidi", Calories=585, Protein=23, CarbonHidrates=21, Fats=49, Fibers=8 },
                new Ingredient { ID = 26, ItemCategoryId=2, ItemName="Fižol, èrni", Calories=132, Protein=8.86, CarbonHidrates=23.71, Fats=0.54, Fibers=8.7 },
                new Ingredient { ID = 27, ItemCategoryId=2, ItemName="Fižol, beli", Calories=139, Protein=9.73, CarbonHidrates=25.09, Fats=0.35, Fibers=6.3 },
                new Ingredient { ID = 28, ItemCategoryId=2, ItemName="Fižol, rumeni", Calories=144, Protein=9.16, CarbonHidrates=25.27, Fats=1.08, Fibers=10.4 },
                new Ingredient { ID = 29, ItemCategoryId=2, ItemName="Èièerika", Calories=164, Protein=8.86, CarbonHidrates=27.42, Fats=2.59, Fibers=7.6 },
                new Ingredient { ID = 30, ItemCategoryId=2, ItemName="Arašidovo maslo", Calories=588, Protein=25.09, CarbonHidrates=19.56, Fats=50.39, Fibers=6 },
                new Ingredient { ID = 31, ItemCategoryId=7, ItemName="Tortilije, koruzne", Calories=218, Protein=5.7, CarbonHidrates=44.64, Fats=2.85, Fibers=6.3 },
                new Ingredient { ID = 32, ItemCategoryId=7, ItemName="Kruh, rženi", Calories=258, Protein=8.5, CarbonHidrates=48.3, Fats=3.3, Fibers=5.8 },
                new Ingredient { ID = 33, ItemCategoryId=8, ItemName="Riž, rjav", Calories=111, Protein=2.58, CarbonHidrates=22.96, Fats=0.9, Fibers=1.8 },
                new Ingredient { ID = 34, ItemCategoryId=8, ItemName="Riž, beli", Calories=130, Protein=2.69, CarbonHidrates=28.17, Fats=0.28, Fibers=0.4 },
                new Ingredient { ID = 35, ItemCategoryId=6, ItemName="Makaroni, polnozrnati", Calories=124, Protein=5.33, CarbonHidrates=26.54, Fats=0.54, Fibers=2.8 },
                new Ingredient { ID = 36, ItemCategoryId=6, ItemName="Špageti, polnozrnati", Calories=124, Protein=5.33, CarbonHidrates=26.54, Fats=0.54, Fibers=4.5 }
                //new Ingredient { ID = , ItemCategoryId=, ItemName="", Calories=, Protein=, CarbonHidrates=, Fats=, Fibers=0 }
            };

            items.ForEach(i => context.Item.AddOrUpdate(i));
            context.SaveChanges();

            // Set default meals
            var meals = new List<Meal>
            {
                new Meal { ID=1, UserID=1, Title="Omleta" },
                new Meal { ID=2, UserID=1, Title="Ovseni kosmièi z borovnicami in banano"},
                new Meal { ID=3, UserID=1, Title="Špageti bolognese"},
                new Meal { ID=4, UserID=1, Title="Tortilije s pišèanèjim mesom"},
                new Meal { ID=5, UserID=1, Title="Rižota s pišèanèjim mesom"}
            };

            meals.ForEach(m => context.Meal.AddOrUpdate(m));
            context.SaveChanges();

            // Set default meal items
            var mealItems = new List<MealItem>
            {
                new MealItem { ID=1, MealId=2, IngredientId=1, UnitId=4, Quantity=200  },
                new MealItem { ID=2, MealId=2, IngredientId=3, UnitId=4, Quantity=30  },
                new MealItem { ID=3, MealId=2, IngredientId=5, UnitId=4, Quantity=50 }
            };

            mealItems.ForEach(mi => context.MealItem.AddOrUpdate(mi));
            context.SaveChanges();

            var mealAdditionalInfo = new List<MealAdditionalInfo>
            {
                new MealAdditionalInfo { MealId=1, Calories=468, CarbonHidrates=6, Fats=42, Protein=53, Fibers=0 },
                new MealAdditionalInfo { MealId=2, Calories=310, CarbonHidrates=52, Fats=6, Protein=11, Fibers=0 }
            };

            mealAdditionalInfo.ForEach(mai => context.MealAdditionalInfo.AddOrUpdate(mai));
            context.SaveChanges();

            var planer = new List<Planer>
            {
                new Planer { ID=1, PlanedOn=DateTime.Now.AddDays(1) },
                new Planer { ID=1, PlanedOn=DateTime.Now.AddDays(2) },
                new Planer { ID=1, PlanedOn=DateTime.Now.AddDays(3) },
                new Planer { ID=1, PlanedOn=DateTime.Now.AddDays(4) },
                new Planer { ID=1, PlanedOn=DateTime.Now.AddDays(5) }
            };

            planer.ForEach(p => context.Planer.AddOrUpdate(p));
            context.SaveChanges();

            var planerMeals = new List<PlanerMeals>
            {
                new PlanerMeals { PlanerId=1, MealId=1, CourseId=1 },
                new PlanerMeals { PlanerId=1, MealId=2, CourseId=1 },
                new PlanerMeals { PlanerId=1, MealId=3, CourseId=2 },
                new PlanerMeals { PlanerId=2, MealId=1, CourseId=1 },
                new PlanerMeals { PlanerId=2, MealId=2, CourseId=1 },
                new PlanerMeals { PlanerId=2, MealId=4, CourseId=2 },
                new PlanerMeals { PlanerId=3, MealId=1, CourseId=1 },
                new PlanerMeals { PlanerId=3, MealId=2, CourseId=1 },
                new PlanerMeals { PlanerId=3, MealId=5, CourseId=2 }
            };

            planerMeals.ForEach(pm => context.PlanerMeals.AddOrUpdate(pm));
            context.SaveChanges();
        }
    }
}
