(function () {
    'use strict';

    function CommitsController(identity, commits) {

        var vm = this;
        vm.identity = identity;

        if (!identity.isAuthenticated()) {
            commits.getPublicCommits()
               .then(function (commits) {
                   vm.commits = commits;
               });
        }
    }

    angular.module('myApp.controllers')
        .controller('CommitsController', ['identity', 'commits', CommitsController])
}());