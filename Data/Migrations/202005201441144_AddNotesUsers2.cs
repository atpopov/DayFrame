namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNotesUsers2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Notes", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Notes", "UserId");
            AddForeignKey("dbo.Notes", "UserId", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notes", "UserId", "dbo.Users");
            DropIndex("dbo.Notes", new[] { "UserId" });
            AlterColumn("dbo.Notes", "UserId", c => c.Int());
        }
    }
}
