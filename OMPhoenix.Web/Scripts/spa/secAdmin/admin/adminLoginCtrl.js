(function (app) {
    'use strict';

    app.controller('adminLoginCtrl', adminLoginCtrl);

    adminLoginCtrl.$inject = ['$scope', 'membershipService', 'notificationService', '$rootScope', '$location', 'apiService']; 

    function adminLoginCtrl($scope, membershipService, notificationService, $rootScope, $location) {
        $scope.pageClass = 'page-login';
        $scope.login = login;
        $scope.user = {};

        function login() {
            membershipService.login($scope.user, loginCompleted)
        }

        function loginCompleted(result) {
            if (result.data.success) {
                membershipService.saveCredentials($scope.user);
                notificationService.displaySuccess('Hello ' + $scope.user.username);
                $scope.userData.displayUserInfo();
                if ($rootScope.previousState)
                    $location.path($rootScope.previousState);
                else
                    $location.path('/adminindex');
            }
            else {
                notificationService.displayError('Login failed. Try again.');
            }
        }
    }
    

})(angular.module('secAdmin'));