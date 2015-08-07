using System.Reflection;
using Abp.Modules;

namespace DogeDaycare
{
    [DependsOn(typeof(DogeDaycareCoreModule))]
    public class DogeDaycareApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
