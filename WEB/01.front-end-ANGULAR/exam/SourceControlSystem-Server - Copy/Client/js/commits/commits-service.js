(function () {
    'use strict';

    function commits($q, notifier, common, data) {

        var publicCommits;
        var commitsUrl = 'api/commits'

        function getPublicCommits() {
            if (publicCommits) {
                return $q.when(publicCommits);
            }
            else {
                return data.get(commitsUrl)
                    .then(function (commits) {
                        publicCommits = commits;
                        return commits;
                    }, function (response) {
                        var errorMessage = common.getErrorMessage(response);
                        notifier.error(errorMessage);
                    });
            }
        }

        function filterCommits(projectId, filters) {
            return data.get(commitsUrl + '/byproject/' + projectId, filters);
        }

        function addCommit(commit) {
            return data.post(commitsUrl, commit);
        }

        function getCommitsByProjectId(projectId) {
            return data.get(commitsUrl + '/byproject/' + projectId);
        }

        function getById(id) {
            return data.get(commitsUrl + '/' + id);
        }

        return {
            addCommit: addCommit,
            getCommitsByProjectId: getCommitsByProjectId,
            getPublicCommits: getPublicCommits,
            getById: getById,
            filterCommits: filterCommits
        };
    }

    angular.module('myApp.services')
        .factory('commits', ['$q', 'notifier', 'common', 'data', commits]);
}())