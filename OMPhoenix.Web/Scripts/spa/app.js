(function () {
    'use strict';

    angular.module('secAdmin', ['common.core', 'common.ui'])
        .config(config)
        .run(run);

    config.$inject = ['$routeProvider','$locationProvider'];
    function config($routeProvider, $locationProvider) {
        $routeProvider
            .when("/", {
                templateUrl: "scripts/spa/secAdmin/admin/adminLogin.html",
                controller: "adminLoginCtrl"
            })
            .when("/adminindex", {
                templateUrl: "scripts/spa/secAdmin/admin/adminIndex.html",
                controller: "adminIndexCtrl"
            })
            .when("/addentry/:id?", {
                templateUrl: "scripts/spa/secAdmin/admin/addDetails.html",
                controller: "addDetailsCtrl"
            })
            .when("/viewentry", {
                templateUrl: "scripts/spa/secAdmin/admin/viewDetails.html",
                controller: "viewDetailsCtrl"
            })
            .otherwise({ redirectTo: "#/" });

        //$locationProvider.html5Mode({
        //    enabled: true,
        //    requireBase: false
        //});
    }

    run.$inject = ['$rootScope', '$location', '$cookieStore', '$http'];

    function run($rootScope, $location, $cookieStore, $http) {
        // handle page refreshes
        $rootScope.repository = $cookieStore.get('repository') || {};
        if ($rootScope.repository.loggedUser) {
            $http.defaults.headers.common['Authorization'] = $rootScope.repository.loggedUser.authdata;
        }

        $(document).ready(function () {
            $(".fancybox").fancybox({
                openEffect: 'none',
                closeEffect: 'none'
            });

            $('.fancybox-media').fancybox({
                openEffect: 'none',
                closeEffect: 'none',
                helpers: {
                    media: {}
                }
            });

            $('[data-toggle=offcanvas]').click(function () {
                $('.row-offcanvas').toggleClass('active');
            });
        });
    }

    isAuthenticated.$inject = ['membershipService', '$rootScope', '$location'];

    function isAuthenticated(membershipService, $rootScope, $location) {
        if (!membershipService.isUserLoggedIn()) {
            $rootScope.previousState = $location.path();
            $location.path('/login');
        }
    }

})();