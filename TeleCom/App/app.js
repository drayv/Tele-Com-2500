'use strict';

angular.module('teleCom', [
  'ngRoute',
  'teleCom.restfulService',
  'teleCom.helpers',
  'teleCom.services',
  'teleCom.rates',
  'teleCom.standards'
]).

config(['$routeProvider', function ($routeProvider) {
    $routeProvider.otherwise({ redirectTo: '/services' });
}]);