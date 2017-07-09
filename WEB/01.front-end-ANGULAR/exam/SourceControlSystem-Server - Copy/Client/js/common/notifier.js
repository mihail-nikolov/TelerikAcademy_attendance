(function () {
    'use strict';

    function notifier(toastr) {
        function success(msg) {
            toastr.success(msg);
        }

        function error(msg) {
            toastr.error(msg);
        }

        return {
            success: success,
            error: error
        };
    }
   
    angular.module('myApp.services')
        .factory('notifier', ['toastr', notifier]);
}());