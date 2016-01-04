namespace WeeklyPlaner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddManufacturerForItems : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ItemAdditionalInfo", "Manufacturer", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ItemAdditionalInfo", "Manufacturer");
        }
    }
}
