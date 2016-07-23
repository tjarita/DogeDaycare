using DogeDaycare.EntityFramework;
using EntityFramework.DynamicFilters;

namespace DogeDaycare.Migrations.SeedData
{
    public class InitialDataBuilder
    {
        private readonly DogeDaycareDbContext _context;

        public InitialDataBuilder(DogeDaycareDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            _context.DisableAllFilters();

            new DefaultEditionsBuilder(_context).Build();
            new DefaultTenantRoleAndUserBuilder(_context).Build();
            new DefaultLanguagesBuilder(_context).Build();
        }
    }
}
