module App {
    "use strict";

    export interface IDataService {
        pageNotfound: () => ng.IHttpPromise<any>;
        serverException: () => ng.IHttpPromise<any>;
        notAuthorized: () => ng.IHttpPromise<any>;
        badRequest: (item: Core.MyDataItem) => ng.IHttpPromise<any>;
        getData: () => ng.IHttpPromise<Core.MyDataResult>;
    }

    DataService.$inject = ["$http", "HttpConfig"];

    function DataService($http: ng.IHttpService, config:App.HttpConfig): IDataService {
        var service: IDataService = {
            pageNotfound: pageNotfound,
            serverException: serverException,
            notAuthorized: notAuthorized,
            badRequest: badRequest,
            getData: getData
        };

        return service;

        function getData(): ng.IHttpPromise<Core.MyDataResult> {
            return $http.get(config.toApiUrl('/demo/myitem'));
        }

        function badRequest(item: Core.MyDataItem): ng.IHttpPromise<any> {
            return $http.post(config.toApiUrl('/demo/myitem'), item);
        }

        function notAuthorized(): ng.IHttpPromise<any> {
            return $http.get(config.toApiUrl('/demo/notauthorized'));
        }

        function serverException() : ng.IHttpPromise<any> {
            return $http.get(config.toApiUrl("/demo/exception")).success(f => {
                return f;
            });
        }

        function pageNotfound(): ng.IHttpPromise<any> {
            return $http.get(config.toApiUrl("/hehehe")).success(f => {
                return f;
            });
        }
    }


    angular.module("App").factory("DataService", DataService);
}