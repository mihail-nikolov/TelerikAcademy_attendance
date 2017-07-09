(function () {
    'use strict';

    function auth($http, $q, baseServiceUrl, common, identity) {
        var usersUrl = baseServiceUrl + 'api/account/';

        function signup(user) {
            var deferred = $q.defer();

            $http.post(usersUrl + 'register', user)
                .then(function () {
                    deferred.resolve();
                }, function (response) {
                    var error = common.getErrorMessage(response);
                    deferred.reject(error);
                });

            return deferred.promise;
        }

        function login(user) {
            var deferred = $q.defer();

            // user object to form-encoded including user['grant_type'] = 'password';
            var requestString = 'username=' + user.username + '&password=' + user.password + '&grant_type=password';

            var headersObject = { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } };

            $http.post(baseServiceUrl + 'token', requestString, headersObject)
                .then(function (response) {
                    if (response.data['access_token']) {
                        var user = response.data;
                        identity.setCurrentUser(user);
                        deferred.resolve(true);
                    }
                    else {
                        deferred.resolve(false);
                    }
                    deferred.resolve();
                });

            return deferred.promise;
        }

        function logout() {
            var deferred = $q.defer();

            var headers = this.getAuthorizationHeader();

            $http.post(usersUrl + 'logout', {}, { headers: headers })
                .then(function (response) {
                    identity.setCurrentUser(undefined);
                    deferred.resolve();
                });

            return deferred.promise;
        }

        function getAuthorizationHeader() {
            var header = {}

            if (identity.isAuthenticated()) {
                var user = identity.getCurrentUser();
                header = { 'Authorization': 'Bearer ' + user['access_token'] };
            }

            return header;
        }

        return {
            signup: signup,
            login: login,
            logout: logout,
            getAuthorizationHeader, getAuthorizationHeader
        };
    }

    angular.module('myApp.services')
        .factory('auth', ['$http', '$q', 'baseServiceUrl', 'common', 'identity', auth]);
}());