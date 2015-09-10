namespace DogeDaycare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        IdOwner = c.Guid(),
                        RegisteredTime = c.DateTime(nullable: false),
                        Appointment_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Persons", t => t.IdOwner)
                .ForeignKey("dbo.Appointments", t => t.Appointment_Id)
                .Index(t => t.IdOwner)
                .Index(t => t.Appointment_Id);
            
            CreateTable(
                "dbo.Persons",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        Owner_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Persons", t => t.Owner_Id)
                .Index(t => t.Owner_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Animals", "Appointment_Id", "dbo.Appointments");
            DropForeignKey("dbo.Appointments", "Owner_Id", "dbo.Persons");
            DropForeignKey("dbo.Animals", "IdOwner", "dbo.Persons");
            DropIndex("dbo.Appointments", new[] { "Owner_Id" });
            DropIndex("dbo.Animals", new[] { "Appointment_Id" });
            DropIndex("dbo.Animals", new[] { "IdOwner" });
            DropTable("dbo.Appointments");
            DropTable("dbo.Persons");
            DropTable("dbo.Animals");
        }
    }
}
