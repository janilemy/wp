namespace WeeklyPlaner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeparateMealPreparation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MealPreparation",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        ActivePreparationTime = c.Int(),
                        PasivePreparationTime = c.Int(),
                        Preparation = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Meal", t => t.ID)
                .Index(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MealPreparation", "ID", "dbo.Meal");
            DropIndex("dbo.MealPreparation", new[] { "ID" });
            DropTable("dbo.MealPreparation");
        }
    }
}
