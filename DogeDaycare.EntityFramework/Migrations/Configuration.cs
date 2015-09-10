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
            Persons.Person toshiki = new Persons.Person() { Name = "Toshiki" };
            Animals.Animal sachi = new Animals.Animal() { Name = "Sachi", Owner = toshiki, IdOwner = toshiki.Id };
            context.Persons.Add(toshiki);
            context.Animals.Add(sachi);

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
