namespace DogeDaycare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddmoreinformationtoPerson : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Persons", "FName", c => c.String());
            AddColumn("dbo.Persons", "NickName", c => c.String());
            AddColumn("dbo.Persons", "LName", c => c.String());
            AddColumn("dbo.Persons", "Email", c => c.String());
            AddColumn("dbo.Persons", "Phone", c => c.String());
            DropColumn("dbo.Persons", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Persons", "Name", c => c.String());
            DropColumn("dbo.Persons", "Phone");
            DropColumn("dbo.Persons", "Email");
            DropColumn("dbo.Persons", "LName");
            DropColumn("dbo.Persons", "NickName");
            DropColumn("dbo.Persons", "FName");
        }
    }
}
