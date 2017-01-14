(function () {
    'use strict';

    function tripsController(trips, identity, cities) {
        var vm = this;
        vm.identity = identity;
        vm.request = {
            page: 1
        };

        vm.prevPage = function () {
            if (vm.request.page == 1) {
                return;
            }
            vm.request.page--;
        }

        vm.prevPage = function () {
            if (vm.request.page == 1) {
                return;
            }
            vm.request.page--;
        }

        vm.nextPage = function () {
            if (!vm.trips || vm.trips.length == 0) {
                return;
            }

            vm.request.page++;
            vm.filterTrips();
        }

        vm.filterTrips = function () {
            trips.filterTrips(vm.request)
                .then(function (filtered) {
                    vm.trips = filtered;
                });
        }

        cities.getAll()
            .then(function (allCities) {
                vm.cities = allCities;
            });

        trips.getPublicTrips()
            .then(function (trips) {
                vm.trips = trips;
            });
    }

    angular.module('myApp.controllers')
        .controller('tripsController', ['trips', 'identity','cities', tripsController]);
}());