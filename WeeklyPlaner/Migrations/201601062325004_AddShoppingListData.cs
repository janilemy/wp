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
                        Item_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Item", t => t.Item_ID)
                .Index(t => t.Item_ID);
            
            CreateTable(
                "dbo.ShoppingListItem",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ShoppingListId = c.Int(nullable: false),
                        UnitId = c.Int(),
                        ItemId = c.Int(nullable: false),
                        Quantity = c.Double(),
                        Shop = c.String(),
                        Price = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Item", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.ShoppingList", t => t.ShoppingListId, cascadeDelete: true)
                .ForeignKey("dbo.Unit", t => t.UnitId)
                .Index(t => t.ShoppingListId)
                .Index(t => t.UnitId)
                .Index(t => t.ItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingList", "Item_ID", "dbo.Item");
            DropForeignKey("dbo.ShoppingListItem", "UnitId", "dbo.Unit");
            DropForeignKey("dbo.ShoppingListItem", "ShoppingListId", "dbo.ShoppingList");
            DropForeignKey("dbo.ShoppingListItem", "ItemId", "dbo.Item");
            DropIndex("dbo.ShoppingListItem", new[] { "ItemId" });
            DropIndex("dbo.ShoppingListItem", new[] { "UnitId" });
            DropIndex("dbo.ShoppingListItem", new[] { "ShoppingListId" });
            DropIndex("dbo.ShoppingList", new[] { "Item_ID" });
            DropTable("dbo.ShoppingListItem");
            DropTable("dbo.ShoppingList");
        }
    }
}
