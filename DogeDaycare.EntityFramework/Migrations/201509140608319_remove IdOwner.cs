namespace DogeDaycare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeIdOwner : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Animals", name: "IdOwner", newName: "Owner_Id");
            RenameIndex(table: "dbo.Animals", name: "IX_IdOwner", newName: "IX_Owner_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Animals", name: "IX_Owner_Id", newName: "IX_IdOwner");
            RenameColumn(table: "dbo.Animals", name: "Owner_Id", newName: "IdOwner");
        }
    }
}
