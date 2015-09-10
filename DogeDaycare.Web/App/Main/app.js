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
        function ($stateProvider, $urlRouterProvider) {
            $urlRouterProvider.otherwise('/');
            $stateProvider.state('home', {
                    url: '/',
                    templateUrl: '/App/Main/views/home/home.cshtml',
                    menu: 'Home' //Matches to name of 'Home' menu in DogeDaycareNavigationProvider
                })
                .state('about', {
                    url: '/about',
                    templateUrl: '/App/Main/views/about/about.cshtml',
                    menu: 'About' //Matches to name of 'About' menu in DogeDaycareNavigationProvider
                })
                .state('admin', {
                    url: '/admin',
                    templateUrl: '/App/Main/views/admin/admin.cshtml',
                    menu: 'Admin' //Matches to name of 'Admin' menu in DogeDaycareNavigationProvider
                })
                //.state('animal.list', {
                //    url: '/animal/list',
                //    templateUrl: '/App/Main/views/admin/animal/list.cshtml',
                //    menu: 'AnimalSearch' //Matches to name of 'AnimalSearch' menu in DogeDaycareNavigationProvider
                //})
                .state('animal', {
                    url: '/animal',
                    templateUrl: '/App/Main/views/animal/animal.cshtml',
                    menu: 'Animals' //Matches to name of 'AnimalAdd' menu in DogeDaycareNavigationProvider

                })
                    .state('animal.new', {
                        url: '/new',
                        templateUrl: '/App/Main/views/animal/animal.new.cshtml',
                    })
                .state('person', {
                    url: '/person',
                    templateUrl: '/App/Main/views/person/person.cshtml',
                    menu: 'Persons' //Matches to name of 'AnimalAdd' menu in DogeDaycareNavigationProvider
                })
                    .state('person.new', {
                        url: '/new',
                        templateUrl: '/App/Main/views/person/person.new.cshtml',
                    })
            ;
        }
    ]);
})();