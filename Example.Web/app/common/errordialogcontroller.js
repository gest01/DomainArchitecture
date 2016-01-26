(function () {
    'use strict';

    angular
        .module('app')
        .controller('errordialogcontroller', errordialogcontroller);

    errordialogcontroller.$inject = ['$scope', '$uibModalInstance', 'error'];

    function errordialogcontroller($scope, $uibModalInstance, error) {

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
            $uibModalInstance.dismiss('cancel');
        };
    }
})();
