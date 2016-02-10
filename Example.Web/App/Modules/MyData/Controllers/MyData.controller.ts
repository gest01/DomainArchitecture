/// <reference path="../_mydata.module.ts" />
module App.Modules.MyData.Controllers {
    "use strict";

    export class MyDataController {

        //static $inject: string[] = [""];

        constructor() {
            this.activate();
        }

        activate() {

        }
    }

    angular.module("App.MyData").controller("MyDataController", MyDataController);
}