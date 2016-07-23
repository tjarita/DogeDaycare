(function () {
    var controllerId = 'app.views.user_dashboard';
    angular.module('app').controller(controllerId, [
        '$scope', '$location','$state', '$stateParams','abp.services.dogedaycare.animal', 'abp.services.dogedaycare.person',
        function ($scope, $location,$state, $stateParams,animalService, personService) {
            var vm = this;
            
            $(document).ready(function () {
                console.log('dashboard load');
            });

        }
    ])
    .service('user_dashboard_nav_updater', function () {
        nav = {
            set: function (state) {
                $('#user_dashboard_nav li').removeClass('active');
                console.log('nav ');
                console.log(state);
                switch (state) {
                    case 'user_dashboard.home':
                        $('#user_dashboard_home').addClass('active');
                        break;
                    case 'user_dashboard.new':
                        $('#person_new').addClass('active');
                        break;
                    case 'user_dashboard.search':
                        $('#person_search').addClass('active');
                        break;
                }
            }
        }
        return nav;
    })
    .service('user_dashboard_context', function () {
        var currentPerson;
        context = {
            set: function (person) {
                currentPerson = person;
            },
            get: function () {
                return currentPerson;
            }
        }
        return context;
    })
    ;
})();