'use strict';

angular.module('teleCom', [
  'ngRoute',
  'teleCom.restfulService',
  'teleCom.helpers',
  'teleCom.services',
  'teleCom.rates'
]).

config(['$routeProvider', function ($routeProvider) {
    $routeProvider.otherwise({ redirectTo: '/services' });
}]);