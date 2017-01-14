(function () {
    'use strict';

    function tripsCreateController($location, cities, trips, notifier) {
        var vm = this;

        cities.getAll()
            .then(function (allCities) {
                vm.cities = allCities;
            });
        notifier.success('here');
        vm.createTrip = function (newTrip) {
           
            trips.createTrip(newTrip)
                .then(function (createdTrip) {
                    notifier.success('succecced');
                    $location.path('/trips/details/' + createdTrip.id);
                });
        }
    }

    angular.module('myApp.controllers')
        .controller('tripsCreateController', ['$location', 'cities', 'trips','notifier', tripsCreateController]);
}());