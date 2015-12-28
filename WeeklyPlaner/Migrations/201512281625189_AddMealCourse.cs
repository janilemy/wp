namespace WeeklyPlaner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMealCourse : DbMigration
    {
        public override void Up()
        {
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
            DropForeignKey("dbo.MealCourse", "Course_ID", "dbo.Course");
            DropForeignKey("dbo.MealCourse", "Meal_ID", "dbo.Meal");
            DropIndex("dbo.MealCourse", new[] { "Course_ID" });
            DropIndex("dbo.MealCourse", new[] { "Meal_ID" });
            DropTable("dbo.MealCourse");
        }
    }
}
