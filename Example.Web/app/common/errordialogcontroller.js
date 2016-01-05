(function () {
    'use strict';

    angular
        .module('app')
        .controller('errordialogcontroller', errordialogcontroller);

    errordialogcontroller.$inject = ['$scope', '$modalInstance', 'error'];

    function errordialogcontroller($scope, $modalInstance, error) {

        activate();

        function activate() {

            $scope.errorMessage = error.ErrorMessage;

            if (error.Stacktrace) {
                $scope.stacktrace = error.Stacktrace;
            }
            
            if (error.ValidationErrors) {
                $scope.validationErrors = error.ValidationErrors;
            }
        }

        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };
    }
})();
