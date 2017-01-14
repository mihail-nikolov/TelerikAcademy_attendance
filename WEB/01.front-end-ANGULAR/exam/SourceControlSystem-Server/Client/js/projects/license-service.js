(function() {
    'use strict';

    function licenses(data) {
        function getAll() {
            return data.get('api/licenses');
        }

        return {
            getAll: getAll
        }
    }

    angular.module('myApp.services')
        .factory('licenses', ['data', licenses])
}());