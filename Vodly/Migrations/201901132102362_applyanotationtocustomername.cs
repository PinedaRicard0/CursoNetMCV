namespace Vodly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class applyanotationtocustomername : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String());
        }
    }
}
