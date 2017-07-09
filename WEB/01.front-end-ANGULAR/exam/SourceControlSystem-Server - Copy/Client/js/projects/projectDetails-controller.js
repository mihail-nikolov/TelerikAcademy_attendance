(function () {
    'use strict';

    function ProjectDetailsController($q, $scope, $routeParams, $route, $location, common, identity, projects, commits) {

        var vm = this;
        vm.identity = identity;
        vm.request = {
            page: 1,
            pageSize: 10
        };

        vm.prevPage = function () {
            if (vm.request.page == 1) {
                return;
            }

            vm.request.page--;
            vm.filterCommits();
        }

        vm.nextPage = function () {
            if (!vm.commits || vm.commits.length == 0) {
                return;
            }

            vm.request.page++;
            vm.filterCommits();
        }

        if (identity.isAuthenticated()) {

            var id = $routeParams.id;

            var commitsPerProject = {};

            commits.getCommitsByProjectId(id)
               .then(function (commits) {
                   vm.commits = commits;
               });

            projects.getById(id)
                .then(function (project) {
                    vm.project = project
                });

            projects.getCollaborators(id)
                .then(function (collaborators) {
                    vm.collaborators = collaborators;
                    var currentUser = identity.getCurrentUser();
                    vm.isCurrentUserCollaborator = common.isArrayContainsValue(collaborators, currentUser.userName);
                });


            vm.addCollaborator = (function (email) {
                projects.addCollaborator(id, '"' + email + '"')
                 .then(function () {
                     $route.reload();
                 });
            });

            vm.filterCommits = function () {
                commits.filterCommits(id, vm.request)
                    .then(function (filteredCommits) {
                        vm.commits = filteredCommits;
                    });
            }
        }
        else {
            $location.path('/unauthorized');
        }
    }

    angular.module('myApp.controllers')
        .controller('ProjectDetailsController', ['$q', '$scope', '$routeParams', '$route', '$location', 'common', 'identity', 'projects', 'commits', ProjectDetailsController])
}());