(function () {
    var controllerId = 'app.views.person.search';
    var app = angular.module('app');

    app.controller(controllerId, [
    '$scope', '$location', '$filter', 'abp.services.dogedaycare.animal', 'abp.services.dogedaycare.person',
    function ($scope, $location, $filter, animalService, personService) {
        var vm = this;

        $(document).ready(function () {
            console.log('document ready...');
        });

        $scope.searchTerms = {
            fName: '',
            lName: ''
        };

        $scope.results;

        $scope.search = function search() {
            console.log('searching... parameters..');
            console.log($scope.searchTerms);
            console.log($scope.results);
            personService.searchForPerson($scope.searchTerms).success(function (results) {
                $scope.results = results;
                console.log('results:');
                console.log($scope.results.persons);
            });
        }

        $scope.select= function (){
            $scope.selected = this.person;
            console.log($scope.selected);
        }

    }
    ]);

})();

