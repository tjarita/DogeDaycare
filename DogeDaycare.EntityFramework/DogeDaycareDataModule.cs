using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using DogeDaycare.EntityFramework;

namespace DogeDaycare
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(DogeDaycareCoreModule))]
    public class DogeDaycareDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
