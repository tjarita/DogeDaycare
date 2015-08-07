using System.Data.Entity.Migrations;

namespace DogeDaycare.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DogeDaycare.EntityFramework.DogeDaycareDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DogeDaycare";
        }

        protected override void Seed(DogeDaycare.EntityFramework.DogeDaycareDbContext context)
        {
            // This method will be called every time after migrating to the latest version.
            // You can add any seed data here...
        }
    }
}
