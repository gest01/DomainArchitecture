/// <reference path="../../../app.module.ts" />
module App.Modules.MyData.Config  {
    "use strict";

    StateProvider.$inject = ["$stateProvider"];

    export function StateProvider($stateProvider: ng.ui.IStateProvider) {

        $stateProvider
            .state("mydata", <ng.ui.IState>{
                url: "/mydata",
                views: {
                    "": {
                        templateUrl: "/mydata/index",
                        controller: Modules.MyData.Controllers.MyDataController,
                        controllerAs: "MyDataController"
                    },
                    "@mydata": {
                        templateUrl: "/mydata/items",
                        controller: Modules.MyData.Controllers.MyDataController,
                        controllerAs: "MyDataController"
                    }
                }
            })

            .state("mydata.new", {
                url: "/new",
                templateUrl: "/mydata/detail",
                controller: Modules.MyData.Controllers.MyDataController,
                controllerAs: "MyDataController"
            })

            .state("mydata.edit", {
                url: "/edit/:Id",
                templateUrl: "/mydata/detail",
                controller: Modules.MyData.Controllers.MyDataController,
                controllerAs: "MyDataController"
            });
    }

    angular.module("App.MyData").config(Config.StateProvider);
}

