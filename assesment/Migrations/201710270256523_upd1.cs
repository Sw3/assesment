namespace assesment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upd1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Customer_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customer", t => t.Customer_ID)
                .Index(t => t.Customer_ID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        productNumber = c.Int(nullable: false),
                        title = c.String(),
                        price = c.Double(nullable: false),
                        category_ID = c.Int(),
                        Product_ID = c.Int(),
                        Order_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProductCategory", t => t.category_ID)
                .ForeignKey("dbo.Product", t => t.Product_ID)
                .ForeignKey("dbo.Order", t => t.Order_ID)
                .Index(t => t.category_ID)
                .Index(t => t.Product_ID)
                .Index(t => t.Order_ID);
            
            CreateTable(
                "dbo.ProductCategory",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        ProductCategory_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProductCategory", t => t.ProductCategory_ID)
                .Index(t => t.ProductCategory_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Order", "Customer_ID", "dbo.Customer");
            DropForeignKey("dbo.Product", "Order_ID", "dbo.Order");
            DropForeignKey("dbo.Product", "Product_ID", "dbo.Product");
            DropForeignKey("dbo.Product", "category_ID", "dbo.ProductCategory");
            DropForeignKey("dbo.ProductCategory", "ProductCategory_ID", "dbo.ProductCategory");
            DropIndex("dbo.ProductCategory", new[] { "ProductCategory_ID" });
            DropIndex("dbo.Product", new[] { "Order_ID" });
            DropIndex("dbo.Product", new[] { "Product_ID" });
            DropIndex("dbo.Product", new[] { "category_ID" });
            DropIndex("dbo.Order", new[] { "Customer_ID" });
            DropTable("dbo.ProductCategory");
            DropTable("dbo.Product");
            DropTable("dbo.Order");
            DropTable("dbo.Customer");
        }
    }
}
