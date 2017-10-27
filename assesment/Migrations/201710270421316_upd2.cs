namespace assesment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upd2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductCategory", "Product_ID", c => c.Int());
            CreateIndex("dbo.ProductCategory", "Product_ID");
            AddForeignKey("dbo.ProductCategory", "Product_ID", "dbo.Product", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductCategory", "Product_ID", "dbo.Product");
            DropIndex("dbo.ProductCategory", new[] { "Product_ID" });
            DropColumn("dbo.ProductCategory", "Product_ID");
        }
    }
}
