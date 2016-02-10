/// <reference path="../_mydata.module.ts" />
module App.Modules.MyData.Controllers {
    "use strict";

    export class MyDataItemsController {

        Items: Array<Core.MyDataItem>;

        static $inject: string[] = ["MyDataService"];

        constructor(private service: App.Modules.MyData.Services.IMyDataService) {
            this.activate();
        }

        activate() {

            this.service.getDataItems().success(f => {
                this.Items = f.Items;
            });
        }
    }

    angular.module("App.MyData").controller("MyDataItemsController", MyDataItemsController);
}