module App {
    "use strict";

    export class ShellController {

        title: string;
        usercontext: App.Shared.UserContext;
        result: any;

        static $inject: string[] = ["DataService", "UserContextService"];

        constructor(private dataservice: App.IDataService, private user: App.Shared.IUserContextService) {
            this.activate();
        }

        activate() {

            this.title = "AngularJS App by TypeScript";
            this.user.getContext().success(f => {
                this.usercontext = f;
            }).error(error => {
                this.result = error;
            });

        }

        callSuccess() {
            this.dataservice.getData().success(f => {
                this.result = f;
            }).error(error => {
                this.result = error;
            });
        }

        callBadRequest()
        {
            var item = new Core.MyDataItem();
            item.Id = 2342;
            item.Name = "Hello World";

            this.dataservice.badRequest(item).success(f => {
                this.result = f;
            }).error(error => {
                this.result = error;
            });

        }

        callNotAuthorized()
        {
            this.dataservice.notAuthorized().success(f => {
                this.result = f;
            }).error(error => {
                this.result = error;
            });
        }

        callServerException()
        {
            this.dataservice.serverException().success(f => {
                this.result = f;
            }).error(error => {
                this.result = error;
            });
        }

        callPageNotFound() {

            this.dataservice.pageNotfound().success(f => {
                this.result = f;
            }).error(f => {
                this.result = f;
            });
        }
    }

    angular.module("App").controller("shellcontroller", ShellController);
}