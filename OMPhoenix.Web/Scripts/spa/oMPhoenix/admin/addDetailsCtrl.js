(function (app) {
    'use strict';

    app.controller('addDetailsCtrl', addDetailsCtrl);

    addDetailsCtrl.$inject = ['$scope', 'membershipService', 'notificationService', '$rootScope', '$location', 'apiService', '$routeParams'];

    function addDetailsCtrl($scope, membershipService, notificationService, $rootScope, $location, apiService, $routeParams) {
        $scope.addEntity = {
            entityId: $routeParams.id,
            customerRecordsVm: {},
            machineRecordsVm: {}
        }

        //default on load
        $scope.$on('$viewContentLoaded', function (a) {
            if ($scope.addEntity.entityId != null) {
                //getCustomerRecordsById($scope.addEntity.entityId)
            }
        });

        $scope.addCustomer = function () {
            saveCustomerData();
        }

        $scope.addMachine = function () {
            saveMachineData();
        }

        function saveCustomerData() {
            apiService.post('api/customer/savecustomersdata', $scope.addEntity.customerRecordsVm, SuccessCustomer, Failed);
        }

        function saveMachineData() {
            apiService.post('api/machine/savemachinesdata', $scope.addEntity.machineRecordsVm, SuccessMachine, Failed);
        }

        function SuccessCustomer(response) {
            $scope.addEntity.customerRecordsVm = {};
            notificationService.displaySuccess("Customer saved successfully");
        }

        function SuccessMachine(response) {
            $scope.addEntity.machineRecordsVm = {};
            notificationService.displaySuccess("Machine saved successfully");
        }

        function Failed() {
            notificationService.displayError("Something went wrong. Please try again.");
        }

        function getCustomerRecordsById(entityId) {
            apiService.post('api/customer/getcustomerdata', entityId, getCustomerDataSuccess, Failed);
        }

        function getMachineRecordsById(entityId) {
            apiService.post('api/machine/getmachinedata', entityId, getMachineDataSuccess, Failed);
        }

        function getCustomerDataSuccess(response) {
            $scope.addEntity.customerRecordsVm = response;
        }

        function getMachineDataSuccess(response) {
            $scope.addEntity.machineRecordsVm = response;
        }
    }

})(angular.module('oMPhoenix'));