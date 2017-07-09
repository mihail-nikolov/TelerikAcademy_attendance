(function () {
    'use strict';

    function RegisterController($scope, $location, notifier, auth) {
        $scope.signup = function (user) {
            auth.signup(user)
                .then(function () {
                    notifier.success('Registration successfull');
                    notifier.success('Use the login form to sign in');
                    $location.path('/');
                }, function (errorResponse) {
                    notifier.error(errorResponse);
                });
        }
    }

    angular.module('myApp.controllers')
        .controller('RegisterController', ['$scope', '$location', 'notifier', 'auth', RegisterController])
}());