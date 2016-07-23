(function () {
    var controllerId = 'app.views.user_dashboard.home';
    angular.module('app').controller(controllerId, [
        '$scope', '$location', '$state', '$stateParams', '$cookies', 'abp.services.dogedaycare.animal', 'abp.services.dogedaycare.person', 'user_dashboard_nav_updater', 'user_dashboard_context',
        function ($scope, $location, $state, $stateParams, $cookies, animalService, personService, user_dashboard_nav_updater, user_dashboard_context) {
            var vm = this;
            var currentPerson = {};

            $(document).ready(function () {
                user_dashboard_nav_updater.set($state.current.name);
            });

            $scope.home_init = function () {
                currentPerson = $cookies.getObject('currentPerson');
                
                if (!jQuery.isEmptyObject(currentPerson)) {
                    $('#user_dashboard_header_name').text(currentPerson.fName + ' ' + currentPerson.lName);
                }
                else {
                    console.log('empty cookie');
                    $state.go('person.search');
                }

            }





        }
    ]);
})();