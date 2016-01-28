module App.Shared {
    "use strict";

    export class ErrorDialogController {

        static $inject: string[] = ["error", "$uibModalInstance"];

        ErrorMessage: string;
        DisplayMessage: string;
        Stacktrace: string;
        ValidationErrors: Array<string>;

        constructor(private error: any, private modalinstance: ng.ui.bootstrap.IModalServiceInstance)
        {
            // Note : ErrorObject is built by ApiGlobalExceptionHandler.cs

            this.ErrorMessage = error.ErrorMessage;

            if (error.DisplayMessage) {
                this.DisplayMessage = error.DisplayMessage;
            }

            if (error.Stacktrace) {
                this.Stacktrace = error.Stacktrace;
            }

            if (error.ValidationErrors) {
                this.ValidationErrors = error.ValidationErrors;
            }
        }

        cancel() {
            this.modalinstance.dismiss('cancel');
        }
    }

    angular.module("app").controller("ErrorDialogController", ErrorDialogController);
}