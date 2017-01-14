﻿(function () {
    'use strict';

    function statistics(data, $q) {
        var statistics;

        function getStats() {
            if (statistics) {
                return $q.when(statistics);
            }
            else {
                return data.get('api/stats')
                    .then(function (stats) {
                        statistics = stats;
                        return stats;
                    });
            }

        }

        return {
            getStats: getStats
        }
    }

    angular.module('myApp.services')
        .factory('statistics', ['data','$q', statistics]);

}());