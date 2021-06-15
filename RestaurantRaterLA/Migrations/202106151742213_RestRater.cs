namespace RestaurantRaterLA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestRater : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Restaurants", "Owners");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Restaurants", "Owners", c => c.String());
        }
    }
}
