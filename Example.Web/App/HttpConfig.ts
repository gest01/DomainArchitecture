module App {
    "use strict";
    
    export class HttpConfig {

        WebRoot: string;
        ApiRoot: string;

        constructor() {

            this.WebRoot = angular.element("#webRoot").attr("href");
            this.ApiRoot = angular.element("#apiRoot").attr("href");
        }

        toApiUrl(segment: string): string {
            return this.ApiRoot + segment;
        }

        toWebUrl(segment: string): string
        {
            return this.WebRoot + segment;
        }

    }

    angular.module("App").service("HttpConfig", HttpConfig);
}