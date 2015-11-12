(function () {
    var controllerId = 'app.views.person.new';
    angular.module('app').controller(controllerId, [
        //'$scope', 'abp.services.dogedaycare.animal', 'abp.services.dogedaycare.person',
        '$scope', '$location', 'abp.services.dogedaycare.person',
        function ($scope, $location, personService) {

        //function ($scope, animalService, personService) {
            var vm = this;

            vm.person = {
                name: ''
            };

            vm.savePerson = function () {
                abp.ui.setBusy(null,
                personService.createPerson(
                        vm.person
                        ).success(function () {
                            abp.notify.info('Person registered');
                            $location.path('/person');
                            $scope.$apply();
                        }));
            };
        }
    ]);
})();