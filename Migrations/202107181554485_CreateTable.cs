namespace demo_02.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        IdProduct = c.String(nullable: false, maxLength: 255),
                        NameProduct = c.String(nullable: false, maxLength: 255),
                        Dimension = c.String(nullable: false, maxLength: 255),
                        Materials = c.String(nullable: false, maxLength: 255),
                        Color = c.String(nullable: false, maxLength: 255),
                        IdRoom = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdProduct)
                .ForeignKey("dbo.Rooms", t => t.IdRoom, cascadeDelete: true)
                .Index(t => t.IdRoom);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        IdRoom = c.Int(nullable: false, identity: true),
                        NameRoom = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.IdRoom);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "IdRoom", "dbo.Rooms");
            DropIndex("dbo.Products", new[] { "IdRoom" });
            DropTable("dbo.Rooms");
            DropTable("dbo.Products");
        }
    }
}
