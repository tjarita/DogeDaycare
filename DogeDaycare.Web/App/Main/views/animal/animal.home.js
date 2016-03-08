(function () {
    var controllerId = 'app.views.animal.home';
    var app = angular.module('app');

    app.controller(controllerId, [
             '$scope', '$location', '$filter', '$state', 'abp.services.dogedaycare.animal', 'abp.services.dogedaycare.person',
    function ($scope, $location, $filter, $state, animalService, personService) {
        var vm = this;

        $(document).ready(function () {
            console.log('home ready');
        });

    }
    ]);

})();

