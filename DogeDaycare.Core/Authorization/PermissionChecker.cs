using Abp.Authorization;
using DogeDaycare.Authorization.Roles;
using DogeDaycare.MultiTenancy;
using DogeDaycare.Users;

namespace DogeDaycare.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
