namespace iCategory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial51 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Name", c => c.Int(nullable: false));
        }
    }
}
