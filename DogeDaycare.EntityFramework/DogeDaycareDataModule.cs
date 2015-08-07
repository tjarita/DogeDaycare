using System.Data.Entity;
using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;
using DogeDaycare.EntityFramework;

namespace DogeDaycare
{
    [DependsOn(typeof(AbpEntityFrameworkModule), typeof(DogeDaycareCoreModule))]
    public class DogeDaycareDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Database.SetInitializer<DogeDaycareDbContext>(null);
        }
    }
}
