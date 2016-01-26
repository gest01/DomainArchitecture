(function () {
    'use strict';

    angular
        .module('app')
        .factory('dataservice', dataservice);

    dataservice.$inject = ['$http', 'config'];

    function dataservice($http, config) {

        var service = {
            pageNotfound: pageNotfound,
            serverException: serverException,
            notAuthorized: notAuthorized,
            badRequest: badRequest,
            getData: getData
        };

        return service;

        function badRequest(myitem) {
            return $http.post(config.apiRoot + '/demo/myitem', myitem).then(function (response) {
                return response.data;
            });
        }

        function pageNotfound() {
            return $http.get(config.apiRoot + '/demo/heheheheh').then(function (response) {
                return response.data;
            });
        }

        function serverException() {
            return $http.get(config.apiRoot + '/demo/exception').then(function (response) {
                return response.data;
            });
        }

        function notAuthorized() {
            return $http.get(config.apiRoot + '/demo/notauthorized').then(function (response) {
                return response.data;
            });
        }

        function getData() {
            return $http.get(config.apiRoot + '/demo').then(function (response) {
                return response.data;
            });
        }
    }
})();