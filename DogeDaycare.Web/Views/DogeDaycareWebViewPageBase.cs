using Abp.Web.Mvc.Views;

namespace DogeDaycare.Web.Views
{
    public abstract class DogeDaycareWebViewPageBase : DogeDaycareWebViewPageBase<dynamic>
    {

    }

    public abstract class DogeDaycareWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected DogeDaycareWebViewPageBase()
        {
            LocalizationSourceName = DogeDaycareConsts.LocalizationSourceName;
        }
    }
}