(function () {
    var controllerId = 'app.views.person.search';
    var app = angular.module('app');

    app.controller(controllerId, [
             '$scope', '$location', '$filter', '$state', 'abp.services.dogedaycare.animal', 'abp.services.dogedaycare.person', 'person_nav_updater',
    function ($scope, $location, $filter, $state, animalService, personService, person_nav_updater) {
        var vm = this;

        $(document).ready(function () {
            console.log('search ready...');
            person_nav_updater.set($state.current.name);
        });

        $scope.searchTerms = {
            fName: '',
            lName: ''
        };

        $scope.results;

        $scope.search = function () {
            console.log('searching... parameters..');
            console.log($scope.searchTerms);
            personService.searchForPerson($scope.searchTerms).success(function (results) {
                $scope.results = results;
                console.log('results:');
                console.log($scope.results.persons);
            });
        }

        $scope.selectedID = null;

        $scope.select = function (person) {
            $state.get('person').data.currentPerson = person;
            console.log('set current person to');
            console.log($state.get('person').data.currentPerson);
            $scope.selectedID = person.id;
        }

        $scope.load = function () {
            if ($state.get('person').data.currentPerson != null) {
                console.log('going to person home');
                $location.path('/person/home');
            }
            else
                alert('Please select a person to load.');
        }
    }
    ]);
})();

