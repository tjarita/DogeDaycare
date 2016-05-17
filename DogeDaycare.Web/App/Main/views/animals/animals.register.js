(function () {
    var controllerId = 'app.views.animals.register';
    angular.module('app').controller(controllerId, [
        '$scope', '$location', 
        function ($scope, $location) {
            var vm = this;
            //About logic...

            // CreateAnimalInput object
            vm.animal = {
                name: '',
                //IdOwner: null
            };

            //personService.getAllPersons().success(function (data) {
            //    vm.persons = data.persons;
            //});

            //vm.saveAnimal = function () {
            //    abp.ui.setBusy(null,
            //        animalService.createAnimal(
            //            vm.animal
            //            ).success(function () {
            //                abp.notify.info('Animal Registered');
            //                $location.path('/animal');
            //            }));
            //};
        }
    ]);
})();