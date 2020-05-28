namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCooking2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
               "dbo.Cooking",
               c => new
               {
                   Id = c.Int(nullable: false, identity: true),
                   Comment = c.String(nullable: false),
                   Likes = c.Int(),
                   ArticleId = c.Int(nullable: false),
               })
               .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.Cooking");
        }
    }
}
