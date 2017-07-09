(function () {
    'use strict';

    function data($http, $q, baseServiceUrl, common, auth, notifier) {

        var authHeader = auth.getAuthorizationHeader();

        function get(url, queryParams) {
            var defered = $q.defer();

            $http.get(baseServiceUrl + url, { params: queryParams, headers: authHeader })
                .then(function (response) {
                    defered.resolve(response.data);
                }, function (responseErr) {
                    var error = common.getErrorMessage(responseErr);
                    notifier.error(error);
                    defered.reject(error);
                });

            return defered.promise;
        }

        function post(url, postData) {
            var deferred = $q.defer();

            $http.post(baseServiceUrl + url, postData, { headers: authHeader })
                .then(function () {
                    deferred.resolve();
                }, function (response) {
                    var errorMessage = common.getErrorMessage(response);
                    notifier.error(errorMessage);
                    deferred.reject(errorMessage);
                });

            return deferred.promise;
        }

        function put(url, postData) {
            var deferred = $q.defer();

            $http.put(baseServiceUrl + url, postData, { headers: authHeader })
                .then(function () {
                    deferred.resolve();
                }, function (response) {
                    console.log(response);
                    var errorMessage = common.getErrorMessage(response);
                    notifier.error(errorMessage);
                    deferred.reject(errorMessage);
                });

            return deferred.promise;
        }

        return {
            get: get,
            post: post,
            put: put
        };
    }

    angular.module('myApp.services')
        .factory('data', ['$http', '$q', 'baseServiceUrl', 'common', 'auth', 'notifier', data]);
}());