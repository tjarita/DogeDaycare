using System.Reflection;
using Abp.Modules;

namespace DogeDaycare
{
    [DependsOn(typeof(DogeDaycareCoreModule))]
    public class DogeDaycareApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            //base.PreInitialize();
            //Configuration.Authorization.Providers.Add<DogeDaycareAuthorizationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
