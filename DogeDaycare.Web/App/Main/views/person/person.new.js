(function () {
    var controllerId = 'app.views.person.new';
    angular.module('app').controller(controllerId, [
        '$scope', '$location', '$state', 'abp.services.dogedaycare.person', 'person_nav_updater',
        function ($scope, $location, $state, personService, person_nav_updater) {
            var vm = this;

            $(document).ready(function () {
                person_nav_updater.set($state.current.name);
            });


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