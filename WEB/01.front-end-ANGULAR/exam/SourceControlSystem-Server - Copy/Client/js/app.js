(function () {
    'use strict';

    function config($routeprovider) {
        var PartialsPrefix = 'views/partials/';
        var ControllerAsViewModel = 'vm';

        $routeprovider
            .when('/', {
                templateUrl: PartialsPrefix + 'home/home.html',
                controller: 'HomeController',
                controllerAs: ControllerAsViewModel
            })
            .when('/unauthorized', {
                template: '<h1 class="text-center">YOU ARE NOT AUTHORIZED!</h1>'
            })
            .when('/register', {
                templateUrl: PartialsPrefix + 'identity/register.html',
                controller: 'RegisterController',
                controllerAs: ControllerAsViewModel
            })
            .when('/login', {
                templateUrl: PartialsPrefix + 'identity/login.html',
                controller: 'LoginController',
                controllerAs: ControllerAsViewModel
            })
            .when('/projects', {
                templateUrl: PartialsPrefix + 'projects/all-projects.html',
                controller: 'ProjectsController',
                controllerAs: ControllerAsViewModel
            })
            .when('/projects/add', {
                templateUrl: PartialsPrefix + 'projects/create-project.html',
                controller: 'CreateProjectController',
                controllerAs: ControllerAsViewModel
            })
            .when('/projects/:id', {
                templateUrl: PartialsPrefix + 'projects/project-details.html',
                controller: 'ProjectDetailsController',
                controllerAs: ControllerAsViewModel
            })
            .when('/projects/:id/addcommits', {
                templateUrl: PartialsPrefix + 'commits/add_commit.html',
                controller: 'AddCommitController',
                controllerAs: ControllerAsViewModel
            })
            .when('/commits/:id', {
                templateUrl: PartialsPrefix + 'commits/commit-details.html',
                controller: 'CommitDetailsController',
                controllerAs: ControllerAsViewModel
            })
            .when('/commits', {
                templateUrl: PartialsPrefix + 'commits/all-commits.html',
                controller: 'CommitsController',
                controllerAs: ControllerAsViewModel
            })
            .otherwise({ redirectTo: '/' });
    }

    angular.module('myApp.services', []);
    angular.module('myApp.directives', []);
    angular.module('myApp.controllers', ['myApp.services']);
    angular.module('myApp.filters', []);
    angular.module('myApp', ['ngRoute', 'ngCookies', 'myApp.controllers', 'myApp.directives', 'myApp.filters', 'kendo.directives'])
       .config(['$routeProvider', config])
       .value('toastr', toastr)
       .constant('baseServiceUrl', 'http://localhost:42252/');
}());