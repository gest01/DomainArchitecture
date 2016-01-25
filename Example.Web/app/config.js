(function () {
    'use strict';

    var app = angular.module('app');

    app.config(["$provide", function ($provide) {

        var apiRoot = angular.element("#apiRoot").attr("href")
        var webRoot = angular.element("#webRoot").attr("href")

        $provide.constant('config', {
            apiRoot: apiRoot,
            webRoot: webRoot
        });
    }]);


    // Register global http exception handler

    app.factory('errorHttpInterceptor', errorHttpInterceptor);

    errorHttpInterceptor.$inject = ['$q',  '$rootScope'];

    function errorHttpInterceptor($q, $rootScope) {

        return {
            responseError: function responseError(rejection) {

                $rootScope.handleError(rejection);

                return $q.reject(rejection);
            }
        };
    }


    app.config(['$httpProvider', function ($httpProvider) {
        $httpProvider.interceptors.push('errorHttpInterceptor');
    }]);


})();