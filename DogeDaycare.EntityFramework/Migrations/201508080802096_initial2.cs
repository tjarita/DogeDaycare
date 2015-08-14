namespace DogeDaycare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        IdOwner = c.Guid(nullable: false),
                        IdAnimal = c.Guid(nullable: false),
                        RegisteredTime = c.DateTime(nullable: false),
                        Appointment_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Appointments", t => t.Appointment_Id)
                .Index(t => t.Appointment_Id);
            
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IdAppointment = c.Guid(nullable: false),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        Owner_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Owner_Id)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IdPerson = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Animals", "Appointment_Id", "dbo.Appointments");
            DropForeignKey("dbo.Appointments", "Owner_Id", "dbo.People");
            DropIndex("dbo.Appointments", new[] { "Owner_Id" });
            DropIndex("dbo.Animals", new[] { "Appointment_Id" });
            DropTable("dbo.People");
            DropTable("dbo.Appointments");
            DropTable("dbo.Animals");
        }
    }
}
