namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropCooking : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Cooking");
            DropTable("dbo.Cookings");
        }
        
        public override void Down()
        {
        }
    }
}
