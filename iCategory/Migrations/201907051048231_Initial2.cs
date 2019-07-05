namespace iCategory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "CategoryName", c => c.String());
            AddColumn("dbo.Categories", "UserName", c => c.String());
            AddColumn("dbo.Products", "UserName", c => c.String());
            DropColumn("dbo.Categories", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Name", c => c.String());
            DropColumn("dbo.Products", "UserName");
            DropColumn("dbo.Categories", "UserName");
            DropColumn("dbo.Categories", "CategoryName");
        }
    }
}
