(function () {
    'use strict';

    angular
        .module('app')
        .controller('shellcontroller', shellcontroller);

    shellcontroller.$inject = ['$scope', 'common', 'contextservice', 'errorhandler', 'dataservice'];

    function shellcontroller($scope, common, contextservice, errorhandler, dataservice) {

        activate();

        function activate() {

            $scope.title = 'Angular App';
            $scope.callPageNotFound = callPageNotFound;
            $scope.callServerException = callServerException;
            $scope.callNotAuthorized = callNotAuthorized;
            $scope.callSuccess = callSuccess;
            $scope.callBadRequest = callBadRequest;

            $scope.isLoading = true;
            contextservice.getcontext().then(
                function (context) {
                    // context initialization
                    $scope.usercontext = context;
                    $scope.isLoading = false;
                },

                function (error) {
                    $scope.isLoading = false;
                });
        }

        common.$rootScope.handleError = function (error) {
            errorhandler.handle(error);
        };

        function callBadRequest() {
            var myitem = {
                Id: 1,
                Name : 'hello'
            };

            dataservice.badRequest(myitem).then(function (result) {
                $scope.result = result;
            }, function (error) {
                $scope.result = error;
            });
        }

        function callSuccess() {
            dataservice.getData().then(function (result) {
                $scope.result = result;
            }, function (error) {
                $scope.result = error;
            });
        }

        function callNotAuthorized() {
            dataservice.notAuthorized().then(function (result) {
                $scope.result = result;
            }, function (error) {
                $scope.result = error;
            });
        }

        function callServerException() {
            dataservice.serverException().then(function (result) {
                $scope.result = result;
            }, function (error) {
                $scope.result = error;
            });
        }

        function callPageNotFound() {
            dataservice.pageNotfound().then(function (result) {
                $scope.result = result;
            }, function (error) {
                $scope.result = error;
            });
        }
    }

})();
