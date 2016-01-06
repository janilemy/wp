namespace WeeklyPlaner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMealPreparation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meal", "Preparation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Meal", "Preparation");
        }
    }
}
