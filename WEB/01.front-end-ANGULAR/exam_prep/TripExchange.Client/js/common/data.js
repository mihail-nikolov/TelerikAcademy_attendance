(function () {

    'use strict';

    function data($http, $q, notifier, baseServiceUrl, authorization) {

        function get(url, queryParams) {
            var deferred = $q.defer();
            var authHeader= authorization.getAuthorizationHeader();
                $http.get(baseServiceUrl + '/' + url, { params: queryParams, headers: authHeader })
                .then(function (response) {
                    deferred.resolve(response.data);
                }
                , function (error) {
                    notifier.error(error);
                    deferred.reject(error);
                });

            return deferred.promise;
        }

        function post(url, postData) {
            var deferred = $q.defer();
            var authHeader = authorization.getAuthorizationHeader();

            $http.post(baseServiceUrl + '/' + url, postData, { headers: authHeader })
                .then(function (response) {
                    deferred.resolve(response.data);
                }
                , function (error) {
                    notifier.error(error);
                    deferred.reject(error);
                });

            return deferred.promise;
        }

        function put(url, queryParams) {
            throw new Error("not implement")
        }

        return {
            get: get,
            post: post,
            put: put
        }
    }

    angular.module('myApp.services')
        .factory('data', ['$http', '$q', 'notifier', 'baseServiceUrl', 'authorization', data])
}());