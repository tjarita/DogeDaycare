namespace DogeDaycare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmailTemplates : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmailTemplates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sender = c.String(nullable: false),
                        Subject = c.String(nullable: false),
                        BodyHTML = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmailBodyReplacements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        EmailTemplate_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EmailTemplates", t => t.EmailTemplate_Id, cascadeDelete: true)
                .Index(t => t.EmailTemplate_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmailBodyReplacements", "EmailTemplate_Id", "dbo.EmailTemplates");
            DropIndex("dbo.EmailBodyReplacements", new[] { "EmailTemplate_Id" });
            DropTable("dbo.EmailBodyReplacements");
            DropTable("dbo.EmailTemplates");
        }
    }
}
