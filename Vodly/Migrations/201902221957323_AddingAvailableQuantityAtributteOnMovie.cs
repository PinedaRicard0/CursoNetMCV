namespace Vodly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAvailableQuantityAtributteOnMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "AvailableQuantity", c => c.Int(nullable: false));

            Sql("UPDATE Movies SET AvailableQuantity = StockQuantity");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "AvailableQuantity");
        }
    }
}
