'use strict';

var services = angular.module('teleCom.restfulService', ['ngResource']);

services.factory('ServicesFactory', ['$resource',
    function ($resource) {
        return $resource('/api/Services', {}, {
            query: { method: 'GET', isArray: true },
            create: { method: 'POST' }
        });
    }
]);

services.factory('ServiceFactory', ['$resource',
    function ($resource) {
        return $resource('/api/Services/:id', {}, {
            show: { method: 'GET' },
            update: { method: 'PUT', params: { id: '@id' } },
            delete: { method: 'DELETE', params: { id: '@id' } }
        });
    }
]);

services.factory('RatesFactory', ['$resource',
    function ($resource) {
        return $resource('/api/Rates', {}, {
            query: { method: 'GET', isArray: true },
            create: { method: 'POST' }
        });
    }
]);

services.factory('RateFactory', ['$resource',
    function ($resource) {
        return $resource('/api/Rates/:id', {}, {
            show: { method: 'GET' },
            update: { method: 'PUT', params: { id: '@id' } },
            delete: { method: 'DELETE', params: { id: '@id' } }
        });
    }
]);

services.factory('StandardsFactory', ['$resource',
    function ($resource) {
        return $resource('/api/Standards', {}, {
            query: { method: 'GET', isArray: true },
            create: { method: 'POST' }
        });
    }
]);

services.factory('StandardFactory', ['$resource',
    function ($resource) {
        return $resource('/api/Standards/:id', {}, {
            show: { method: 'GET' },
            update: { method: 'PUT', params: { id: '@id' } },
            delete: { method: 'DELETE', params: { id: '@id' } }
        });
    }
]);