namespace DogeDaycare.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Changeanimalfromauditedtoregularentity : DbMigration
    {
        public override void Up()
        {
            AlterTableAnnotations(
                "dbo.Animals",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 128),
                        Age = c.Single(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Owner_Id = c.Long(nullable: false),
                        Appointment_Id = c.Guid(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Animal_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            DropColumn("dbo.Animals", "IsDeleted");
            DropColumn("dbo.Animals", "DeleterUserId");
            DropColumn("dbo.Animals", "DeletionTime");
            DropColumn("dbo.Animals", "LastModificationTime");
            DropColumn("dbo.Animals", "LastModifierUserId");
            DropColumn("dbo.Animals", "CreationTime");
            DropColumn("dbo.Animals", "CreatorUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Animals", "CreatorUserId", c => c.Long());
            AddColumn("dbo.Animals", "CreationTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Animals", "LastModifierUserId", c => c.Long());
            AddColumn("dbo.Animals", "LastModificationTime", c => c.DateTime());
            AddColumn("dbo.Animals", "DeletionTime", c => c.DateTime());
            AddColumn("dbo.Animals", "DeleterUserId", c => c.Long());
            AddColumn("dbo.Animals", "IsDeleted", c => c.Boolean(nullable: false));
            AlterTableAnnotations(
                "dbo.Animals",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 128),
                        Age = c.Single(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Owner_Id = c.Long(nullable: false),
                        Appointment_Id = c.Guid(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Animal_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
        }
    }
}
