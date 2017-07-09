(function () {
    'use strict';

    function CreateProjectController($location, auth, identity, projects, licenses) {

        var vm = this;
        vm.identity = identity;
        
        licenses.getAll()
            .then(function (allLicenses) {
                vm.allLicenses = allLicenses;
            });

        vm.createProject = function (project) {
            projects.createProject(project)
                .then(function () {
                    $location.path('/');
                });
        }
    }

    angular.module('myApp.controllers')
        .controller('CreateProjectController', ['$location', 'auth', 'identity', 'projects', 'licenses', CreateProjectController])
}());