(function () {
    var controllerId = 'app.views.animal.search';
    var app = angular.module('app');

    app.controller(controllerId, [
    '$scope', '$location', '$filter' ,'abp.services.dogedaycare.animal', 'abp.services.dogedaycare.person', 'ngTableParams',
    function ($scope, $location, $filter, animalService, personService, ngTableParams) {
        var vm = this;
        abp.ui.setBusy(null,
                animalService.getAllAnimals().success(function (data) {
                    $scope.animals = data.animals;
                    $scope.animalsTable = new ngTableParams({
                        page: 1,
                        count: 3
                    }, {
                        total: $scope.animals.length,
                        getData: function ($defer, params) {
                            $scope.data = params.sorting() ? $filter('orderBy')($scope.animals, params.orderBy()) : $scope.animals;
                            $scope.data = $scope.animals.slice((params.page() - 1) * params.count(), params.page() * params.count());
                            $defer.resolve($scope.data);
                        }
                    });
                }));



    }
    ]);

})();

