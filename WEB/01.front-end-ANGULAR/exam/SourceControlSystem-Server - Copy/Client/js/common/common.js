(function () {
    'use strict';

    function common() {

        function getErrorMessage(response) {
            var error = response.data.ModelState;
            var errorMessage = '';
            if (error && error[Object.keys(error)[0]][0]) {
                errorMessage = error[Object.keys(error)[0]][0];
            }
            else {
                errorMessage = response.data.Message;
            }
            return errorMessage;
        }

        function isArrayContainsValue(array, value) {
            for (var i = 0; i < array.length; i++) {
                if (array[i] === value) {
                    return true;
                }
            }
            return false;
        }

        return {
            getErrorMessage: getErrorMessage,
            isArrayContainsValue: isArrayContainsValue
        };
    }

    angular.module('myApp.services')
        .factory('common', [common]);
}());