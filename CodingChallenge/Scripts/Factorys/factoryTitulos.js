var app = angular.module('AppTitulos');

app.factory('factoryTitulos', ['$resource', function ($resource) {
    return $resource('api/Titulo/', {},
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
}]);