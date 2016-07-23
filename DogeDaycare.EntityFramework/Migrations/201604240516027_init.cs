namespace DogeDaycare.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 128),
                        Age = c.Single(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        Owner_Id = c.Long(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Animal_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpUsers", t => t.Owner_Id, cascadeDelete: true)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Start = c.DateTimeOffset(nullable: false, precision: 7),
                        End = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        Owner_Id = c.Long(),
                        Pet_Id = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Appointment_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpUsers", t => t.Owner_Id)
                .ForeignKey("dbo.Animals", t => t.Pet_Id)
                .Index(t => t.Owner_Id)
                .Index(t => t.Pet_Id);
            
            CreateTable(
                "dbo.AbpUserLoginAttempts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        TenancyName = c.String(maxLength: 64),
                        UserId = c.Long(),
                        UserNameOrEmailAddress = c.String(maxLength: 256),
                        ClientIpAddress = c.String(maxLength: 64),
                        ClientName = c.String(maxLength: 128),
                        BrowserInfo = c.String(maxLength: 256),
                        Result = c.Byte(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.TenancyName, t.UserNameOrEmailAddress, t.Result });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "Pet_Id", "dbo.Animals");
            DropForeignKey("dbo.Appointments", "Owner_Id", "dbo.AbpUsers");
            DropForeignKey("dbo.Animals", "Owner_Id", "dbo.AbpUsers");
            DropIndex("dbo.AbpUserLoginAttempts", new[] { "TenancyName", "UserNameOrEmailAddress", "Result" });
            DropIndex("dbo.Appointments", new[] { "Pet_Id" });
            DropIndex("dbo.Appointments", new[] { "Owner_Id" });
            DropIndex("dbo.Animals", new[] { "Owner_Id" });
            DropTable("dbo.AbpUserLoginAttempts");
            DropTable("dbo.Appointments",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Appointment_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Animals",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Animal_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
