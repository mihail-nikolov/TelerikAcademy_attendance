(function () {
    'use strict';

    function homeController(statistics, trips, drivers) {
        var vm = this;

        statistics.getStats()
            .then(function (stats) {
                vm.stats = stats;
            });

        trips.getPublicTrips()
            .then(function (publicTrips) {
                vm.publicTrips = publicTrips;
            });

        drivers.getPublicDriversInfo()
           .then(function (publicDriversInfo) {
               vm.publicDriversInfo = publicDriversInfo;
           });

    }
    angular.module('myApp.controllers')
        .controller('homeController', ['statistics','trips', 'drivers',  homeController]);
}());