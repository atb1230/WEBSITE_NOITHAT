namespace demo_02.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateImages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "Picture1", c => c.String(nullable: false));
            AddColumn("dbo.Products", "Picture2", c => c.String(nullable: false));
            AddColumn("dbo.Products", "Picture3", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Picture3");
            DropColumn("dbo.Products", "Picture2");
            DropColumn("dbo.Products", "Picture1");
            DropColumn("dbo.Products", "Price");
        }
    }
}
