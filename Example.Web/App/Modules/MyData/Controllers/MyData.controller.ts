/// <reference path="../_mydata.module.ts" />
module App.Modules.MyData.Controllers {
    "use strict";

    export class MyDataController {

        static $inject: string[] = ["MyDataService", "$stateParams"];

        Item: Core.MyDataItem;

        constructor(private service: App.Modules.MyData.Services.IMyDataService, private $stateParams: ng.ui.IStateParamsService) {

            if ($stateParams['Id']) {
                var id = parseInt($stateParams['Id']);

                this.service.getDataItem(id).success(f => {
                    this.Item = f;
                });
            }
        }
    }

    angular.module("App.MyData").controller("MyDataController", MyDataController);
}