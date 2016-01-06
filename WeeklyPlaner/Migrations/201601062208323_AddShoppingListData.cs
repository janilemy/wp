namespace WeeklyPlaner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShoppingListData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShoppingList",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Timestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Item", "ShoppingList_ID", c => c.Int());
            CreateIndex("dbo.Item", "ShoppingList_ID");
            AddForeignKey("dbo.Item", "ShoppingList_ID", "dbo.ShoppingList", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Item", "ShoppingList_ID", "dbo.ShoppingList");
            DropIndex("dbo.Item", new[] { "ShoppingList_ID" });
            DropColumn("dbo.Item", "ShoppingList_ID");
            DropTable("dbo.ShoppingList");
        }
    }
}
