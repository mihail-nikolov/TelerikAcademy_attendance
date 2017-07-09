(function () {
    'use strict';

    function CommitDetailsController($routeParams, $location, identity, commits) {

        var vm = this;
        vm.identity = identity;

        if (identity.isAuthenticated()) {
            var id = $routeParams.id;

            commits.getById(id)
                .then(function (commit) {
                    vm.commit = commit
                });
        }
        else {
            $location.path('/unauthorized');
        }
    }

    angular.module('myApp.controllers')
        .controller('CommitDetailsController', ['$routeParams', '$location', 'identity', 'commits', CommitDetailsController])
}());