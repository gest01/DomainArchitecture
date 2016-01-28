module App.Shared {
    "use strict";
    
    export class ErrorHandler  {

        static $inject: string[] = ["$injector", "HttpConfig", "$log"];

        constructor(private $injector: ng.auto.IInjectorService, private config : App.HttpConfig, private $log : ng.ILogService) {

        }

        handleError(error: any) {

            // HACK : Unable to inject IModalService through construcotr --> circular dependency
            var modal = this.$injector.get<ng.ui.bootstrap.IModalService>("$uibModal");

            if (error.status === 400 || /* Bad Request */ 
                error.status === 404    /* NotFound */) {
                this.handle400(error, modal);
            }

            if (error.status === 500) {
                this.handle500(error, modal);
            }
        }

        handle500(error: any, modal: ng.ui.bootstrap.IModalService)
        {
            var exception = error.data;
            if (exception.Stacktrace) {
                this.$log.error(exception.Stacktrace);
            }

            var modalInstance = modal.open({
                animation: false,
                templateUrl: this.config.toWebUrl('error/internalservererrordialog'),
                controller: ErrorDialogController,
                controllerAs: 'errorController',
                windowClass: 'error-dialog',
                resolve: {
                    error: function () {
                        return exception;
                    }
                }
            });
        }

        handle400(error: any, modal: ng.ui.bootstrap.IModalService)
        {
            var validationerrors = [];
            if (error.data.ModelState) {
                // Validation Error
                for (var key in error.data.ModelState) {
                    for (var i = 0; i < error.data.ModelState[key].length; i++) {
                        validationerrors.push(error.data.ModelState[key][i]);
                    }
                }
            }

            var errorMessage = error.data.Message;
            if (error.data.MessageDetail) {
                errorMessage = error.data.MessageDetail; // Set when IncludeErrorDetailPolicy-Property in Api-Config is set to IncludeErrorDetailPolicy.Always
            }

            this.$log.error(errorMessage);

            var modalInstance = modal.open({
                animation: false,
                templateUrl: this.config.toWebUrl('error/badrequestdialog'),
                controller: ErrorDialogController,
                controllerAs: 'errorController',
                windowClass: 'warning-dialog',
                resolve: {
                    error: function () {
                        return {
                            ErrorMessage: errorMessage,
                            ValidationErrors: validationerrors
                        };
                    }
                }
            });
        }
    }

    angular.module("app").service("ErrorHandler", ErrorHandler);


}