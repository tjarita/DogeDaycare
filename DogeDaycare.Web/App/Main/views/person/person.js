(function () {
    var controllerId = 'app.views.person';
    angular.module('app').controller(controllerId, [
        '$scope', function ($scope) {
            var vm = this;
            //About logic...
            $scope.load = function () {
                // Adds active property to nav when switching states
                $(document).ready(function () {
                    $('#person_nav li').click(function (e) {
                        $('#person_nav li').removeClass('active');
                        $(this).addClass('active');
                    });
                });
            }
            $scope.load();



        }
    ])
    .service('personMaintenanceContext', function () {
        var person = {};


        return {
            getPerson: function () { return person; },
            setPerson: function (input) { person = input;}
        }
    });;




})();