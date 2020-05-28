namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCooking : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Cooking");
        }
        
        public override void Down()
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
    }
}
