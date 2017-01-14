(function () {
    'use strict';

    function commits(data) {
        var COMMITS_URL = 'api/commits';
        function getPublicCommits() {
            return data.get(COMMITS_URL);
        }
        function createCommit(commit) {
            return data.post(COMMITS_URL, commit);
        }
        return {
            getPublicCommits: getPublicCommits,
            createCommit:createCommit
        }
    }

    angular.module('myApp.services')
        .factory('commits', ['data', commits])
}());