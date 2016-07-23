using System.Data.Entity.Migrations;
using DogeDaycare.Migrations.SeedData;
using System.Linq;
using Abp.Net.Mail;

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
            new InitialDataBuilder(context).Build();
        }


    }
}
