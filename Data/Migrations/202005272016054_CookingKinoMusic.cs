namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CookingKinoMusic : DbMigration
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
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Kino",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Comment = c.String(nullable: false),
                    Likes = c.Int(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Music",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Comment = c.String(nullable: false),
                    Likes = c.Int(),
                })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.Cooking");
            DropTable("dbo.Music");
            DropTable("dbo.Kino");
        }
    }
}
