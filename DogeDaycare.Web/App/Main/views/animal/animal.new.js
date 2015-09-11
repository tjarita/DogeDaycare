(function () {
    var controllerId = 'app.views.animal.new';
    angular.module('app').controller(controllerId, [
        '$scope', '$location','abp.services.dogedaycare.animal', 'abp.services.dogedaycare.person',
        function ($scope, $location, animalService, personService) {
            var vm = this;
            //About logic...

            vm.animal = {
                name: '',
                owner: null
            };

            personService.getAllPersons().success(function (data) {
                vm.persons = data.persons;
            });

            vm.saveAnimal = function () {
                abp.ui.setBusy(null,
                    animalService.createAnimal(vm.animal
                    ).success(function(){
                        abp.notify.info('Animal Registered');
                        $location.path('/person');
                    }));
            };
        }
    ]);
})();