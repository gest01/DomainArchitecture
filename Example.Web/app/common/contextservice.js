(function () {
    'use strict';

    angular
        .module('app')
        .factory('contextservice', contextservice);

    contextservice.$inject = ['$http', 'config'];

    function contextservice($http, config) {

        var service = {
            getcontext: getcontext
        };

        return service;

        function getcontext() {
            return $http.get(config.apiRoot + '/user/context').then(function (response) {
                return response.data;
            });
        }
    }
})();