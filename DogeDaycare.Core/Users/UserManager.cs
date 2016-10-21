using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.IdentityFramework;
using Abp.Localization;
using Abp.Organizations;
using Abp.Runtime.Caching;
using Abp.Zero.Configuration;
using DogeDaycare.Authorization.Roles;
using DogeDaycare.MultiTenancy;

namespace DogeDaycare.Users
{
    public class UserManager : AbpUserManager<Role, User>
    {
        public UserManager(
            AbpUserStore<Role, User> userStore,
            AbpRoleManager<Role, User> roleManager,
            IPermissionManager permissionManager,
            IUnitOfWorkManager unitOfWorkManager,
            ICacheManager cacheManager,
            IRepository<OrganizationUnit, long> organizationUnitRepository,
            IRepository<UserOrganizationUnit, long> userOrganizationUnitRepository,
            IOrganizationUnitSettings organizationUnitSettings,
            ILocalizationManager localizationManager,
            IdentityEmailMessageService emailService,
            ISettingManager settingManager,
            IUserTokenProviderAccessor userTokenProviderAccessor

            //UserStore store,
            //RoleManager roleManager,
            //IRepository<Tenant> tenantRepository,
            //IMultiTenancyConfig multiTenancyConfig,
            //IPermissionManager permissionManager,
            //IUnitOfWorkManager unitOfWorkManager,
            //ISettingManager settingManager,
            //IUserManagementConfig userManagementConfig,
            //IIocResolver iocResolver,
            //ICacheManager cacheManager,
            //IRepository<OrganizationUnit, long> organizationUnitRepository,
            //IRepository<UserOrganizationUnit, long> userOrganizationUnitRepository,
            //IOrganizationUnitSettings organizationUnitSettings,
            //IRepository<UserLoginAttempt, long> userLoginAttemptRepository
            )
            : base(
            userStore,
            roleManager,
            permissionManager,
            unitOfWorkManager,
            cacheManager,
            organizationUnitRepository,
            userOrganizationUnitRepository,
            organizationUnitSettings,
            localizationManager,
            emailService,
            settingManager,
            userTokenProviderAccessor
            )
        {
        }

    }
}