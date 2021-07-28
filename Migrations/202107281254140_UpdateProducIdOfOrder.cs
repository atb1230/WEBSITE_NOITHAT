namespace demo_02.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProducIdOfOrder : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderDetails", "ProductId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderDetails", "ProductId", c => c.Int(nullable: false));
        }
    }
}
