using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Organizations;
using Abp.Runtime.Caching;
using Abp.Zero.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeDaycare.Authorization.Managers
{
    public class UserManager : AbpUserManager<Tenant, Role, User>
    {
        public UserManager(
            UserStore userStore,
            RoleManager roleManager,
            IRepository<Tenant> tenantRepository,
            IMultiTenancyConfig multiTenancyConfig,
            IPermissionManager permissionManager,
            IUnitOfWorkManager unitOfWorkManager,
            ISettingManager settingManager,
            IUserManagementConfig userManagementConfig,
            IIocResolver iocResolver,
            ICacheManager cacheManager,
            IRepository<OrganizationUnit, long> organizationUnitRepository,
            IRepository<UserOrganizationUnit, long> userOrganizationUnitRepository,
            IOrganizationUnitSettings organizationUnitSettings,
            IRepository<UserLoginAttempt, long> userLoginAttempyRepository
            )
            : base(
                  userStore,
                  roleManager,
                  tenantRepository,
                  multiTenancyConfig,
                  permissionManager,
                  unitOfWorkManager,
                  settingManager,
                  userManagementConfig,
                  iocResolver,
                  cacheManager,
                  organizationUnitRepository,
                  userOrganizationUnitRepository,
                  organizationUnitSettings,
                  userLoginAttempyRepository
                  )
        { }
    }
}
