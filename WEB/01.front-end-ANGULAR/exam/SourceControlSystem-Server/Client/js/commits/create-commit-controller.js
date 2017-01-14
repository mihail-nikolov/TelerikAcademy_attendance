(function () {
    'use strict';

    function CreateCommitController($location, commits, projects) {
        var vm = this;

        projects.getPrivateProjects()
            .then(function (privateProjects) {
                vm.projects = privateProjects;
            });

        vm.createCommit = function (newCommit) {
            commits.createCommit(newCommit)
                .then(function (createdCommit) {
                    $location.path('/commits');
                });
        }
    }

    angular.module('myApp.controllers')
        .controller('CreateCommitController', ['$location', 'commits','projects',  CreateCommitController]);
}());