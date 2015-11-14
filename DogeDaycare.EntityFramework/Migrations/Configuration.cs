namespace DogeDaycare.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DogeDaycare.EntityFramework.DogeDaycareDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DogeDaycare.EntityFramework.DogeDaycareDbContext context)
        {
        }
    }
}
