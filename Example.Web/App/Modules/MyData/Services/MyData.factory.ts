module App.Modules.MyData.Services {
    "use strict";

    export interface IMyDataService {
        getData: () => string;
    }

    MyDataService.$inject = ["$http"];

    function MyDataService($http: ng.IHttpService): IMyDataService {
        var service: IMyDataService = {
            getData: getData
        };

        return service;

        function getData() {
            return "";
        }
    }


    angular.module("App.MyData").factory("MyDataService", MyDataService);
}