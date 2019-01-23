namespace Vodly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedingGenre : DbMigration
    {
        public override void Up()
        {
            Sql("Insert INTO Genres (Name) VALUES ('Comedy')");
            Sql("Insert INTO Genres (Name) VALUES ('Drama')");
            Sql("Insert INTO Genres (Name) VALUES ('Terror')");
        }
        
        public override void Down()
        {
        }
    }
}
