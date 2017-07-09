(function () {
    'use strict';

    function projects($q, notifier, common, data) {

        var publicProjects;
        var projectsUrl = 'api/projects'

        function getPublicProjects() {
            if (publicProjects) {
                return $q.when(publicProjects);
            }
            else {
                return data.get(projectsUrl)
                    .then(function (projects) {
                        publicProjects = projects;
                        return projects;
                    }, function (response) {
                        var errorMessage = common.getErrorMessage(response);
                        notifier.error(errorMessage);
                    });
            }
        }

        function createProject(project) {
            return data.post(projectsUrl + '/add', project);
        }

        function getAllProjects() {
            return data.get(projectsUrl + '/all');
        }

        //could be in 1 function
        function filterProjects(filters) {
            return data.get(projectsUrl + '/all', filters);
        }

        function getById(id) {
            return data.get(projectsUrl + '/' + id);
        }

        function getCollaborators(id) {
            return data.get(projectsUrl + '/collaborators/' + id);
        }

        function addCollaborator(id, email) {
            return data.put(projectsUrl + '/' + id, email);
        }

        return {
            getPublicProjects: getPublicProjects,
            createProject: createProject,
            getAllProjects: getAllProjects,
            getById: getById,
            getCollaborators: getCollaborators,
            addCollaborator: addCollaborator,
            filterProjects: filterProjects
        };
    }

    angular.module('myApp.services')
        .factory('projects', ['$q', 'notifier', 'common', 'data', projects]);
}())