﻿using System.Web.Optimization;

namespace OMPhoenix.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/Vendors/modernizr.js"));

            bundles.Add(new ScriptBundle("~/bundles/vendors").Include(
                "~/Scripts/Vendors/jquery.js",
                "~/Scripts/Vendors/bootstrap.js",
                "~/Scripts/Vendors/toastr.js",
                "~/Scripts/Vendors/jquery.raty.js",
                "~/Scripts/Vendors/respond.src.js",
                "~/Scripts/Vendors/angular.js",
                "~/Scripts/Vendors/angular-route.js",
                "~/Scripts/Vendors/angular-cookies.js",
                "~/Scripts/Vendors/angular-validator.js",
                "~/Scripts/Vendors/angular-base64.js",
                "~/Scripts/Vendors/angular-file-upload.js",
                "~/Scripts/Vendors/angucomplete-alt.min.js",
                "~/Scripts/Vendors/ui-bootstrap-tpls-0.13.1.js",
                "~/Scripts/Vendors/underscore.js",
                "~/Scripts/Vendors/raphael.js",
                "~/Scripts/Vendors/morris.js",
                "~/Scripts/Vendors/jquery.fancybox.js",
                "~/Scripts/Vendors/jquery.fancybox-media.js",
                "~/Scripts/Vendors/loading-bar.js",
                "~/Scripts/Vendors/index.js",
                "~/Scripts/Vendors/wow.min.js",
                "~/Scripts/Vendors/active.js",
                "~/Scripts/Vendors/plugins.js",
                "~/Scripts/Vendors/popper.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/spa").Include(
                "~/Scripts/spa/modules/common.core.js",
                "~/Scripts/spa/modules/common.ui.js",
                "~/Scripts/spa/app.js",
                "~/Scripts/spa/services/apiService.js",
                "~/Scripts/spa/services/notificationService.js",
                "~/Scripts/spa/services/membershipService.js",
                "~/Scripts/spa/services/fileUploadService.js",
                "~/Scripts/spa/layout/topBar.directive.js",
                "~/Scripts/spa/layout/sideBar.directive.js",
                "~/Scripts/spa/layout/customPager.directive.js",
                "~/Scripts/spa/directives/rating.directive.js",
                "~/Scripts/spa/directives/availableMovie.directive.js",
                //"~/Scripts/spa/secAdmin/login/loginCtrl.js",
                "~/Scripts/spa/account/registerCtrl.js",
                "~/Scripts/spa/home/rootCtrl.js",
                "~/Scripts/spa/home/indexCtrl.js",
                //"~/scripts/spa/oMPhoenix/clientList/clientListCtrl.js",
                //"~/scripts/spa/oMPhoenix/createRecords/createCtrl.js",
                "~/scripts/spa/oMPhoenix/admin/adminLoginCtrl.js",
                "~/scripts/spa/oMPhoenix/admin/adminIndexCtrl.js",
                "~/scripts/spa/oMPhoenix/admin/addDetailsCtrl.js",
                "~/scripts/spa/oMPhoenix/admin/viewDetailsCtrl.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/css/style.css",
                "~/Content/css/classy-nav.css",
                "~/Content/css/bootstrap.min.css",
                "~/Content/css/bootstrap-theme.css",
                "~/Content/css/font-awesome.min.css",
                "~/Content/css/morris.css",
                "~/content/css/toastr.css",
                "~/Content/css/jquery.fancybox.css",
                "~/Content/css/loading-bar.css",
                "~/Content/css/magnific-popup.css",
                "~/Content/css/nice-select.css",
                "~/Content/css/travel-icon.css",
                "~/Content/css/animate.css"));

            BundleTable.EnableOptimizations = false;
        }
    }
}