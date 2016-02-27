(function () {
    var controllerId = 'app.views.animal.search';
    var app = angular.module('app');

    app.controller(controllerId, [
    '$scope', '$location', '$filter', 'abp.services.dogedaycare.animal', 'abp.services.dogedaycare.person', 
    function ($scope, $location, $filter, animalService, personService) {
        var vm = this;

        

        //$scope.filters = {
        //    name: ''
        //};
        $scope.animals = {};
        $scope.data = {};


        //loadTable = function () {
        //    $scope.animalsTable = new ngTableParams({
        //        //Params
        //        page: 1,
        //        count: 10,
        //        //filter: {name: 'T'},
        //        sorting: {
        //            name: "asc"
        //        }
        //    },
        //    {
        //        //Settings
        //        total: $scope.animals.length,
        //        getData: function ($defer, params) {
        //            //data = params.sorting() ? $filter('orderBy')(data, params.orderBy()) : data;
        //            console.log('logging inside getdata');
        //            //pagination
        //            $scope.data = $scope.animals.slice((params.page() - 1) * params.count(), params.page() * params.count());
        //            console.log($scope.data);
        //            // sorting
        //            $scope.data = params.sorting() ? $filter('orderBy')($scope.data, params.orderBy()) : $scope.data;
        //            console.log($scope.data);
        //            // filtering
        //            $scope.data = params.filter() ? $filter('filter')($scope.data, params.filter()) : $scope.data;
        //            console.log($scope.data);

        //            //$scope.data = params.filter() ? $filter('filter')($scope.data, params.filter().myfilter) : $scope.data;
        //            console.log(params.filter())

        //            if (jQuery.isEmptyObject($scope.data)) {
        //                console.log('empty data');
        //                //getAnimalData();
        //            }
        //            //console.log('printing slice and params');
        //            //console.log($scope.data);
        //            //console.log(params);
        //            $defer.resolve($scope.data);
        //        }
        //    });
        //}

        $scope.refresh = function () {
            console.log('refresh');

        }

        $(document).ready(function () {
            //console.log('document ready...');
            abp.ui.setBusy(null,
            animalService.getAllAnimals().success(function (results) {
                //console.log('get animals..');
                $scope.animals = results.animals;
                console.log($scope.animals);
                //console.log('loading table..');
                //loadTable();
                //console.log('finish table..');
            })
            );
        });
    }
    ]);

})();

