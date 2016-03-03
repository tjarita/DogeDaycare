(function () {
    var controllerId = 'app.views.person.home';
    var app = angular.module('app');

    app.controller(controllerId, [
             '$scope', '$location', '$filter', '$state', 'abp.services.dogedaycare.animal', 'abp.services.dogedaycare.person', 'person_nav_updater',
    function ($scope, $location, $filter, $state, animalService, personService, person_nav_updater) {
        var vm = this;

        $(document).ready(function () {
            console.log('home ready');
            person_nav_updater.set($state.current.name);
        });



        $scope.init = function () {
            console.log('home init');
            $scope.current = $state.get('person').data.currentPerson;
            console.log($scope.current);


        }

    }
    ]);

})();

