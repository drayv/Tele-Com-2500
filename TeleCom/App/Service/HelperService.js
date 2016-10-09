﻿'use strict';

angular.module('teleCom.helpers', ['ngRoute'])

.factory("HelperService", function () {
    return {
        addPaginationMethodsToScope: function (scope) {
            scope.prevPage = function () {
                if (scope.currentPage > 0) {
                    scope.currentPage--;
                }
            };

            scope.nextPage = function () {
                if (scope.currentPage < scope.numberOfPages() - 1) {
                    scope.currentPage++;
                }
            };

            scope.startingItem = function () {
                return scope.currentPage * scope.itemsPerPage;
            };

            scope.numberOfPages = function () {
                return Math.ceil(scope.filteredItems.length / scope.itemsPerPage);
            };
        },
        searchMatch: function (find, query) {
            if (!query) {
                return true;
            }
            if (find == null) {
                return false;
            }
            return find.toLowerCase().indexOf(query.toLowerCase()) !== -1;
        },
        activateMenu: function (selector) {
            $('#logo-menu-item').removeClass('active');
            $('#nomenclature-menu-item').removeClass('active');
            $('#repairers-menu-item').removeClass('active');
            $('#requests-menu-item').removeClass('active');
            $(selector).addClass('active');
        }
    }
});