module App.Modules.MyData.Controllers {
    "use strict";

    export class MyDataController {

        static $inject: string[] = ["MyDataService"];

        constructor(private service: App.Modules.MyData.Services.IMyDataService) {
            this.activate();
        }

        activate() {

        }
    }

    angular.module("App.MyData").controller("MyDataController", MyDataController);
}