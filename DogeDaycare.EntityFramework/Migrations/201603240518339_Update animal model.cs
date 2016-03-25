namespace DogeDaycare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updateanimalmodel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Animals", "Age", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Animals", "Age", c => c.Int(nullable: false));
        }
    }
}
