(function () {
    var controllerId = 'app.views.person';
    angular.module('app').controller(controllerId, [
        '$scope', 
        function ($scope) {
            var vm = this;

            $scope.load = function () {
                // Adds active property to nav when switching states
                $(document).ready(function () {
                });
            }
            $scope.load();
        }
    ])
    .service('person_nav_updater', function () {
        nav = {
            set: function (state) {
                $('#person_nav li').removeClass('active');
                switch (state) {
                    case 'person.home':
                        $('#person_home').addClass('active');
                        break;
                    case 'person.new':
                        $('#person_new').addClass('active');
                        break;
                    case 'person.search':
                        $('#person_search').addClass('active');
                        break;
                }
            }
        }
        return nav;
    })
})();