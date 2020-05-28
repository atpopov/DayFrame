namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCooking : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cooking",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Comment = c.String(nullable: false),
                    Like = c.Int(),
                    ArticleId = c.Int(),
                })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.Cooking");
        }
    }
}
