using System.Reflection;
using Abp.Modules;

namespace DogeDaycare
{
    public class DogeDaycareCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
