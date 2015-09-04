using System.Reflection;
using Abp.Application.Services;
using Abp.Modules;
using Abp.WebApi;
using Abp.WebApi.Controllers.Dynamic.Builders;

namespace DogeDaycare
{
    [DependsOn(typeof(AbpWebApiModule), typeof(DogeDaycareApplicationModule))]
    public class DogeDaycareWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(DogeDaycareApplicationModule).Assembly, "daycare")
                .Build();
        }
    }
}
