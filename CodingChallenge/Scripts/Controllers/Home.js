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
            return loadTitulosByQuery(query).then(function (data) {
                return data;
            })  
        }


        function loadTitulosByQuery(query) {
            var allTitulos = [];
            

            var defered = $q.defer();
            var promise = defered.promise;

            allTitulos = titulos.queryByName({ nombre: query },
                function () {
                    var result = [];
                    angular.forEach(allTitulos,
                            function (Titulo, key) {
                                result.push(
                                    {
                                        value: Titulo,
                                        display: Titulo.Descripcion
                                    });
                            }
                    );
                    defered.resolve(result);
                },

                function errorCallback(response) {
                    console.log('Oops! Hubo un error mientras se buscaban los datos. Codigo: ' + response.status + ' Estado: ' + response.statusText);
                }

            );
            return promise;
        }
    }
})();