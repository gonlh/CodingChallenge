(function () {
    'use strict';
    var app = angular.module('AppTitulos');

    app.config(['$resourceProvider', function ($resourceProvider) {
        // Don't strip trailing slashes from calculated URLs
        $resourceProvider.defaults.stripTrailingSlashes = false;
    }]);

    app.controller('AutoCompleteCtrl', AutoCompleteCtrl, ['$routeParams', '$resource', 'factoryTitulos']);


    function AutoCompleteCtrl($http, $timeout, $q, $log, $routeParams, $resource, factoryTitulos) {



        var titulos = factoryTitulos;


        var self = this;
        self.simulateQuery = true;
        self.titulos = [];
        self.querySearch = querySearch;

        function querySearch(query) {

            var results = loadTitulosByQuery(query), deferred;
            if (self.simulateQuery) {
                deferred = $q.defer();
                $timeout(function () { deferred.resolve(results); }, Math.random() * 1000, false);
                return deferred.promise;
            } else {
                return results;
            }
        }


        function loadTitulosByQuery(query) {
            var allTitulos = [];
            var result = [];

            allTitulos = titulos.queryByName({ nombre: query },
                function () {

                    angular.forEach(allTitulos,
                            function (Titulo, key) {
                                result.push(
                                    {
                                        value: Titulo,
                                        display: Titulo.Descripcion
                                    });
                            }
                    );
                },

                function errorCallback(response) {
                    console.log('Oops! Hubo un error mientras se buscaban los datos. Codigo: ' + response.status + ' Estado: ' + response.statusText);
                }

            );

            return result;

        }


    }
})();