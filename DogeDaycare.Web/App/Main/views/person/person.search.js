(function () {
    var controllerId = 'app.views.person.search';
    var app = angular.module('app');

    app.controller(controllerId, [
    '$scope', '$location', '$filter', 'abp.services.dogedaycare.animal', 'abp.services.dogedaycare.person', 'personMaintenanceContext',
    function ($scope, $location, $filter, animalService, personService, personMaintenanceContext) {
        var vm = this;

        $(document).ready(function () {
            console.log('document ready...');
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

        $scope.select = function (){
            $scope.selected = this.person;
            personMaintenanceContext.setPerson($scope.selected);
            console.log('set context to');
            console.log(personMaintenanceContext.getPerson());
        }



    }
    ]);

})();

