(function () {
    var controllerId = 'app.views.person.search';
    var app = angular.module('app');

    app.controller(controllerId, [
             '$scope', '$location', '$filter', '$state', '$stateParams', '$cookies','abp.services.dogedaycare.animal', 'abp.services.dogedaycare.person', 'person_nav_updater',
    function ($scope, $location, $filter, $state, $stateParams, $cookies, animalService, personService, person_nav_updater) {
        var vm = this;

        $(document).ready(function () {
            console.log('search ready...');
            person_nav_updater.set($state.current.name);
            console.log($stateParams);
            if($stateParams.fName === null && $stateParams.lName === null)
                $scope.searchMode = true;
            else
                search();
        });

        //$scope.searchTerms = {
        //    fName: '',
        //    lName: ''
        //};

        $scope.results;

        function search() {
            console.log('searching... parameters..');
            console.log($stateParams);
            abp.ui.setBusy(null,
            personService.searchForPerson($stateParams).success(function (results) {
                $scope.results = results;
                console.log('results:');
                console.log($scope.results.persons.length);
            }));
        }

        $scope.selected = null;

        $scope.select = function (person) {
            console.log('set current person to');
            $scope.selected = person;
        }

        $scope.load = function () {
            if ($scope.selected != null && typeof $scope.selected != 'undefined') {
                $cookies.putObject('currentPerson', $scope.selected);
                $state.go('user_dashboard.home');
            }
            else
                alert('Please select a person');
        }

    }
    ]);
})();

