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


    // Menu matches to the name in DogeDaycareNavigationProvider

    //Configuration for Angular UI routing.
    app.config([
        '$stateProvider', '$urlRouterProvider',
        function ($stateProvider, $urlRouterProvider) {
            $urlRouterProvider.otherwise('/');
            $stateProvider.state('home', {
                url: '/',
                templateUrl: '/App/Main/views/home/home.cshtml',
                menu: 'Home'
            })
                .state('about', {
                    url: '/about',
                    templateUrl: '/App/Main/views/about/about.cshtml',
                    menu: 'About'
                })
                //.state('admin', {
                //    url: '/admin',
                //    templateUrl: '/App/Main/views/admin/admin.cshtml',
                //    menu: 'Admin' //Matches to name of 'Admin' menu in DogeDaycareNavigationProvider
                //})
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
                    .state('animal.search', {
                        url: '/search?ownerId',
                        templateUrl: '/App/Main/views/animal/animal.search.cshtml',
                        controller: function ($scope, $stateParams) {
                            $scope.ownerId = $stateParams.ownerId;
                        }
                    })
                .state('user_dashboard', {
                    title: 'User Dashboard',
                    url: '/dashboard',
                    templateUrl: '/App/Main/views/user_dashboard/user_dashboard.cshtml',
                    data: {
                        currentPerson: null
                    },
                })
                    .state('user_dashboard.home', {
                        url: '/home',
                        menu: 'Dashboard',
                        params: {
                            person: null,
                        },
                        templateUrl: '/App/Main/views/user_dashboard/user_dashboard.home.cshtml',
                        onEnter: function ($state, $stateParams) {
                            console.log('dash onenter');
                            console.log($stateParams.person);
                            if ($.isEmptyObject($stateParams.person) || typeof $stateParams.person === 'undefined') {
                                console.log('empty stateparams');
                                $state.go('person.search');
                            }
                        }
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
                            fName:null,
                            lName:null,
                        },
                        templateUrl: '/App/Main/views/person/person.search.cshtml',
                    })
            ;
        }
    ]);
})();