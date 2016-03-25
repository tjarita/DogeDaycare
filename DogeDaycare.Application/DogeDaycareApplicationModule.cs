using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace DogeDaycare
{
    [DependsOn(typeof(DogeDaycareCoreModule), typeof(AbpAutoMapperModule))]
    public class DogeDaycareApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
