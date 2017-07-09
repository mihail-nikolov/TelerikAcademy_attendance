(function () {
    'use strict';

    function ProjectsController(identity, projects) {

        var vm = this;
        vm.identity = identity;
        vm.request = {
            page: 1,
            pageSize: 10
        };
 //------------------filtering
        vm.filterProjects = function () {
            projects.filterProjects(vm.request)
                .then(function (filteredProjects) {
                    vm.projects = filteredProjects;
                    //resetRequest();
                });
        }

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

        function resetRequest() {
            vm.request = {
                page: 1,
                pageSize: 10
            };
        }
//-----------------------------------------
        if (identity.isAuthenticated()) {
            projects.getAllProjects()
                .then(function (projects) {
                    vm.projects = projects;
                });
        }
        else {
            projects.getPublicProjects()
                .then(function (projects) {
                    vm.projects = projects;
                });
        }
    }

    angular.module('myApp.controllers')
        .controller('ProjectsController', ['identity', 'projects', ProjectsController])
}());