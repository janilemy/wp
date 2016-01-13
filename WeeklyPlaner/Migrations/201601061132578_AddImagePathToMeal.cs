namespace WeeklyPlaner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImagePathToMeal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meal", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Meal", "ImagePath");
        }
    }
}