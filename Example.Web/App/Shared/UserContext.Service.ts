module App.Shared {
    "use strict";

    export class UserContext {
        User: User;
    }

    export class User {
        Id: number;
        DisplayName: string;
    }

    export interface IUserContextService {
        getContext: () => ng.IHttpPromise<UserContext> ;
    }
    
    class UserContextService implements IUserContextService {
        static $inject: string[] = ["$http", "HttpConfig"];

        constructor(private $http: ng.IHttpService, private config:App.HttpConfig) {
        }

        getContext(): ng.IHttpPromise<UserContext> {
            return this.$http.get<UserContext>(this.config.toApiUrl("/user/context")).success(f => {
                return f;
            });
        }
    }

    angular.module("app").service("UserContextService", UserContextService);
}