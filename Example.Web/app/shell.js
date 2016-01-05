(function () {
    'use strict';

    angular
        .module('app')
        .controller('shellcontroller', shellcontroller);

    shellcontroller.$inject = ['$scope', 'common', 'contextservice', 'errorhandler'];

    function shellcontroller($scope, common, contextservice, errorhandler) {

        activate();

        function activate() {

            $scope.isLoading = true;
            contextservice.getcontext().then(
                function (context) {
                	// context initialization
                    common.usercontext = context.User;
                    common.resourceStrings = context.Resouces;
                    $scope.usercontext = common.usercontext;
                    $scope.isLoading = false;
                },

                function (error) {
                    $scope.isLoading = false;
                });
        }

        common.$rootScope.handleError = function (error) {
            errorhandler.handle(error);
        };
    }

})();
