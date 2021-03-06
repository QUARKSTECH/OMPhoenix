﻿(function (app) {
    'use strict';

    app.controller('adminIndexCtrl', adminIndexCtrl);

    adminIndexCtrl.$inject = ['$scope', 'membershipService', 'notificationService', '$rootScope', '$location', 'apiService'];

    function adminIndexCtrl($scope, membershipService, notificationService, $rootScope, $location, apiService) {
        $scope.studentListVm = {
            studentlist: {}
        };

        function getAllStudent() {
            apiService.get('api/student/getallstudents', '', Success, Failed);
        }
        //default on load
        $scope.$on('$viewContentLoaded', function (a) {
            //getAllStudent();
        });



        function Success(response) {
            $scope.studentListVm.studentlist = response.data.responseData;
        }

        function Failed() {
            notificationService.displayError("Something went wrong. Please try again.");
        }
    }

})(angular.module('oMPhoenix'));