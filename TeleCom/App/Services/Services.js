'use strict';

angular.module('teleCom.services', ['ngRoute'])

.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/services', { templateUrl: '/app/Services/Services.html', controller: 'ServicesCtrl' });
    $routeProvider.when('/service/:id', { templateUrl: '/app/Services/EditService.html', controller: 'EditServiceCtrl' });
    $routeProvider.when('/add-service', { templateUrl: '/app/Services/AddService.html', controller: 'AddServiceCtrl' });
}])

.filter('startFrom', function () {
    return function (input, start) {
        start = +start;
        return input.slice(start);
    }
})

.controller('ServicesCtrl', ['$scope', 'ServicesFactory', 'ServiceFactory', 'HelperService', '$location', '$filter',
    function ($scope, ServicesFactory, ServiceFactory, HelperService, $location, $filter) {

        $scope.currentPage = 0;
        $scope.itemsPerPage = 10;
        $scope.services = ServicesFactory.query();
        $scope.filteredItems = $scope.services;

        HelperService.activateMenu('#services-menu-item');

        $scope.editService = function (id) {
            $location.path('/service/' + id);
        };

        $scope.deleteService = function (id) {
            ServiceFactory.delete({ id: id }).$promise.then(function (result) {
                ServicesFactory.query().$promise.then(function (result) {
                    $scope.services = result;
                    $scope.filteredItems = $scope.services;
                    if ($scope.currentPage > $scope.numberOfPages() - 1) {
                        $scope.currentPage = $scope.numberOfPages() - 1;
                    }
                    $scope.query = "";
                });
            });
        };

        $scope.createNewService = function () {
            $location.path('/add-service');
        };

        $scope.search = function () {
            $scope.filteredItems = $filter('filter')($scope.services, function (item) {
                if (HelperService.searchMatch(item["Id"], $scope.query)) {
                    return true;
                } else if (HelperService.searchMatch(item["Name"], $scope.query)) {
                    return true;
                }
                return false;
            });
            $scope.currentPage = 0;
        };

        HelperService.addPaginationMethodsToScope($scope);
    }
]);