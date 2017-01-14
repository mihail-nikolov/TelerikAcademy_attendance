(function () {
    'use strict';

    function config($routeProvider) {
        $routeProvider
            .when('/', {
                templateUrl: 'views/partials/home.html',
                controller: 'homeController',
                controllerAs: 'vm'
            })
            .when('/trips', {
                templateUrl: 'views/partials/trips.html',
                controller: 'tripsController',
                controllerAs: 'vm'
            })
            .when('/trips/create', {
                templateUrl: 'views/partials/trip-create.html',
                controller: 'tripsCreateController',
                controllerAs: 'vm'
            })
            .when('/unauthorized', {
                template: '<h1>YOU ARE NOT AUTHORIZED</h1>'
            })
            .when('/register', {
                templateUrl: 'views/partials/register.html',
                controller: 'SignUpCtrl'
            })
            .otherwise({ redirectTo: '/' });
    }

    angular.module('myApp.services', []);
    angular.module('myApp.directives', []);
    angular.module('myApp.controllers', ['myApp.services']);
    angular.module('myApp', ['ngRoute', 'ngCookies', 'kendo.directives', 'myApp.controllers', 'myApp.directives'])
        .config(['$routeProvider', config])
        .value('toastr', toastr)
        .constant('baseServiceUrl', 'http://spa2014.bgcoder.com');
}());