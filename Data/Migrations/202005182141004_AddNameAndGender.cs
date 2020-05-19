namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameAndGender : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Username", c => c.String(nullable: false));
            AddColumn("dbo.Users", "Name", c => c.String());
            AddColumn("dbo.Users", "Gender", c => c.String());
            DropColumn("dbo.Users", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Email", c => c.String(nullable: false));
            DropColumn("dbo.Users", "Gender");
            DropColumn("dbo.Users", "Name");
            DropColumn("dbo.Users", "Username");
        }
    }
}
