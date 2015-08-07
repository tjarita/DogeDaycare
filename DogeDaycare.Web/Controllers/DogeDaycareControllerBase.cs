using Abp.Web.Mvc.Controllers;

namespace DogeDaycare.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class DogeDaycareControllerBase : AbpController
    {
        protected DogeDaycareControllerBase()
        {
            LocalizationSourceName = DogeDaycareConsts.LocalizationSourceName;
        }
    }
}