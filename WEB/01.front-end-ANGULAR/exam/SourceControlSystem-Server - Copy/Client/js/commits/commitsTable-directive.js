(function () {
    'use strict';

    function commitsTable() {
        return {
            restrict: 'A',
            templateUrl: 'views/directives/commits-directive.html'
        }
    }

    angular.module('myApp.directives')
        .directive('commitsTable', [commitsTable]);
}());