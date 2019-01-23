namespace Vodly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removingSomePropertiesFromGenre : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Genres", "ReleaseDate");
            DropColumn("dbo.Genres", "DateAdded");
            DropColumn("dbo.Genres", "StockQuantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Genres", "StockQuantity", c => c.Int(nullable: false));
            AddColumn("dbo.Genres", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Genres", "ReleaseDate", c => c.DateTime(nullable: false));
        }
    }
}
