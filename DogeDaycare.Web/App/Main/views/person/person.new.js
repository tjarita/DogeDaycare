(function () {
    var controllerId = 'app.views.person.new';
    angular.module('app').controller(controllerId, [
        '$scope', '$location', 'abp.services.dogedaycare.person',
        function ($scope, $location, personService) {
            var vm = this;

            vm.person = {
                NickName: '',
            //    Gender: '',
            //    Birthday: '',
            //    Address
            };

            vm.savePerson = function () {
                abp.ui.setBusy(null,
                personService.createPerson(
                        vm.person
                        ).success(function () {
                            abp.notify.info('Person registered');
                            $location.path('/person');
                        }));
            };
        }
    ]);
})();