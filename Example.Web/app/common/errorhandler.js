(function () {
    'use strict';

    angular
        .module('app')
        .factory('errorhandler', errorhandler);

    errorhandler.$inject = ['$modal', 'common'];

    function errorhandler($modal, common) {

        var service = {
            handle: handle
        };

        return service;

        function handle(error) {

            if (error.status === 400 ||
                error.status === 404 /* NotFound behandeln wir mit dem gleichen handler */ ) {
                // BadRequests oder NotFound
                handle400(error);
            }

            if (error.status === 500) {
                handle500(error);
            }
        }

        // Verarbeitet alle 400 - Bad Request error
        // Das können Validierungsfehler sein, oder ItemNotFound etc
        function handle400(error) {

            var validationerrors = [];
            if (error.data.ModelState) {
                // Es ist ein Validation Error
                for (var key in error.data.ModelState) {
                    for (var i = 0; i < error.data.ModelState[key].length; i++) {
                        validationerrors.push(error.data.ModelState[key][i]);
                    }
                }
            }

            var errorMessage = error.data.Message;
            if (error.data.MessageDetail) {
                errorMessage = error.data.MessageDetail; // Ist gesetzt wenn das IncludeErrorDetailPolicy-Property in der Api-Config entsprechend gesetzt ist
            }

            common.$log.error(errorMessage);

            var modalInstance = $modal.open({
                animation: false,
                templateUrl: common.config.mvcRoot + 'error/badrequestdialog',
                controller: 'errordialogcontroller',
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

        // Verarbeitet alle 500 - Internal Server errors
        function handle500(error) {

            // Globaler exception handler. Siehe ApiGlobalExceptionHandler.cs

            var exception = error.data;
            if (exception.Stacktrace) {
                common.$log.error(exception.Stacktrace);
            }

            var modalInstance = $modal.open({
                animation: false,
                templateUrl: common.config.mvcRoot + 'error/internalservererrordialog',
                controller: 'errordialogcontroller',
                windowClass: 'error-dialog',
                resolve: {
                    error: function () {
                        return exception;
                    }
                }
            });
        }
    }
})();