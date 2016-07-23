(function () {
    var controllerId = 'app.views.animals.home';
    var app = angular.module('app');

    app.controller(controllerId, [
             '$scope', '$location', '$filter', '$state', 'abp.services.app.animal',
    function ($scope, $location, $filter, $state, animalService) {
        var vm = this;

        $(document).ready(function () {
            console.log('home ready');
        });

    }
    ]);

})();

