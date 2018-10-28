(function (app) {
    'use strict';

    app.controller('createCtrl', createCtrl);

    createCtrl.$inject = ['$scope', 'membershipService', 'notificationService', '$rootScope', '$location', '$routeParams', 'apiService','fileUploadService'];

    function createCtrl($scope, membershipService, notificationService, $rootScope, $location, $routeParams, apiService, fileUploadService) {

        $scope.createObj = {
            studentId: $routeParams.id,
            studentRecordsVm: {}
        }

        //default on load
        $scope.$on('$viewContentLoaded', function (a) {
            if ($scope.createObj.studentId!=null) {
                getStudentRecordsById($scope.createObj.studentId)
            }
        });

        $scope.create = function () {
            saveStudentsData();
        }

        function saveStudentsData () {
            apiService.post('api/student/savestudentsdata', $scope.createObj.studentRecordsVm, Success, Failed);
        }

        function Success (response) {
            $scope.createObj.studentRecordsVm = {};
            notificationService.displaySuccess("Records saved successfully");
            $location.path('/clientlist');
        }

        function Failed() {
            notificationService.displayError("Something went wrong. Please try again.");
        }

        function getStudentRecordsById(studentId) {
            apiService.post('api/student/saveStudentsData', studentId, getStudentDataSuccess, Failed);
        }

        function getStudentDataSuccess(response) {
            $scope.createObj.studentRecordsVm = response;
        }
        var type = "";
        $scope.uploadImage = function ($files, typ) {
            type = typ;
            $scope.customerImage = $files;
            if ($scope.customerImage[0].type == "image/png" || $scope.customerImage[0].type == "image/jpeg" && $scope.customerImage[0].size < 10485760 && $scope.customerImage[0].type != "") {
                fileUploadService.uploadCustomerImage($scope.customerImage, saveImage);
            }
            else {
                angular.element("input[type='file']").val(null);
                return false
            }
        }
        function saveImage(response) {
            if (response.status == 1) {
                if (type == 'Profile')
                    $scope.createObj.studentRecordsVm.ProfileImagePath = response.responseData.FileName;
                else
                    $scope.createObj.studentRecordsVm.CertificateImagePath = response.responseData.FileName;
                notificationService.displaySuccess('File uploaded successfully');
            }
            else {
                notificationService.displayError('Invalid image please try again');
            }
        }
    }

})(angular.module('secAdmin'));