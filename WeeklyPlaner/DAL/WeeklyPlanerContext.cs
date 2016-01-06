using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using WeeklyPlaner.Models;

namespace WeeklyPlaner.DAL
{
    public class WeeklyPlanerContext : DbContext
    {
        public WeeklyPlanerContext() : base("WeeklyPlanerContext")
        { }

        public DbSet<Item> Item { get; set; }        
        public DbSet<ItemCategory> ItemCategory { get; set; }
        public DbSet<ItemAdditionalInfo> ItemAdditionalInfo { get; set; }
        public DbSet<FavouriteItem> FavouriteItem { get; set; }
        public DbSet<Unit> Unit { get; set; }
        public DbSet<UnitType> UnitType { get; set; }
        public DbSet<Meal> Meal { get; set; }        
        public DbSet<MealItem> MealItem { get; set; }
        public DbSet<MealPreparation> MealPreparation { get; set; }
        public DbSet<MealAdditionalInfo> MealAdditionalInfo { get; set; }        
        public DbSet<Planer> Planer { get; set; }
        public DbSet<PlanerMeals> PlanerMeals { get; set; }
        public DbSet<Course> Course { get; set; }                            

        //public DbSet<Advanced> Advanced { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // FOR SINGULAR TABLE NAME USE SUCH AS Item, Meal (insetead of Items, Meals)
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // CONFIGURE MODEL WITH FLUENT API
        }
    }
}