'use strict';

angular.module('teleCom.standards', ['ngRoute'])

.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/standards', { templateUrl: '/app/Standards/Standards.html', controller: 'StandardsCtrl' });
    $routeProvider.when('/standard/:id', { templateUrl: '/app/Standards/EditStandard.html', controller: 'EditStandardCtrl' });
    $routeProvider.when('/add-standard', { templateUrl: '/app/Standards/AddStandard.html', controller: 'AddStandardCtrl' });
}])

.filter('startFrom', function () {
    return function (input, start) {
        start = +start;
        return input.slice(start);
    }
})

.controller('EditStandardCtrl', ['$scope', 'StandardFactory', 'ServicesFactory', 'ServiceFactory', 'HelperService', '$location', '$routeParams', '$timeout',
     function ($scope, StandardFactory, ServicesFactory, ServiceFactory, HelperService, $location, $routeParams, $timeout) {
         $scope.standard = {};

         HelperService.activateMenu('#standards-menu-item');

         ServicesFactory.query().$promise.then(function (result) {
             $scope.services = result;
             ServiceFactory.show({ id: $routeParams.id }).$promise.then(function (result) {
                 $scope.service = result;

                 $timeout(function () {
                     $('#standard').val($scope.standard.Service.Id);
                     $('.ui.dropdown').dropdown();
                 }, 0);
             });
         });

         $scope.setService = function (id) {
             $scope.standard.Service.Id = id;
         };

         $scope.updateStandard = function () {
             if ($scope.standard.Name && $scope.standard.Service.Id && $scope.standard.Value) {
                 StandardFactory.update({
                     id: $scope.standard.Id
                 }, $scope.standard).$promise.then(function (result) {
                     $location.path('/standards');
                 });
             } else {
                 $('.ui.form').form({
                     fields: {
                         Name: {
                             identifier: 'Name',
                             rules: [{ type: 'empty' }]
                         },
                         Service: {
                             identifier: 'Service',
                             rules: [{ type: 'empty' }]
                         },
                         Value: {
                             identifier: 'Value',
                             rules: [{ type: 'empty' }]
                         }
                     }
                 });
             }
         };

         $scope.cancel = function () {
             $location.path('/standards');
         };

         StandardFactory.show({ id: $routeParams.id }).$promise.then(function (result) {
             $scope.standard.Id = result.Id;
             $scope.standard.Name = result.Name;
             $scope.standard.Service = result.Service;
             $scope.standard.Value = result.Value;
         });
     }
])

.controller('AddStandardCtrl', ['$scope', 'ServicesFactory', 'StandardsFactory', 'HelperService', '$location',
     function ($scope, ServicesFactory, StandardsFactory, HelperService, $location) {
         $scope.standard = {};

         HelperService.activateMenu('#standards-menu-item');

         ServicesFactory.query().$promise.then(function (result) {
             $scope.services = result;
             $scope.standard = {};
             $scope.standard.Service = {};
             $scope.standard.Name = "";
             $scope.standard.Value = "";
             $('.ui.dropdown').dropdown();
         });

         $scope.setService = function (id) {
             $scope.standard.Service.Id = id;
         };

         $scope.createNewStandard = function () {
             if ($scope.standard.Name && $scope.standard.Service.Id && $scope.standard.Value) {
                 StandardsFactory.create($scope.standard).$promise.then(function (result) {
                     $location.path('/standards');
                 });
             } else {
                 $('.ui.form').form({
                     fields: {
                         Name: {
                             identifier: 'Name',
                             rules: [{ type: 'empty' }]
                         },
                         Service: {
                             identifier: 'Service',
                             rules: [{ type: 'empty' }]
                         },
                         Value: {
                             identifier: 'Value',
                             rules: [{ type: 'empty' }]
                         }
                     }
                 });
             }
         };

         $scope.cancel = function () {
             $location.path('/standards');
         };
     }
])

.controller('StandardsCtrl', ['$scope', 'StandardsFactory', 'StandardFactory', 'HelperService', '$location', '$filter',
    function ($scope, StandardsFactory, StandardFactory, HelperService, $location, $filter) {

        $scope.currentPage = 0;
        $scope.itemsPerPage = 10;
        $scope.standards = StandardsFactory.query();
        $scope.filteredItems = $scope.standards;

        HelperService.activateMenu('#standards-menu-item');

        $scope.editStandard = function (id) {
            $location.path('/standard/' + id);
        };

        $scope.deleteStandard = function (id) {
            StandardFactory.delete({ id: id }).$promise.then(function (result) {
                StandardsFactory.query().$promise.then(function (result) {
                    $scope.standards = result;
                    $scope.filteredItems = $scope.standards;
                    if ($scope.currentPage > $scope.numberOfPages() - 1) {
                        $scope.currentPage = $scope.numberOfPages() - 1;
                    }
                    $scope.query = "";
                });
            });
        };

        $scope.createNewStandard = function () {
            $location.path('/add-standard');
        };

        $scope.search = function () {
            $scope.filteredItems = $filter('filter')($scope.standards, function (item) {
                if (HelperService.searchMatch(item["Service"]["Name"], $scope.query)) {
                    return true;
                } else if (HelperService.searchMatch(item["Name"], $scope.query)) {
                    return true;
                } else if (HelperService.searchMatch(item["Value"], $scope.query)) {
                    return true;
                }
                return false;
            });
            $scope.currentPage = 0;
        };

        HelperService.addPaginationMethodsToScope($scope);
    }
]);