(function () {
    'use strict';

    angular
        .module('app')
        .factory('contextservice', contextservice);

    contextservice.$inject = ['$http', '$resource', 'config'];

    function contextservice($http, $resource, config) {

        var service = {
            getcontext: getcontext
        };

        return service;

		// usercontext and resouces
        function getcontext() {
            return $http.get(config.apiRoot + '/user/context').then(function (response) {
                return response.data;
            });
        }
    }
})();