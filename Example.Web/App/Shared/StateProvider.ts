module App.Shared {
    "use strict";

    StateProvider.$inject = ["$locationProvider", "$urlRouterProvider", "$stateProvider"];

    export function StateProvider($locationProvider: ng.ILocationProvider, $urlRouterProvider: ng.ui.IUrlRouterProvider, $stateProvider: ng.ui.IStateProvider) {

        $locationProvider.html5Mode(false).hashPrefix("!");
        // $urlRouterProvider.otherwise("/");

        $stateProvider
            .state("home", <ng.ui.IState>{
                url: "/app",
                templateUrl: "/home/angularapp"
            });
    }

    angular.module("App").config(App.Shared.StateProvider);
}

