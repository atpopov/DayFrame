namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNotesUsers1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notes", "UserId", c => c.Int());

            Sql(@"UPDATE dbo.Notes SET UserId = 1
              where User IS NULL");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notes", "UserId");
        }
    }
}
