(function () {
    'use strict';

    function projectsTable() {
        return {
            restrict: 'A',
            templateUrl: 'views/directives/projects-directive.html'
        }
    }

    angular.module('myApp.directives')
        .directive('projectsTable', [projectsTable]);
}());