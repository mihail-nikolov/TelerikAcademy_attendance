(function () {
    'use strict';

    function LoginController($scope, $location, notifier, auth, identity) {

        $scope.identity = identity;

        $scope.login = function (user, loginForm) {
            if (loginForm.$valid) {
                auth.login(user)
                .then(function (success) {
                    if (success) {
                        notifier.success('login successfull');
                        $scope.loginForm.$setPristine();
                        $location.path('/');
                    }
                    else {
                        notifier.error(errorResponse);
                    } 
                }, function () { notifier.error('error login'); });
            }
            else {
                notifier.error('Username and password are required fields!')
            }
        }

        $scope.logout = function(){
            auth.logout()
                .then(function () {
                    notifier.success('succesful logout');
                    if ($scope.user) {
                        $scope.user.email = 'authorization' ;
                        $scope.user.username = '';
                        $scope.user.password = '';
                    }
                    $scope.loginForm.$setPristine();
                    $location.path('/');
                },  function () { notifier.error('error logout'); });
        }
    }

    angular.module('myApp.controllers')
        .controller('LoginController', ['$scope', '$location', 'notifier', 'auth', 'identity', LoginController])
}());