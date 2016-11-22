(function () {
    'use strict';
    var app = angular.module('MyApp', ['ngMaterial', 'ngMessages', 'material.svgAssetsCache', 'ngResource', 'ngRoute']);


        app.config(['$resourceProvider', function ($resourceProvider) {
                // Don't strip trailing slashes from calculated URLs
                $resourceProvider.defaults.stripTrailingSlashes = false;
            }]);

        app.controller('AutoCompleteCtrl', AutoCompleteCtrl, ['$routeParams', '$resource']);


    function AutoCompleteCtrl($http, $timeout, $q, $log, $routeParams, $resource) {

       // var titulos = $resource('api/Titulo/:id', { id: 'byName', nombre: '@name' });

        var titulos = $resource('api/Titulo/', {}, 
                {
                    'queryByName':
                       {
                           url: 'api/Titulo/:id',
                           params: {
                               id: 'byName',
                               nombre: '@name'
                           },
                           method: 'GET',
                           isArray: true,
                       
                       }

                }            
            );

        //var ti = titulos.queryByName({ nombre: 'Bonar' }, function () {
           
        //    var una = ti[0];
        //    alert("Llego aca");
        //    }            
        //);

        var self = this;
        self.simulateQuery = true;
        self.titulos = []; // = loadAllProducts($http);
        self.querySearch = querySearch;

        function querySearch(query) {

            //var results = query ? self.titulos.filter(createFilterFor(query)) : loadTitulosByQuery(query), deferred;
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

        function createFilterFor(query) {
            var lowercaseQuery = angular.lowercase(query);
            return function filterFn(titulo) {
                return (titulo.display.indexOf(lowercaseQuery) === 0);
            };

        }
    }
})();