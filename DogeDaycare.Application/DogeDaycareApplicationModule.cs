using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using DogeDaycare.Configuration;

namespace DogeDaycare
{
    [DependsOn(typeof(DogeDaycareCoreModule), typeof(AbpAutoMapperModule))]
    public class DogeDaycareApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            IocManager.Register<IWebConfigConfigurationManager, WebConfigConfigurationManager>(Abp.Dependency.DependencyLifeStyle.Transient);
        }
    }
}
