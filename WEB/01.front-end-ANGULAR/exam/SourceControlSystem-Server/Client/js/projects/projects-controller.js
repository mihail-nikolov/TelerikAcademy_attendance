(function () {
    'use strict';

    function ProjectsController(projects, licenses, identity) {
        var vm = this;
        vm.identity = identity;
        vm.request = {
            page: 1,
            pageSize:10
        };

        vm.prevPage = function () {
            if (vm.request.page == 1) {
                return;
            }

            vm.request.page--;
            vm.filterProjects();
        }

        vm.nextPage = function () {
            if (!vm.projects || vm.projects.length == 0) {
                return;
            }

            vm.request.page++;
            vm.filterProjects();
        }

        vm.filterProjects = function () {
            projects.filterProjects(vm.request)
                .then(function (filteredProjects) {
                    vm.projects = filteredProjects;
                });
        }

        if (identity.isAuthenticated()) {
            projects.getPrivateProjects()
            .then(function (privateProjects) {
                vm.projects = privateProjects;
            });
        }
        else {
            projects.getPublicProjects()
            .then(function (publicProjects) {
                vm.projects = publicProjects;
            });
        }
    }

    angular.module('myApp.controllers')
        .controller('ProjectsController', ['projects', 'licenses', 'identity', ProjectsController]);
}());