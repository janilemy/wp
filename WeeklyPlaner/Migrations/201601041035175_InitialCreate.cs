namespace WeeklyPlaner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Meal",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MealAdditionalInfo",
                c => new
                    {
                        MealId = c.Int(nullable: false),
                        Protein = c.Double(),
                        CarbonHidrates = c.Double(),
                        Fats = c.Double(),
                        Fibers = c.Double(),
                        Calories = c.Int(),
                        Price = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.MealId)
                .ForeignKey("dbo.Meal", t => t.MealId)
                .Index(t => t.MealId);
            
            CreateTable(
                "dbo.MealItem",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MealId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        UnitId = c.Int(),
                        Quantity = c.Double(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Unit", t => t.UnitId)
                .ForeignKey("dbo.Item", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.Meal", t => t.MealId, cascadeDelete: true)
                .Index(t => t.MealId)
                .Index(t => t.ItemId)
                .Index(t => t.UnitId);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ItemCategoryId = c.Int(nullable: false),
                        Name = c.String(),
                        Manufacturer = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ItemCategory", t => t.ItemCategoryId, cascadeDelete: true)
                .Index(t => t.ItemCategoryId);
            
            CreateTable(
                "dbo.FavouriteItem",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Item", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.ItemAdditionalInfo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UnitId = c.Int(),
                        ItemId = c.Int(nullable: false),
                        Quantity = c.Double(),
                        Protein = c.Double(),
                        CarbonHidrates = c.Double(),
                        Fats = c.Double(),
                        Fibers = c.Double(),
                        Calories = c.Int(),
                        Shop = c.String(),
                        Price = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Item", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.Unit", t => t.UnitId)
                .Index(t => t.UnitId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.Unit",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UnitTypeId = c.Int(nullable: false),
                        Symbol = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UnitType", t => t.UnitTypeId, cascadeDelete: true)
                .Index(t => t.UnitTypeId);
            
            CreateTable(
                "dbo.UnitType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ItemCategory",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Planer",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PlanedOn = c.DateTime(nullable: false),
                        Meal_ID = c.Int(),
                        Course_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Meal", t => t.Meal_ID)
                .ForeignKey("dbo.Course", t => t.Course_ID)
                .Index(t => t.Meal_ID)
                .Index(t => t.Course_ID);
            
            CreateTable(
                "dbo.PlanerMeals",
                c => new
                    {
                        PlanerMealsId = c.Int(nullable: false, identity: true),
                        PlanerId = c.Int(nullable: false),
                        MealId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlanerMealsId)
                .ForeignKey("dbo.Course", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Meal", t => t.MealId, cascadeDelete: true)
                .ForeignKey("dbo.Planer", t => t.PlanerId, cascadeDelete: true)
                .Index(t => t.PlanerId)
                .Index(t => t.MealId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.MealCourse",
                c => new
                    {
                        Meal_ID = c.Int(nullable: false),
                        Course_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Meal_ID, t.Course_ID })
                .ForeignKey("dbo.Meal", t => t.Meal_ID, cascadeDelete: true)
                .ForeignKey("dbo.Course", t => t.Course_ID, cascadeDelete: true)
                .Index(t => t.Meal_ID)
                .Index(t => t.Course_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Planer", "Course_ID", "dbo.Course");
            DropForeignKey("dbo.Planer", "Meal_ID", "dbo.Meal");
            DropForeignKey("dbo.PlanerMeals", "PlanerId", "dbo.Planer");
            DropForeignKey("dbo.PlanerMeals", "MealId", "dbo.Meal");
            DropForeignKey("dbo.PlanerMeals", "CourseId", "dbo.Course");
            DropForeignKey("dbo.MealItem", "MealId", "dbo.Meal");
            DropForeignKey("dbo.MealItem", "ItemId", "dbo.Item");
            DropForeignKey("dbo.Item", "ItemCategoryId", "dbo.ItemCategory");
            DropForeignKey("dbo.Unit", "UnitTypeId", "dbo.UnitType");
            DropForeignKey("dbo.MealItem", "UnitId", "dbo.Unit");
            DropForeignKey("dbo.ItemAdditionalInfo", "UnitId", "dbo.Unit");
            DropForeignKey("dbo.ItemAdditionalInfo", "ItemId", "dbo.Item");
            DropForeignKey("dbo.FavouriteItem", "ItemId", "dbo.Item");
            DropForeignKey("dbo.MealAdditionalInfo", "MealId", "dbo.Meal");
            DropForeignKey("dbo.MealCourse", "Course_ID", "dbo.Course");
            DropForeignKey("dbo.MealCourse", "Meal_ID", "dbo.Meal");
            DropIndex("dbo.MealCourse", new[] { "Course_ID" });
            DropIndex("dbo.MealCourse", new[] { "Meal_ID" });
            DropIndex("dbo.PlanerMeals", new[] { "CourseId" });
            DropIndex("dbo.PlanerMeals", new[] { "MealId" });
            DropIndex("dbo.PlanerMeals", new[] { "PlanerId" });
            DropIndex("dbo.Planer", new[] { "Course_ID" });
            DropIndex("dbo.Planer", new[] { "Meal_ID" });
            DropIndex("dbo.Unit", new[] { "UnitTypeId" });
            DropIndex("dbo.ItemAdditionalInfo", new[] { "ItemId" });
            DropIndex("dbo.ItemAdditionalInfo", new[] { "UnitId" });
            DropIndex("dbo.FavouriteItem", new[] { "ItemId" });
            DropIndex("dbo.Item", new[] { "ItemCategoryId" });
            DropIndex("dbo.MealItem", new[] { "UnitId" });
            DropIndex("dbo.MealItem", new[] { "ItemId" });
            DropIndex("dbo.MealItem", new[] { "MealId" });
            DropIndex("dbo.MealAdditionalInfo", new[] { "MealId" });
            DropTable("dbo.MealCourse");
            DropTable("dbo.PlanerMeals");
            DropTable("dbo.Planer");
            DropTable("dbo.ItemCategory");
            DropTable("dbo.UnitType");
            DropTable("dbo.Unit");
            DropTable("dbo.ItemAdditionalInfo");
            DropTable("dbo.FavouriteItem");
            DropTable("dbo.Item");
            DropTable("dbo.MealItem");
            DropTable("dbo.MealAdditionalInfo");
            DropTable("dbo.Meal");
            DropTable("dbo.Course");
        }
    }
}
