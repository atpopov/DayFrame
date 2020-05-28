namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddArticleId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cooking", "ArticleId", c => c.Int(nullable: false));
            AddColumn("dbo.Kino", "ArticleId", c => c.Int(nullable: false));
            AddColumn("dbo.Music", "ArticleId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cooking", "ArticleId");
            DropColumn("dbo.Kino", "ArticleId");
            DropColumn("dbo.Music", "ArticleId");
        }
    }
}
