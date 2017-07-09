(function () {
    'use strict';

    function AddCommitController($location, $routeParams, auth, identity, commits, projects) {

        var vm = this;
        vm.identity = identity;

        if (identity.isAuthenticated()) {
            var id = $routeParams.id;
            var commit = {};
            commit.projectId = id;
            vm.commit = commit;

            projects.getById(id)
                .then(function (project) {
                    vm.project = project;
                });

            vm.addCommit = function (commit) {
                commits.addCommit(commit)
                    .then(function () {
                        $location.path('/projects/' + id);
                    });
            }
        }
        else {
            $location.path('/unauthorized');
        }
    }

    angular.module('myApp.controllers')
        .controller('AddCommitController', ['$location', '$routeParams', 'auth', 'identity', 'commits', 'projects', AddCommitController])
}());