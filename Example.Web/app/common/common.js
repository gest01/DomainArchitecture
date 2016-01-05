(function () {
    'use strict';

    angular
        .module('app')
        .factory('common', common);

    common.$inject = ['$filter', '$rootScope', '$state', '$log', 'config'];

    function common($filter, $rootScope, $state, $log, config) {
        
        var usercontext = {};
        var resourceStrings = {};

        var service = {

            // Angular Services
            $rootScope: $rootScope,
            $filter: $filter,
            $state: $state,
            $log: $log,

            // Properties
            usercontext: usercontext,
            resourceStrings: resourceStrings,
            config: config,

            // Functions
            broadcast: broadcast,
        };

        return service;

        function broadcast(evt) {
            $rootScope.$broadcast(evt);
        }
    
    }
})();