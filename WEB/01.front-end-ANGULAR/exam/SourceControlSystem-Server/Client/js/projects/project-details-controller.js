(function () {
    'use strict';

    function ProjectDetailsController($routeParams, projects, identity) {
        var vm = this;
        var id = $routeParams.id;
        vm.identity = identity;

        projects.getById(id)
            .then(function (project) {
                vm.project = project;
                console.log(vm.projects);
            });
    }

    angular.module('myApp.controllers')
        .controller('ProjectDetailsController', ['$routeParams', 'projects', 'identity', ProjectDetailsController])
}());