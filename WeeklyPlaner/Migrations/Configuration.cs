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
                new Course { ID = 2, Title="Malica, dopoldanska" },
                new Course { ID = 3, Title="Kosilo" },
                new Course { ID = 4, Title="Malica, popoldanska" },
                new Course { ID = 5, Title="Pred treningom" },
                new Course { ID = 6, Title="Po treningu" },
                new Course { ID = 7, Title="Veèerja" },
            };

            courses.ForEach(c => context.Course.AddOrUpdate(c));
            context.SaveChanges();

            var unitTypes = new List<UnitType>
            {
                new UnitType { ID = 1, Title="Tekoèine enote"},
                new UnitType { ID = 2, Title="Težinske enote"},
                new UnitType { ID = 3, Title="Ostale enote"}
            };

            unitTypes.ForEach(ut => context.UnitType.AddOrUpdate(ut));
            context.SaveChanges();

            var units = new List<Unit>
            {
                new Unit { ID = 1, Symbol="ml", Name="Mililiter", UnitTypeId=1},
                new Unit { ID = 2, Symbol="l", Name="Liter", UnitTypeId=1},                
                new Unit { ID = 3, Symbol="mg", Name="Miligram", UnitTypeId=2},
                new Unit { ID = 4, Symbol="g", Name="Gram", UnitTypeId=2},
                new Unit { ID = 5, Symbol="dag", Name="Dekagram", UnitTypeId=2},
                new Unit { ID = 6, Symbol="kg", Name="Kilogram", UnitTypeId=2},
                new Unit { ID = 7, Symbol="kom", Name="Kos", UnitTypeId=3},
                new Unit { ID = 8, Symbol="Žlica", Name="Žlica", UnitTypeId=3}
            };

            units.ForEach(u => context.Unit.AddOrUpdate(u));
            context.SaveChanges();

            // Set default categories
            var itemCategories = new List<ItemCategory>
            {
                new ItemCategory { ID = 1, Category="Sadje" },
                new ItemCategory { ID = 2, Category="Zelenjava"},
                new ItemCategory { ID = 3, Category="Meso" },
                new ItemCategory { ID = 4, Category="Klobase" },
                new ItemCategory { ID = 5, Category="Mleèni izdelki" },
                new ItemCategory { ID = 6, Category="Olja in mašèobe" },
                new ItemCategory { ID = 7, Category="Testenine in kosmièi" },                
                new ItemCategory { ID = 8, Category="Kruh in krušni izdelki" }, 
                new ItemCategory { ID = 9, Category="Riž" },
                new ItemCategory { ID = 10, Category="Orešèki" },
                new ItemCategory { ID = 11, Category="Zaèimbe in zelišèa" },
                new ItemCategory { ID = 12, Category="Pijaèe" },
                new ItemCategory { ID = 13, Category="Namazi" },
                new ItemCategory { ID = 14, Category="Èistila" }
            };

            itemCategories.ForEach(ic => context.ItemCategory.AddOrUpdate(ic));
            context.SaveChanges();

            // Set default items
            var items = new List<Item>
            {
                new Item { ID = 1, ItemCategoryId=1, Name="Banana"},
                new Item { ID = 2, ItemCategoryId=1, Name="Jabolko"},
                new Item { ID = 3, ItemCategoryId=1, Name="Borovnice"},
                new Item { ID = 4, ItemCategoryId=5, Name="Jajce"},
                new Item { ID = 5, ItemCategoryId=5, Name="Jajce, beljak"},
                new Item { ID = 6, ItemCategoryId=5, Name="Jajce, rumenjak"},
                new Item { ID = 7, ItemCategoryId=5, Name="Sir, edamec"},
                new Item { ID = 8, ItemCategoryId=5, Name="Sir, gavda"},
                new Item { ID = 9, ItemCategoryId=5, Name="Skuta, nepasirana light", Manufacturer="Spar"},
                new Item { ID = 10, ItemCategoryId=8, Name="Ovseni kosmièi"},
                new Item { ID = 11, ItemCategoryId=3, Name="Pišèanec, prsa"},
                new Item { ID = 12, ItemCategoryId=3, Name="Puran, prsa"},
                new Item { ID = 13, ItemCategoryId=3, Name="Govedina, mleta"},
                new Item { ID = 14, ItemCategoryId=2, Name="Brokoli"},
                new Item { ID = 15, ItemCategoryId=2, Name="Cvetaèa"},
                new Item { ID = 16, ItemCategoryId=2, Name="Kumara"},
                new Item { ID = 17, ItemCategoryId=2, Name="Grah"},
                new Item { ID = 18, ItemCategoryId=2, Name="Krompir"},
                new Item { ID = 19, ItemCategoryId=2, Name="Špinaèa"},
                new Item { ID = 20, ItemCategoryId=2, Name="Buèka"},
                new Item { ID = 21, ItemCategoryId=2, Name="Korenje"},
                new Item { ID = 22, ItemCategoryId=10, Name="Mandlji"},
                new Item { ID = 23, ItemCategoryId=10, Name="Lešniki"},
                new Item { ID = 24, ItemCategoryId=10, Name="Makadamija"},
                new Item { ID = 25, ItemCategoryId=10, Name="Pistacija"},
                new Item { ID = 26, ItemCategoryId=10, Name="Arašidi"},
                new Item { ID = 27, ItemCategoryId=2, Name="Fižol, èrni"},
                new Item { ID = 28, ItemCategoryId=2, Name="Fižol, beli"},
                new Item { ID = 29, ItemCategoryId=2, Name="Fižol, rumeni"},
                new Item { ID = 30, ItemCategoryId=2, Name="Èièerika"},
                new Item { ID = 31, ItemCategoryId=2, Name="Arašidovo maslo", Manufacturer="Roks"},
                new Item { ID = 32, ItemCategoryId=7, Name="Tortilije, koruzne"},
                new Item { ID = 33, ItemCategoryId=7, Name="Kruh, rženi"},
                new Item { ID = 34, ItemCategoryId=9, Name="Riž, rjav"},
                new Item { ID = 35, ItemCategoryId=9, Name="Riž, beli"},
                new Item { ID = 36, ItemCategoryId=7, Name="Makaroni, polnozrnati"},
                new Item { ID = 37, ItemCategoryId=7, Name="Špageti, polnozrnati"},
                new Item { ID = 38, ItemCategoryId=4, Name="Slanina, prekajena" },
                new Item { ID = 39, ItemCategoryId=2, Name="Èebula"},
                new Item { ID = 40, ItemCategoryId=2, Name="Èesen"},
                new Item { ID = 41, ItemCategoryId=2, Name="Paprika, zelena"},
                new Item { ID = 42, ItemCategoryId=2, Name="Paprika, rdeèa"},
                new Item { ID = 43, ItemCategoryId=2, Name="Paprika, rumena"},
                new Item { ID = 44, ItemCategoryId=2, Name="Pelati"},
                new Item { ID = 45, ItemCategoryId=11, Name="Sol"},
                new Item { ID = 46, ItemCategoryId=11, Name="Poper"},
                new Item { ID = 47, ItemCategoryId=11, Name="Vegeta"},
                new Item { ID = 48, ItemCategoryId=11, Name="Origano"},
                new Item { ID = 49, ItemCategoryId=11, Name="Bazilika"},
                new Item { ID = 50, ItemCategoryId=11, Name="Majaron"},
                new Item { ID = 51, ItemCategoryId=11, Name="Lovorjev list"},
                new Item { ID = 52, ItemCategoryId=2, Name="Kokošja kocka"},
                new Item { ID = 53, ItemCategoryId=5, Name="Smetana za kuhanje"},
                new Item { ID = 54, ItemCategoryId=6, Name="Olje, arašidovo"},
                new Item { ID = 55, ItemCategoryId=2, Name="Mešanica za gobovo omako, Knorr Fix"}
                //new Item { ID = , ItemCategoryId=, Name="" }
            };

            items.ForEach(i => context.Item.AddOrUpdate(i));
            context.SaveChanges();

            var itemAdditionalInfo = new List<ItemAdditionalInfo>
            {
                new ItemAdditionalInfo { ID = 1, ItemId=1, Quantity=100, UnitId=4, Calories=89, Protein=1.09, CarbonHidrates=22.84, Fats=0.33, Fibers=3  },
                new ItemAdditionalInfo { ID = 2, ItemId=2, Quantity=100, UnitId=4, Calories=52, Protein=0.26, CarbonHidrates=13.81, Fats=0.17, Fibers=2 },
                new ItemAdditionalInfo { ID = 3, ItemId=3, Quantity=100, UnitId=4, Calories=57 , Protein=0.74, CarbonHidrates=14.49, Fats=0.33, Fibers=2 },
                new ItemAdditionalInfo { ID = 4, ItemId=4, Quantity=100, UnitId=4, Calories=196, Protein=13.63, CarbonHidrates=0.88, Fats=15.31, Fibers=0 },
                new ItemAdditionalInfo { ID = 5, ItemId=4, Quantity=1, UnitId=7, Calories=89, Protein=7, CarbonHidrates=1, Fats=7, Fibers=0 },
                new ItemAdditionalInfo { ID = 6, ItemId=5, Quantity=1, UnitId=7, Calories=16, Protein=3, CarbonHidrates=0, Fats=0, Fibers=0 },
                new ItemAdditionalInfo { ID = 7, ItemId=5, Quantity=100, UnitId=4, Calories=52, Protein=10.9, CarbonHidrates=0.73, Fats=0.17, Fibers=0 },
                new ItemAdditionalInfo { ID = 8, ItemId=6, Quantity=100, UnitId=4, Calories=322, Protein=15.86, CarbonHidrates=3.59, Fats=26.54, Fibers=0 },
                new ItemAdditionalInfo { ID = 9, ItemId=7, Quantity=100, UnitId=4, Calories=357, Protein=24.99, CarbonHidrates=1.43, Fats=27.8, Fibers=0 },
                new ItemAdditionalInfo { ID = 10, ItemId=8, Quantity=100, UnitId=4, Calories=356, Protein=24.94, CarbonHidrates=2.22, Fats=27.44, Fibers=0 },
                new ItemAdditionalInfo { ID = 11, ItemId=9, Quantity=100, UnitId=4, Calories=70, Protein=13, CarbonHidrates=3, Fats=0, Fibers=0, Shop="Spar"},
                new ItemAdditionalInfo { ID = 12, ItemId=10, Quantity=100, UnitId=4, Calories=372, Protein=13.5, CarbonHidrates=58.7, Fats=7, Fibers=10, Shop="Hofer", Price=0.49m},
                new ItemAdditionalInfo { ID = 13, ItemId=11, Quantity=100, UnitId=4, Calories=110, Protein=23.09, CarbonHidrates=0, Fats=1.24, Fibers=0},
                new ItemAdditionalInfo { ID = 14, ItemId=12, Quantity=100, UnitId=4, Calories=115, Protein=23.56, CarbonHidrates=0, Fats=1.56, Fibers=0},
                new ItemAdditionalInfo { ID = 15, ItemId=13, Quantity=100, UnitId=4, Calories=254, Protein=17.17, CarbonHidrates=0, Fats=20, Fibers=0},
                new ItemAdditionalInfo { ID = 16, ItemId=14, Quantity=100, UnitId=4, Calories=34, Protein=2.82, CarbonHidrates=6.64, Fats=0.37, Fibers=2.6 },
                new ItemAdditionalInfo { ID = 17, ItemId=15, Quantity=100, UnitId=4, Calories=25, Protein=1.98, CarbonHidrates=5.3, Fats=0.1, Fibers=2.5 },
                new ItemAdditionalInfo { ID = 18, ItemId=16, Quantity=100, UnitId=4, Calories=12, Protein=0.59, CarbonHidrates=2.16, Fats=0.16, Fibers=0.7 },
                new ItemAdditionalInfo { ID = 19, ItemId=17, Quantity=100, UnitId=4, Calories=81, Protein=5.42, CarbonHidrates=14.46, Fats=0.4, Fibers=5.1 },
                new ItemAdditionalInfo { ID = 20, ItemId=18, Quantity=100, UnitId=4, Calories=93, Protein=1.96, CarbonHidrates=21.55, Fats=0.1, Fibers=1.5 },
                new ItemAdditionalInfo { ID = 21, ItemId=19, Quantity=100, UnitId=4, Calories=23, Protein=2.86, CarbonHidrates=3.63, Fats=0.39, Fibers=2.2 },
                new ItemAdditionalInfo { ID = 22, ItemId=20, Quantity=100, UnitId=4, Calories=16, Protein=1.21, CarbonHidrates=3.35, Fats=0.18, Fibers=1.1 },
                new ItemAdditionalInfo { ID = 23, ItemId=21, Quantity=100, UnitId=4, Calories=35, Protein=0.64, CarbonHidrates=8.24, Fats=0.13, Fibers=2.9 },
                new ItemAdditionalInfo { ID = 24, ItemId=22, Quantity=100, UnitId=4, Calories=578, Protein=21.26, CarbonHidrates=19.74, Fats=50.64, Fibers=11.8 },
                new ItemAdditionalInfo { ID = 25, ItemId=23, Quantity=100, UnitId=4, Calories=628, Protein=14.95, CarbonHidrates=16.7, Fats=60.75, Fibers=9.7 },
                new ItemAdditionalInfo { ID = 26, ItemId=24, Quantity=100, UnitId=4, Calories=718, Protein=7.91, CarbonHidrates=13.82, Fats=75.77, Fibers=8.6 },
                new ItemAdditionalInfo { ID = 27, ItemId=25, Quantity=100, UnitId=4, Calories=557, Protein=20.61, CarbonHidrates=27.97, Fats=44.44, Fibers=10.3 },
                new ItemAdditionalInfo { ID = 28, ItemId=26, Quantity=100, UnitId=4, Calories=585, Protein=23, CarbonHidrates=21, Fats=49, Fibers=8 },
                new ItemAdditionalInfo { ID = 29, ItemId=27, Quantity=100, UnitId=4, Calories=132, Protein=8.86, CarbonHidrates=23.71, Fats=0.54, Fibers=8.7 },
                new ItemAdditionalInfo { ID = 30, ItemId=28, Quantity=100, UnitId=4, Calories=139, Protein=9.73, CarbonHidrates=25.09, Fats=0.35, Fibers=6.3 },
                new ItemAdditionalInfo { ID = 31, ItemId=29, Quantity=100, UnitId=4, Calories=144, Protein=9.16, CarbonHidrates=25.27, Fats=1.08, Fibers=10.4 },
                new ItemAdditionalInfo { ID = 32, ItemId=30, Quantity=100, UnitId=4, Calories=164, Protein=8.86, CarbonHidrates=27.42, Fats=2.59, Fibers=7.6 },
                new ItemAdditionalInfo { ID = 33, ItemId=31, Quantity=100, UnitId=4, Calories=588, Protein=25.09, CarbonHidrates=19.56, Fats=50.39, Fibers=6 },
                new ItemAdditionalInfo { ID = 34, ItemId=32, Quantity=100, UnitId=4, Calories=218, Protein=5.7, CarbonHidrates=44.64, Fats=2.85, Fibers=6.3 },
                new ItemAdditionalInfo { ID = 35, ItemId=33, Quantity=100, UnitId=4, Calories=258, Protein=8.5, CarbonHidrates=48.3, Fats=3.3, Fibers=5.8 },
                new ItemAdditionalInfo { ID = 36, ItemId=34, Quantity=100, UnitId=4, Calories=111, Protein=2.58, CarbonHidrates=22.96, Fats=0.9, Fibers=1.8 },
                new ItemAdditionalInfo { ID = 37, ItemId=35, Quantity=100, UnitId=4, Calories=130, Protein=2.69, CarbonHidrates=28.17, Fats=0.28, Fibers=0.4 },
                new ItemAdditionalInfo { ID = 38, ItemId=36, Quantity=100, UnitId=4, Calories=124, Protein=5.33, CarbonHidrates=26.54, Fats=0.54, Fibers=2.8 },
                new ItemAdditionalInfo { ID = 39, ItemId=37, Quantity=100, UnitId=4, Calories=124, Protein=5.33, CarbonHidrates=26.54, Fats=0.54, Fibers=4.5 },
                new ItemAdditionalInfo { ID = 40, ItemId=38, Quantity=100 , UnitId=4 , Calories=365, Protein=24.8, CarbonHidrates=1.1, Fats=29, Fibers=0, Shop="Hofer" }
                //new ItemAdditionalInfo { ID = , ItemId=, Quantity= , UnitId= , Calories=, Protein=, CarbonHidrates=, Fats=, Fibers=0, Manufacturer= "" }
            };

            itemAdditionalInfo.ForEach(iai => context.ItemAdditionalInfo.AddOrUpdate(iai));
            context.SaveChanges();

            // Set default meals
            var meals = new List<Meal>
            {
                new Meal { ID=1, UserID=1, Title="Omleta" },
                new Meal { ID=2, UserID=1, Title="Ovseni kosmièi z borovnicami in banano"},
                new Meal { ID=3, UserID=1, Title="Špageti bolognese"},
                new Meal { ID=4, UserID=1, Title="Tortilije s pišèanèjim mesom"},
                new Meal { ID=5, UserID=1, Title="Rižota s pišèanèjim mesom"},
                new Meal { ID=6, UserID=1, Title="Toast, pišèanèje prsi, skutin namaz"},
                new Meal { ID=7, UserID=1, Title="Orešèki, pest"},
                new Meal { ID=8, UserID=1, Title="Grški jogurt, jabolka, cimet in orešèki"},
                new Meal { ID=9, UserID=1, Title="Èokolino fitness in whey"},
                new Meal { ID=10, UserID=1, Title="Makaroni s pišèanèjim mesom"},
                new Meal { ID=11, UserID=1, Title="Pišèanèji ragu z grahom", ImagePath="~/Content/Images/Meals/11.png"}
            };

            meals.ForEach(m => context.Meal.AddOrUpdate(m));
            context.SaveChanges();

            // Set default meal items
            var mealItems = new List<MealItem>
            {                
                new MealItem { ID=1, MealId=2, ItemId=1, UnitId=4, Quantity=200 },
                new MealItem { ID=2, MealId=2, ItemId=3, UnitId=4, Quantity=30 },
                new MealItem { ID=3, MealId=2, ItemId=10, UnitId=4, Quantity=50 },
                new MealItem { ID=4, MealId=1, ItemId=4, UnitId=7, Quantity=2 },
                new MealItem { ID=5, MealId=1, ItemId=5, UnitId=7, Quantity=4 },
                new MealItem { ID=6, MealId=1, ItemId=38, UnitId=4, Quantity=10 },
                new MealItem { ID=7, MealId=10, ItemId=11, UnitId=4, Quantity=400 },
                new MealItem { ID=8, MealId=10, ItemId=36, UnitId=4, Quantity=200 },
                new MealItem { ID=9, MealId=10, ItemId=39, UnitId=7, Quantity=1 },
                new MealItem { ID=10, MealId=10, ItemId=40, UnitId=7, Quantity=1 },
                new MealItem { ID=11, MealId=10, ItemId=42, UnitId=7, Quantity=1 },
                new MealItem { ID=12, MealId=10, ItemId=44, UnitId=1, Quantity=200 },
                new MealItem { ID=13, MealId=10, ItemId=45 },
                new MealItem { ID=14, MealId=10, ItemId=46 },
                new MealItem { ID=15, MealId=10, ItemId=47 },
                new MealItem { ID=16, MealId=10, ItemId=48 },
                new MealItem { ID=17, MealId=10, ItemId=49 },
                new MealItem { ID=18, MealId=10, ItemId=50 },
                new MealItem { ID=19, MealId=10, ItemId=51 },
                new MealItem { ID=20, MealId=11, ItemId=11, UnitId=4, Quantity=400 },
                new MealItem { ID=20, MealId=11, ItemId=52, UnitId=7, Quantity=1 },       
                new MealItem { ID=20, MealId=11, ItemId=55, UnitId=7, Quantity=1},       
                new MealItem { ID=20, MealId=11, ItemId=17, UnitId=4, Quantity=200 },
                new MealItem { ID=20, MealId=11, ItemId=53, UnitId=1, Quantity=100 },
                new MealItem { ID=20, MealId=11, ItemId=54, UnitId=8, Quantity=2 },
                new MealItem { ID=20, MealId=11, ItemId=39, UnitId=4, Quantity=60 },
                new MealItem { ID=20, MealId=11, ItemId=49 },                                          
                //new MealItem { ID=, MealId=, ItemId=, UnitId=, Quantity= }
            };

            mealItems.ForEach(mi => context.MealItem.AddOrUpdate(mi));
            context.SaveChanges();

            var mealPreparation = new List<MealPreparation>
            {
                new MealPreparation { ID=10, Preparation="Pišèanèje fileje narežemo na kocke in jih na vroèem olju popražimo. Dodamo sol, poper, malo vegete, lovorov list in timijan. Meso shranimo na toplem. Na istem olju prepražimo èebulo in èesen ter dodamo na kocke narezano rdeèo papriko, ponovno malo posolimo. Meso vrnemo v ponev k ostalim sestavinam in pražimo, dokler paprika ni mehka. Nato dodamo paradižnikovo omako ter origano in baziliko (ostale zaèimbe po potrebi) in kuhamo na zmernem ognju še 15 minut. Vmes skuhamo makarone, po navodilih iz embalaže, oziroma po okusu."},
                new MealPreparation { ID=11, Preparation="Na vroèem olju prepražimo sesekljano èebulo. Pišèanèje prsi narežemo na kocke. Gobe oèistimo in narežemo na primerne manjše kose. Meso in gobe dodamo k èebuli ter zaèinimo s Knorr kokošjo kocko in pražimo 2-3 minuti. Dodamo grah.Knorr Fix mešanico zmešamo z 2 dl vode in smetano. Dodamo k raguju in kuhamo 10 minut. Dodamo sveže narezano baziliko in poper po okusu."}
            };

            mealPreparation.ForEach(mp => context.MealPreparation.AddOrUpdate(mp));
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
                new Planer { ID=1, PlanedOn= new DateTime(2016, 1, 4) },
                new Planer { ID=2, PlanedOn= new DateTime(2016, 1, 5) },
                new Planer { ID=3, PlanedOn= new DateTime(2016, 1, 6) },
                new Planer { ID=4, PlanedOn= new DateTime(2016, 1, 7) },
                new Planer { ID=5, PlanedOn= new DateTime(2016, 1, 8) },
                new Planer { ID=6, PlanedOn= new DateTime(2016, 1, 9) },
                new Planer { ID=7, PlanedOn= new DateTime(2016, 1, 10) },
                new Planer { ID=8, PlanedOn= new DateTime(2016, 1, 11) }
            };

            planer.ForEach(p => context.Planer.AddOrUpdate(p));
            context.SaveChanges();

            var planerMeals = new List<PlanerMeals>
            {
                new PlanerMeals { PlanerMealsId=1, PlanerId=1, MealId=1, CourseId=1 },    
                new PlanerMeals { PlanerMealsId=2, PlanerId=1, MealId=2, CourseId=1 },                
                new PlanerMeals { PlanerMealsId=3, PlanerId=1, MealId=5, CourseId=3 },
                new PlanerMeals { PlanerMealsId=4, PlanerId=1, MealId=6, CourseId=4 },
                new PlanerMeals { PlanerMealsId=5, PlanerId=1, MealId=9, CourseId=6 },
                new PlanerMeals { PlanerMealsId=6, PlanerId=1, MealId=5, CourseId=7 },
                new PlanerMeals { PlanerMealsId=7, PlanerId=2, MealId=1, CourseId=1 },    
                new PlanerMeals { PlanerMealsId=8, PlanerId=2, MealId=2, CourseId=1 },                
                new PlanerMeals { PlanerMealsId=9, PlanerId=2, MealId=3, CourseId=3 },
                new PlanerMeals { PlanerMealsId=10, PlanerId=2, MealId=6, CourseId=4 },
                new PlanerMeals { PlanerMealsId=11, PlanerId=2, MealId=9, CourseId=6 },
                new PlanerMeals { PlanerMealsId=12, PlanerId=2, MealId=3, CourseId=7 },
                new PlanerMeals { PlanerMealsId=13, PlanerId=3, MealId=1, CourseId=1 },    
                new PlanerMeals { PlanerMealsId=14, PlanerId=3, MealId=2, CourseId=1 },                
                new PlanerMeals { PlanerMealsId=15, PlanerId=3, MealId=11, CourseId=3 }             
                
            };

            planerMeals.ForEach(pm => context.PlanerMeals.AddOrUpdate(pm));
            context.SaveChanges();
        }
    }
}
