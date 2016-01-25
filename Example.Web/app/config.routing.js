//(function () {
//    'use strict';

//    var module = angular.module('app');

//    module.config(['$stateProvider', '$urlRouterProvider', 'config', function ($stateProvider, $urlRouterProvider, config) {

//        $urlRouterProvider.otherwise("/app");

//        $stateProvider

//            .state('home', {
//                url: '/app',
//                templateUrl: config.mvcRoot + '/home/apphome'
//            })

//            .state('activity', {
//                url: '/activity',
//                views: {
//                    '': { templateUrl: config.mvcRoot + '/view1/index' },
//                    '@activity': { templateUrl: config.mvcRoot + 'view1/overview', controller: 'democontroller' }
//                }
//            });
//    }]);
//})();