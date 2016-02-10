/// <reference path="../_mydata.module.ts" />
module App.Modules.MyData.Services {
    "use strict";

    export interface IMyDataService {
        getDataItems: () => ng.IHttpPromise<Core.MyDataResult>;
        getDataItem: (id: number) => ng.IHttpPromise<Core.MyDataItem>
    }

    MyDataService.$inject = ["$http", "HttpConfig"];

    function MyDataService($http: ng.IHttpService, config: App.HttpConfig): IMyDataService {
        var service: IMyDataService = {
            getDataItems: getDataItems,
            getDataItem: getDataItem
        };

        return service;

        function getDataItem(id: number): ng.IHttpPromise<Core.MyDataItem> {
            return $http.get(config.toApiUrl('/mydata/' + id));
        }

        function getDataItems(): ng.IHttpPromise<Core.MyDataResult> {
            return $http.get(config.toApiUrl('/mydata/items'));
        }
    }


    angular.module("App.MyData").factory("MyDataService", MyDataService);
}