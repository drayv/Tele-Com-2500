﻿'use strict';

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