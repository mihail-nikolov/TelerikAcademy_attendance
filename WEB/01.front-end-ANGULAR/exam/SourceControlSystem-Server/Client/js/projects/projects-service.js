(function(){
    'use strict';

    function projects(data) {
        var PROJECTS_URL = 'api/projects';
        var PROJECTS_ALL_URL = 'api/projects/all';

        function getPublicProjects() {
            return data.get(PROJECTS_URL);
        }

        function getPrivateProjects() {
            return data.get(PROJECTS_ALL_URL);
        }

        function filterProjects(filters) {
            return data.get(PROJECTS_ALL_URL, filters);
        }

        function createProject(project) {
            return data.post(PROJECTS_URL, project);
        }

        function getById(id) {
            return data.get(PROJECTS_URL + '/' + id);
        }
        
        return {
            getPublicProjects: getPublicProjects,
            createProject: createProject,
            filterProjects: filterProjects,
            getPrivateProjects: getPrivateProjects,
            getById: getById
        }
    }

    angular.module('myApp.services')
        .factory('projects', ['data', projects])
}());