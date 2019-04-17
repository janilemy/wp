using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using WeeklyPlaner.Models;

namespace WeeklyPlaner.Migrations
{
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
                new Course { ID = 7, Title="Večerja" },
            };

            courses.ForEach(c => context.Course.AddOrUpdate(c));
            context.SaveChanges();

            var unitTypes = new List<UnitType>
            {
                new UnitType { ID = 1, Title="Tekočine enote"},
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
                new ItemCategory { ID = 5, Category="Mlečni izdelki" },
                new ItemCategory { ID = 6, Category="Olja in maščobe" },
                new ItemCategory { ID = 7, Category="Testenine in kosmiči" },
                new ItemCategory { ID = 8, Category="Kruh in krušni izdelki" },
                new ItemCategory { ID = 9, Category="Riž" },
                new ItemCategory { ID = 10, Category="Oreščki" },
                new ItemCategory { ID = 11, Category="Začimbe in zelišča" },
                new ItemCategory { ID = 12, Category="Pijače" },
                new ItemCategory { ID = 13, Category="Namazi" },
                new ItemCategory { ID = 14, Category="čistila" }
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
                new Item { ID = 10, ItemCategoryId=8, Name="Ovseni kosmiči"},
                new Item { ID = 11, ItemCategoryId=3, Name="Piščanec, prsa"},
                new Item { ID = 12, ItemCategoryId=3, Name="Puran, prsa"},
                new Item { ID = 13, ItemCategoryId=3, Name="Govedina, mleta"},
                new Item { ID = 14, ItemCategoryId=2, Name="Brokoli"},
                new Item { ID = 15, ItemCategoryId=2, Name="Cvetača"},
                new Item { ID = 16, ItemCategoryId=2, Name="Kumara"},
                new Item { ID = 17, ItemCategoryId=2, Name="Grah"},
                new Item { ID = 18, ItemCategoryId=2, Name="Krompir"},
                new Item { ID = 19, ItemCategoryId=2, Name="Špinača"},
                new Item { ID = 20, ItemCategoryId=2, Name="Bučka"},
                new Item { ID = 21, ItemCategoryId=2, Name="Korenje"},
                new Item { ID = 22, ItemCategoryId=10, Name="Mandlji"},
                new Item { ID = 23, ItemCategoryId=10, Name="Lešniki"},
                new Item { ID = 24, ItemCategoryId=10, Name="Makadamija"},
                new Item { ID = 25, ItemCategoryId=10, Name="Pistacija"},
                new Item { ID = 26, ItemCategoryId=10, Name="Arašidi"},
                new Item { ID = 27, ItemCategoryId=2, Name="Fižol, črni"},
                new Item { ID = 28, ItemCategoryId=2, Name="Fižol, beli"},
                new Item { ID = 29, ItemCategoryId=2, Name="Fižol, rumeni"},
                new Item { ID = 30, ItemCategoryId=2, Name="čičerika"},
                new Item { ID = 31, ItemCategoryId=2, Name="Arašidovo maslo", Manufacturer="Roks"},
                new Item { ID = 32, ItemCategoryId=7, Name="Tortilije, koruzne"},
                new Item { ID = 33, ItemCategoryId=7, Name="Kruh, rženi"},
                new Item { ID = 34, ItemCategoryId=9, Name="Riž, rjav"},
                new Item { ID = 35, ItemCategoryId=9, Name="Riž, beli"},
                new Item { ID = 36, ItemCategoryId=7, Name="Makaroni, polnozrnati"},
                new Item { ID = 37, ItemCategoryId=7, Name="Špageti, polnozrnati"},
                new Item { ID = 38, ItemCategoryId=4, Name="Slanina, prekajena" },
                new Item { ID = 39, ItemCategoryId=2, Name="čebula"},
                new Item { ID = 40, ItemCategoryId=2, Name="česen"},
                new Item { ID = 41, ItemCategoryId=2, Name="Paprika, zelena"},
                new Item { ID = 42, ItemCategoryId=2, Name="Paprika, rdeča"},
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
                new Item { ID = 55, ItemCategoryId=2, Name="Mešanica za gobovo omako, Knorr Fix"},
                new Item { ID = 56, ItemCategoryId=3, Name="Govedina, zrezki"},
                new Item { ID = 57, ItemCategoryId=2, Name="Grah, korenje"}
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
                new ItemAdditionalInfo { ID = 40, ItemId=38, Quantity=100 , UnitId=4 , Calories=365, Protein=24.8, CarbonHidrates=1.1, Fats=29, Fibers=0, Shop="Hofer" },
                new ItemAdditionalInfo { ID = 41, ItemId=55, Quantity=100, UnitId=4, Calories=110, Protein=23.09, CarbonHidrates=0, Fats=1.24, Fibers=0, Shop="Hofer" },
                new ItemAdditionalInfo { ID = 42, ItemId=56, Quantity=100, UnitId=4, Calories=42, Protein=3, CarbonHidrates=5, Fats=1, Fibers=4, Shop="Hofer" }
                //new ItemAdditionalInfo { ID = , ItemId=, Quantity= , UnitId= , Calories=, Protein=, CarbonHidrates=, Fats=, Fibers=0, Manufacturer= "" }
            };

            itemAdditionalInfo.ForEach(iai => context.ItemAdditionalInfo.AddOrUpdate(iai));
            context.SaveChanges();

            // Set default meals
            var meals = new List<Meal>
            {
                new Meal { ID=1, UserID=1, Title="Omleta", ImagePath="~/Content/Images/Meals/1.jpg" },
                new Meal { ID=2, UserID=1, Title="Ovseni kosmiči z borovnicami in banano", ImagePath="~/Content/Images/Meals/2.jpg"},
                new Meal { ID=3, UserID=1, Title="Špageti bolognese", ImagePath="~/Content/Images/Meals/3.jpg"},
                new Meal { ID=4, UserID=1, Title="Tortilije s piščančjim mesom", ImagePath="~/Content/Images/Meals/4.jpg"},
                new Meal { ID=5, UserID=1, Title="Rižota s piščančjim mesom"},
                new Meal { ID=6, UserID=1, Title="Toast, piščančje prsi, skutin namaz", ImagePath="~/Content/Images/Meals/6.jpg"},
                new Meal { ID=7, UserID=1, Title="Oreščki, pest"},
                new Meal { ID=8, UserID=1, Title="Grški jogurt, jabolka, cimet in oreščki"},
                new Meal { ID=9, UserID=1, Title="čokolino fitness in whey", ImagePath="~/Content/Images/Meals/9.jpg"},
                new Meal { ID=10, UserID=1, Title="Makaroni s piščančjim mesom", ImagePath="~/Content/Images/Meals/10.jpg"},
                new Meal { ID=11, UserID=1, Title="Piščančji ragu z grahom", ImagePath="~/Content/Images/Meals/11.jpg"},

                // Sestavine še niso dodeljene
                new Meal { ID=12, UserID=1, Title="Piščančje prsi v curry omaki", ImagePath="~/Content/Images/Meals/12.jpg"},
                new Meal { ID=13, UserID=1, Title="Piščančje prsi v nacho omaki", ImagePath="~/Content/Images/Meals/13.jpg"},
                new Meal { ID=14, UserID=1, Title="Piščančje prsi v naravni omaki", ImagePath="~/Content/Images/Meals/14.jpg"},
                new Meal { ID=15, UserID=1, Title="Piščančje prsi v sirovi omaki", ImagePath="~/Content/Images/Meals/15.jpg"},
                new Meal { ID=16, UserID=1, Title="Sendvič z piščančjo posebno in sirom", ImagePath="~/Content/Images/Meals/16.jpg"}
                //new Meal { ID=, UserID=1, Title="", ImagePath="~/Content/Images/Meals/12.jpg"}
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
                new MealPreparation { ID=10, Preparation="Piščančje fileje narežemo na kocke in jih na vročem olju popražimo. Dodamo sol, poper, malo vegete, lovorov list in timijan. Meso shranimo na toplem. Na istem olju prepražimo čebulo in česen ter dodamo na kocke narezano rdečo papriko, ponovno malo posolimo. Meso vrnemo v ponev k ostalim sestavinam in pražimo, dokler paprika ni mehka. Nato dodamo paradižnikovo omako ter origano in baziliko (ostale začimbe po potrebi) in kuhamo na zmernem ognju še 15 minut. Vmes skuhamo makarone, po navodilih iz embalaže, oziroma po okusu."},
                new MealPreparation { ID=11, Preparation="Na vročem olju prepražimo sesekljano čebulo. Piščančje prsi narežemo na kocke. Gobe očistimo in narežemo na primerne manjše kose. Meso in gobe dodamo k čebuli ter začinimo s Knorr kokošjo kocko in pražimo 2-3 minuti. Dodamo grah.Knorr Fix mešanico zmešamo z 2 dl vode in smetano. Dodamo k raguju in kuhamo 10 minut. Dodamo sveže narezano baziliko in poper po okusu."},
                new MealPreparation { ID=12, Preparation="Pripravimo si piščančje prsi narezane na kocke, smetano za kuhanje, curry začimbo, poper, začimbo za piščančje meso. V posodo damo malo olja in popečemo meso, ki ga začinimo z začimbo za meso in poprom. Ko je meso pečeno ga zalijemo z malo vode, ki jo začinimo z curry začimbo in pustimo še pustimo nekaj minut vret. Nato po potrebi še dodamo vodo, ali pa kar dodamo smetano za kuhanje in še po potrebi začinimo z curryjem in poprom. Ko se omaka malo zgosti je jed gotova."},
                new MealPreparation { ID=13, Preparation="Pripravimo si piščančje prsi narezane na kocke, smetano za kuhanje, nacho sir, poper, začimbo za piščančje meso. V posodo damo malo olja in popečemo meso, ki ga začinimo z začimbo za meso in poprom. Ko je meso pečeno ga zalijemo z malo vode in pustimo še pustimo nekaj minut vret. Nato po potrebi še dodamo vodo, ali pa kar dodamo smetano za kuhanje, nacho sir in poper. Omako še nekaj minut mešamo, ko se omaka zgosti je jed gotova."}
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
                new Planer { ID=8, PlanedOn= new DateTime(2016, 1, 11) },
                new Planer { ID=9, PlanedOn= new DateTime(2016, 1, 18) }
            };

            planer.ForEach(p => context.Planer.AddOrUpdate(p));
            context.SaveChanges();

            var planerMeals = new List<PlanerMeals>
            {
                new PlanerMeals { PlanerMealsId=1, PlanerId=1, MealId=1, CourseId=1 },
                new PlanerMeals { PlanerMealsId=2, PlanerId=1, MealId=2, CourseId=1 },
                new PlanerMeals { PlanerMealsId=3, PlanerId=1, MealId=10, CourseId=3 },
                new PlanerMeals { PlanerMealsId=4, PlanerId=1, MealId=6, CourseId=4 },
                //new PlanerMeals { PlanerMealsId=5, PlanerId=1, MealId=9, CourseId=6 },
                new PlanerMeals { PlanerMealsId=5, PlanerId=1, MealId=10, CourseId=7 },
                new PlanerMeals { PlanerMealsId=6, PlanerId=2, MealId=1, CourseId=1 },
                new PlanerMeals { PlanerMealsId=7, PlanerId=2, MealId=2, CourseId=1 },
                new PlanerMeals { PlanerMealsId=8, PlanerId=2, MealId=3, CourseId=3 },
                new PlanerMeals { PlanerMealsId=9, PlanerId=2, MealId=6, CourseId=4 },
                //new PlanerMeals { PlanerMealsId=11, PlanerId=2, MealId=9, CourseId=6 },
                new PlanerMeals { PlanerMealsId=10, PlanerId=2, MealId=3, CourseId=7 },
                new PlanerMeals { PlanerMealsId=11, PlanerId=3, MealId=1, CourseId=1 },
                new PlanerMeals { PlanerMealsId=12, PlanerId=3, MealId=2, CourseId=1 },
                new PlanerMeals { PlanerMealsId=13, PlanerId=3, MealId=11, CourseId=3 },
                new PlanerMeals { PlanerMealsId=14, PlanerId=3, MealId=11, CourseId=5 },
                new PlanerMeals { PlanerMealsId=15, PlanerId=3, MealId=6, CourseId=7 },
                new PlanerMeals { PlanerMealsId=16, PlanerId=4, MealId=1, CourseId=1 },
                new PlanerMeals { PlanerMealsId=16, PlanerId=4, MealId=16, CourseId=3 },
                new PlanerMeals { PlanerMealsId=16, PlanerId=4, MealId=12, CourseId=4 }

            };

            planerMeals.ForEach(pm => context.PlanerMeals.AddOrUpdate(pm));
            context.SaveChanges();

            List<ShoppingListItem> firstShoppingListItems = new List<ShoppingListItem>();
            firstShoppingListItems.Add(new ShoppingListItem { ID = 1, ShoppingListId = 1, ItemId = 1, Quantity = 200, UnitId = 4 });

            List<ShoppingListItem> secondShoppingListItems = new List<ShoppingListItem>();
            firstShoppingListItems.Add(new ShoppingListItem { ID = 1, ShoppingListId = 2, ItemId = 3, Quantity = 125, UnitId = 4 });
            firstShoppingListItems.Add(new ShoppingListItem { ID = 2, ShoppingListId = 2, ItemId = 4, Quantity = 12, UnitId = 7 });
            firstShoppingListItems.Add(new ShoppingListItem { ID = 3, ShoppingListId = 2, ItemId = 55, Quantity = 500, UnitId = 4 });
            firstShoppingListItems.Add(new ShoppingListItem { ID = 4, ShoppingListId = 2, ItemId = 56, Quantity = 500, UnitId = 4 });
            firstShoppingListItems.Add(new ShoppingListItem { ID = 5, ShoppingListId = 2, ItemId = 38, Quantity = 300, UnitId = 4 });

            var shoppingLists = new List<ShoppingList>
            {
                new ShoppingList { ID=1, Timestamp=DateTime.Now.AddDays(-6), ShoppingListItems = firstShoppingListItems },
                new ShoppingList { ID=2, Timestamp=DateTime.Now, ShoppingListItems = secondShoppingListItems }
            };

            shoppingLists.ForEach(sl => context.ShoppingLists.AddOrUpdate(sl));
            context.SaveChanges();
        }
    }
}
