(function () {
    'use strict';

    function drivers(data) {

        function getPublicDriversInfo() {
            return data.get('/api/drivers')
        }

        return {
            getPublicDriversInfo: getPublicDriversInfo
        }
    }

    angular.module('myApp.services')
        .factory('drivers', ['data', drivers]);

}());