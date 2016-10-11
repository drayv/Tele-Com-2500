'use strict';

angular.module('teleCom.rates', ['ngRoute'])

.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/rates', { templateUrl: '/app/Rates/Rates.html', controller: 'RatesCtrl' });
    $routeProvider.when('/rate/:id', { templateUrl: '/app/Rates/EditRate.html', controller: 'EditRateCtrl' });
    $routeProvider.when('/add-rate', { templateUrl: '/app/Rates/AddRate.html', controller: 'AddRateCtrl' });
}])

.filter('startFrom', function () {
    return function (input, start) {
        start = +start;
        return input.slice(start);
    }
})

.controller('EditRateCtrl', ['$scope', 'RateFactory', 'ServicesFactory', 'ServiceFactory', 'HelperService', '$location', '$routeParams', '$timeout',
     function ($scope, RateFactory, ServicesFactory, ServiceFactory, HelperService, $location, $routeParams, $timeout) {
         $scope.rate = {};

         HelperService.activateMenu('#rates-menu-item');

         ServicesFactory.query().$promise.then(function (result) {
             $scope.services = result;
             ServiceFactory.show({ id: $routeParams.id }).$promise.then(function (result) {
                 $scope.service = result;

                 $timeout(function () {
                     $('#rate').val($scope.rate.Service.Id);
                     $('.ui.dropdown').dropdown();
                 }, 0);
             });
         });

         $scope.setService = function (id) {
             $scope.rate.Service.Id = id;
         };

         $scope.updateRate = function () {

             var amount = parseFloat($scope.rate.Amount.toString().replace(",", "."));
             $scope.rate.Amount = amount;

             if ($scope.rate.StartDate && $scope.rate.Service.Id && amount != null) {
                 RateFactory.update({
                     id: $scope.rate.Id
                 }, $scope.rate).$promise.then(function (result) {
                     $location.path('/rates');
                 });
             } else {
                 $('.ui.form').form({
                     fields: {
                         StartDate: {
                             identifier: 'StartDate',
                             rules: [{ type: 'empty', prompt: 'Введите дату начала действия цены!' }]
                         },
                         Service: {
                             identifier: 'Service',
                             rules: [{ type: 'empty', prompt: 'Выбирете работу!' }]
                         },
                         Amount: {
                             identifier: 'Amount',
                             rules: [{ type: 'regExp[/^([0-9]{0,8}((,)[0-9]{0,2}))$/]', prompt: 'Формат цены: разделитьль: запятая, два знака после запятой как максимум.' }]
                         }
                     }
                 });
             }
         };

         $scope.cancel = function () {
             $location.path('/rates');
         };

         RateFactory.show({ id: $routeParams.id }).$promise.then(function (result) {
             $scope.rate.Id = result.Id;
             $scope.rate.Amount = result.Amount;
             $scope.rate.Service = result.Service;
             $scope.rate.StartDate = new Date(result.StartDate);
         });
     }
])

.controller('AddRateCtrl', ['$scope', 'ServicesFactory', 'RatesFactory', 'HelperService', '$location',
     function ($scope, ServicesFactory, RatesFactory, HelperService, $location) {
         $scope.rate = {};

         HelperService.activateMenu('#rates-menu-item');

         ServicesFactory.query().$promise.then(function (result) {
             $scope.services = result;
             $scope.rate = {};
             $scope.rate.Service = {};
             $scope.rate.Amount = 0;
             $('.ui.dropdown').dropdown();
         });

         $scope.setService = function (id) {
             $scope.rate.Service.Id = id;
         };

         $scope.createNewRate = function () {

             var amount = parseFloat($scope.rate.Amount.toString().replace(",", "."));
             $scope.rate.Amount = amount;

             if ($scope.rate.StartDate && $scope.rate.Service.Id && amount != null) {
                 RatesFactory.create($scope.rate).$promise.then(function (result) {
                     $location.path('/rates');
                 });
             } else {
                 $('.ui.form').form({
                     fields: {
                         StartDate: {
                             identifier: 'StartDate',
                             rules: [{ type: 'empty', prompt: 'Введите дату начала действия цены!' }]
                         },
                         Service: {
                             identifier: 'Service',
                             rules: [{ type: 'empty', prompt: 'Выбирете работу!' }]
                         },
                         Amount: {
                             identifier: 'Amount',
                             rules: [{ type: 'regExp[/^([0-9]{0,8}((,)[0-9]{0,2}))$/]', prompt: 'Формат цены: разделитьль: запятая, два знака после запятой как максимум.' }]
                         }
                     }
                 });
             }
         };

         $scope.cancel = function () {
             $location.path('/rates');
         };
     }
])

.controller('RatesCtrl', ['$scope', 'RatesFactory', 'RateFactory', 'HelperService', '$location', '$filter',
    function ($scope, RatesFactory, RateFactory, HelperService, $location, $filter) {

        $scope.currentPage = 0;
        $scope.itemsPerPage = 10;
        $scope.rates = RatesFactory.query();
        $scope.filteredItems = $scope.rates;

        HelperService.activateMenu('#rates-menu-item');

        $scope.editRate = function (id) {
            $location.path('/rate/' + id);
        };

        $scope.deleteRate = function (id) {
            RateFactory.delete({ id: id }).$promise.then(function (result) {
                RatesFactory.query().$promise.then(function (result) {
                    $scope.rates = result;
                    $scope.filteredItems = $scope.rates;
                    if ($scope.currentPage > $scope.numberOfPages() - 1) {
                        $scope.currentPage = $scope.numberOfPages() - 1;
                    }
                    $scope.query = "";
                });
            });
        };

        $scope.createNewRate = function () {
            $location.path('/add-rate');
        };

        $scope.search = function () {
            $scope.filteredItems = $filter('filter')($scope.rates, function (item) {
                if (HelperService.searchMatch(item["Service"]["Name"], $scope.query)) {
                    return true;
                } else if (HelperService.searchMatch(item["Amount"], $scope.query)) {
                    return true;
                } else if (HelperService.searchMatch(item["StartDate"], $scope.query)) {
                    return true;
                }
                return false;
            });
            $scope.currentPage = 0;
        };

        HelperService.addPaginationMethodsToScope($scope);
    }
]);