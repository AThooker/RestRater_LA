namespace RestaurantRaterLA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        RestaurantID = c.Int(nullable: false, identity: true),
                        Owners = c.String(),
                        Name = c.String(),
                        Address = c.String(),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RestaurantID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Restaurants");
        }
    }
}
