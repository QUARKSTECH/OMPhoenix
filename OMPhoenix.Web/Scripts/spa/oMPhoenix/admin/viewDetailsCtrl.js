(function (app) {
    'use strict';

    app.controller('viewDetailsCtrl', viewDetailsCtrl);

    viewDetailsCtrl.$inject = ['$scope', 'membershipService', 'notificationService', '$rootScope', '$location', 'apiService','$timeout'];

    function viewDetailsCtrl($scope, membershipService, notificationService, $rootScope, $location, apiService,$timeout) {
        $scope.entityListVm = {
            customerList: {},
            machineList: {}
        };

        function getAllCustomer() {
            apiService.get('api/customer/getallcustomers', '', SuccessCustomer, Failed);
        }

        function getAllMachine() {
            apiService.get('api/machine/getallmachines', '', SuccessMachine, Failed);
        }
        //default on load
        $scope.$on('$viewContentLoaded', function (a) {
            getAllCustomer();
            getAllMachine();
            $scope.class = "tab active";
        });

        $scope.switchTab = function (tabName) {
            $timeout(function () {
                if (tabName === 'customer') {
                    $("#customer").show();
                    $("#machine").hide();
                }
                else {
                    $("#customer").hide();
                    $("#machine").show();
                }
            }, 0, false);
            

        }

        function SuccessCustomer(response) {
            $scope.entityListVm.customerList = response.data.responseData;
        }

        function SuccessMachine(response) {
            $scope.entityListVm.machineList = response.data.responseData;
        }

        function Failed() {
            notificationService.displayError("Something went wrong. Please try again.");
        }
    }

})(angular.module('oMPhoenix'));