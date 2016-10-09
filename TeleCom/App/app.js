'use strict';

angular.module('teleCom', [
  'ngRoute',
  'teleCom.restfulService',
  'teleCom.helpers',
  'teleCom.services'
]).

config(['$routeProvider', function ($routeProvider) {
    $routeProvider.otherwise({ redirectTo: '/services' });
}]);