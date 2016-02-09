module App.Shared {
    "use strict";

    setupErrorHandler.$inject = ["$q", "ErrorHandler"];
    function setupErrorHandler($q: ng.IQService, handler: ErrorHandler): ng.IHttpInterceptor {
        var service: ng.IHttpInterceptor = {
            responseError: handleResponseError,
        };

        return service;

        function handleResponseError(rejection: any): any {
            handler.handleError(rejection);
            return $q.reject(rejection);
        }
    }


    angular.module("App").config(['$httpProvider', function ($httpProvider: ng.IHttpProvider) {
        $httpProvider.interceptors.push(setupErrorHandler);
    }]);
}