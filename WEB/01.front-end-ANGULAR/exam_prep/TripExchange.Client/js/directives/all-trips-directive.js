(function () {
    'use strict';
    
    function allTrips() {
        return {
            restrcit:'A',
            templateUrl:'views/partials/all_trips_directive.html'
        }
    }

    angular.module('myApp.directives')
        .directive('allTrips', [allTrips])
}());