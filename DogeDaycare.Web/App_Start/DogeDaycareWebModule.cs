using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Abp.Localization;
using Abp.Localization.Sources.Xml;
using Abp.Modules;

namespace DogeDaycare.Web
{
    [DependsOn(typeof(DogeDaycareDataModule), typeof(DogeDaycareApplicationModule), typeof(DogeDaycareWebApiModule))]
    public class DogeDaycareWebModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Add/remove languages for your application
            Configuration.Localization.Languages.Add(new LanguageInfo("en", "English", "famfamfam-flag-us", true));

            //Add/remove localization sources here
            Configuration.Localization.Sources.Add(
                new XmlLocalizationSource(
                    DogeDaycareConsts.LocalizationSourceName,
                    HttpContext.Current.Server.MapPath("~/Localization/DogeDaycare")
                    )
                );

            //Configure navigation/menu
            Configuration.Navigation.Providers.Add<DogeDaycareNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
