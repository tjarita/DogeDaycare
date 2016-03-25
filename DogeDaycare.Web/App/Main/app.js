(function () {
    'use strict';
    
    var app = angular.module('app', [
        'ngAnimate',
        'ngSanitize',

        'ui.router',
        'ui.bootstrap',
        'ui.jq',

        'abp'
    ]);

    //Configuration for Angular UI routing.
    app.config([
        '$stateProvider', '$urlRouterProvider',
        function($stateProvider, $urlRouterProvider) {
            $urlRouterProvider.otherwise('/');

            if (abp.auth.hasPermission('Pages.Tenants')) {
                $stateProvider
                    .state('tenants', {
                        url: '/tenants',
                        templateUrl: '/App/Main/views/tenants/index.cshtml',
                        menu: 'Tenants' //Matches to name of 'Tenants' menu in DogeDaycareNavigationProvider
                    });
                $urlRouterProvider.otherwise('/tenants');
            }

            $stateProvider
                .state('home', {
                    url: '/',
                    templateUrl: '/App/Main/views/home/home.cshtml',
                    menu: 'Home' //Matches to name of 'Home' menu in DogeDaycareNavigationProvider
                })
                .state('about', {
                    url: '/about',
                    templateUrl: '/App/Main/views/about/about.cshtml',
                    menu: 'About' //Matches to name of 'About' menu in DogeDaycareNavigationProvider
                })
                .state('person', {
                    url: '/person',
                    templateUrl: '/App/Main/views/person/person.cshtml',
                    data: {
                        currentPerson: null
                    }
                })
                    .state('person.home', {
                        url: '/home',
                        templateUrl: '/App/Main/views/person/person.home.cshtml',
                    })
                    .state('person.new', {
                        url: '/new',
                        templateUrl: '/App/Main/views/person/person.new.cshtml',
                    })
                    .state('person.search', {
                        url: '/search?fName&lName',
                        menu: 'Persons',
                        params: {
                            fName: null,
                            lName: null,
                        },
                        templateUrl: '/App/Main/views/person/person.search.cshtml',
                    })
            ; // State Provider
        }
    ]);
})();