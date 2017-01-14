(function () {
    'use strict';

    function CommitsController(commits, identity) {
        var vm = this;
        vm.identity = identity;
        commits.getPublicCommits()
            .then(function (publicCommits) {
                vm.publicCommits = publicCommits;
            });
    }

    angular.module('myApp.controllers')
        .controller('CommitsController', ['commits', 'identity', CommitsController]);
}());