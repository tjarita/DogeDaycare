(function () {
	var controllerId = 'app.views.animal';
	angular.module('app').controller(controllerId, [
        '$scope', function ($scope) {
        	var vm = this;
            //About logic...
        	$scope.load = function () {
        	    // Adds active property to nav when switching states
        	    $(document).ready(function () {
        	        $('#animal_nav li').click(function (e) {
        	            $('#animal_nav li').removeClass('active');
        	            $(this).addClass('active');
        	        });
        	    });
        	}
        	$scope.load();


        }
	]);
})();