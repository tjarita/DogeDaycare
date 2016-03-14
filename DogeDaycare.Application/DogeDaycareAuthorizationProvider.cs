using Abp.Authorization;
using Abp.Localization;
using System;

namespace DogeDaycare
{
    public class DogeDaycareAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            var administration = context.CreatePermission("Administration", new LocalizableString("Administration", DogeDaycareConsts.LocalizationSourceName));
            var userMaintenance = administration.CreateChildPermission("Administration.UserMaintenance", new LocalizableString("UserMaintenance", DogeDaycareConsts.LocalizationSourceName));
            var roleMaintenance = administration.CreateChildPermission("Administration.RoleMaintenance", new LocalizableString("RoleMaintenance", DogeDaycareConsts.LocalizationSourceName));
        }
    }
}
