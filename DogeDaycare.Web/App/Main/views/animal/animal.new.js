(function () {
    var controllerId = 'app.views.animal.new';
    angular.module('app').controller(controllerId, [
        '$scope', 'abp.services.dogedaycare.animal',
        function ($scope, animalService) {
            var vm = this;
            //About logic...

            vm.localize = abp.localization.getSource('DogeDaycare');


        }
    ]);
})();