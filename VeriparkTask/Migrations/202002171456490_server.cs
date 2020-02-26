namespace VeriparkTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class server : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Countries", "CurrencyCode", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Countries", "CurrencyCode");
        }
    }
}
