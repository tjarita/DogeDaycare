namespace DogeDaycare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeEmailBodyReplacementKeytoIdentifier : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmailBodyReplacements", "Identifier", c => c.String(nullable: false));
            DropColumn("dbo.EmailBodyReplacements", "Key");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmailBodyReplacements", "Key", c => c.String(nullable: false));
            DropColumn("dbo.EmailBodyReplacements", "Identifier");
        }
    }
}
