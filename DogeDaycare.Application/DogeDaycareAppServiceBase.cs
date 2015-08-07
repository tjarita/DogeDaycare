using Abp.Application.Services;

namespace DogeDaycare
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class DogeDaycareAppServiceBase : ApplicationService
    {
        protected DogeDaycareAppServiceBase()
        {
            LocalizationSourceName = DogeDaycareConsts.LocalizationSourceName;
        }
    }
}