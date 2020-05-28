namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCook : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cook",
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
            DropTable("dbo.Cook");
        }
    }
}
