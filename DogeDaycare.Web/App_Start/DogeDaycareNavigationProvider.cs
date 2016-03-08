﻿using Abp.Application.Navigation;
using Abp.Localization;

namespace DogeDaycare.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See .cshtml and .js files under App/Main/views/layout/header to know how to render menu.
    /// </summary>
    public class DogeDaycareNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        "Home",
                        new LocalizableString("Home Page", DogeDaycareConsts.LocalizationSourceName),
                        url: "#/",
                        icon: "fa fa-home"
                        )
                )

                .AddItem(
                    new MenuItemDefinition(
                        "About",
                        new LocalizableString("About", DogeDaycareConsts.LocalizationSourceName),
                        url: "#/about",
                        icon: "fa fa-info"
                        )
                )
                //.AddItem(
                //    new MenuItemDefinition(
                //        "Admin",
                //        new LocalizableString("Admin", DogeDaycareConsts.LocalizationSourceName),
                //        url: "#/admin",
                //        icon: "fa fa-gears "
                //        )
                .AddItem(new MenuItemDefinition(
                    "Animals",
                    new LocalizableString("Animals", DogeDaycareConsts.LocalizationSourceName),
                    url: "#/animal",
                    icon: "fa fa-paw"
                    //, requiredPermissionName: ""
                    )
                )
                .AddItem(new MenuItemDefinition(
                    "Persons",
                    new LocalizableString("Users", DogeDaycareConsts.LocalizationSourceName),
                    url: "#/person/search",
                    icon: "fa fa-users"
                    //, requiredPermissionName: ""
                    )
                )
                .AddItem(new MenuItemDefinition(
                    "Dashboard",
                    new LocalizableString("Dashboard", DogeDaycareConsts.LocalizationSourceName),
                    url: "#/dashboard/home",
                    icon: "fa fa-tachometer"
                    //, requiredPermissionName: ""
                    )
                )

                ;
        }
    }
}
