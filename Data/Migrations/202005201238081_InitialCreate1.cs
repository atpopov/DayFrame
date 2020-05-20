namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Note = c.String(nullable: false),
                    IsChecked = c.Boolean(),
                })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.Notes");
        }
    }
}
