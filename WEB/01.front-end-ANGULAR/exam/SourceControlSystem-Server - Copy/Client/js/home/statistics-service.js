(function(){
    'use strict';

    function statistics($q, data) {
        
        var statistics;

        function getStatistics() {
            if (statistics) {
                return $q.when(statistics);
            }
            else {
                return data.get('api/statistics')
                    .then(function (stats) {
                        statistics = stats;
                        return stats;
                    });
            }
        }

        return {
            getStatistics: getStatistics
        };
    }

    angular.module('myApp.services')
        .factory('statistics', ['$q', 'data', statistics]);
}())