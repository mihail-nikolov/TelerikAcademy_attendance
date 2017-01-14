(function () {
    'use strict';

    function CreateProjectController($location, licenses, projects) {
        var vm = this;

        licenses.getAll()
            .then(function (allLicenses) {
                vm.allLicenses = allLicenses;
            });
        vm.createProject = function (newProject) {
            projects.createProject(newProject)
                .then(function (createdProject) {
                    $location.path('/projects');
                });
        }
    }

    angular.module('myApp.controllers')
        .controller('CreateProjectController', ['$location', 'licenses', 'projects', CreateProjectController]);
}());