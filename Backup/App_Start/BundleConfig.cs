using System.Web.Optimization;

namespace Storemey.Web
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            //ACCOUNT BUNDLES
            bundles.Add(
                new StyleBundle("~/Bundles/account-vendor/css")
                    .Include("~/fonts/roboto/roboto.css", new CssRewriteUrlTransform())
                    .Include("~/fonts/material-icons/materialicons.css", new CssRewriteUrlTransform())
                    .Include("~/lib/bootstrap/dist/css/bootstrap.css", new CssRewriteUrlTransform())
                    .Include("~/lib/toastr/toastr.css", new CssRewriteUrlTransform())
                    .Include("~/lib/famfamfam-flags/dist/sprite/famfamfam-flags.css", new CssRewriteUrlTransform())
                    .Include("~/lib/font-awesome/css/font-awesome.css", new CssRewriteUrlTransform())
                    .Include("~/lib/Waves/dist/waves.css", new CssRewriteUrlTransform())
                    .Include("~/lib/animate.css/animate.css", new CssRewriteUrlTransform())
                    .Include("~/css/materialize.css", new CssRewriteUrlTransform())
                    .Include("~/css/style.css", new CssRewriteUrlTransform())
                    .Include("~/Views/Account/_Layout.css", new CssRewriteUrlTransform())
            );

            bundles.Add(
                new ScriptBundle("~/Bundles/account-vendor/js/bottom")
                    .Include(
                        "~/lib/json2/json2.js",
                        "~/lib/jquery/dist/jquery.js",
                        "~/lib/bootstrap/dist/js/bootstrap.js",
                        "~/lib/moment/min/moment-with-locales.js",
                        "~/lib/jquery-validation/dist/jquery.validate.js",
                        "~/lib/blockUI/jquery.blockUI.js",
                        "~/lib/toastr/toastr.js",
                        "~/lib/sweetalert/dist/sweetalert.min.js",
                        "~/lib/spin.js/spin.js",
                        "~/lib/spin.js/jquery.spin.js",
                        "~/lib/Waves/dist/waves.js",
                        "~/Abp/Framework/scripts/abp.js",
                        "~/Abp/Framework/scripts/libs/abp.jquery.js",
                        "~/Abp/Framework/scripts/libs/abp.toastr.js",
                        "~/Abp/Framework/scripts/libs/abp.blockUI.js",
                        "~/Abp/Framework/scripts/libs/abp.spin.js",
                        "~/Abp/Framework/scripts/libs/abp.sweet-alert.js",
                        "~/js/admin.js",
                        "~/js/main.js"
                    )
            );

            //VENDOR RESOURCES

            //~/Bundles/App/vendor/css
            bundles.Add(
                new StyleBundle("~/Bundles/App/vendor/css")
                    .Include("~/fonts/roboto/roboto.css", new CssRewriteUrlTransform())
                    .Include("~/fonts/material-icons/materialicons.css", new CssRewriteUrlTransform())
                    .Include("~/lib/bootstrap/dist/css/bootstrap.css", new CssRewriteUrlTransform())
                    .Include("~/lib/toastr/toastr.css", new CssRewriteUrlTransform())
                    .Include("~/lib/famfamfam-flags/dist/sprite/famfamfam-flags.css", new CssRewriteUrlTransform())
                    .Include("~/lib/font-awesome/css/font-awesome.css", new CssRewriteUrlTransform())
                    .Include("~/lib/Waves/dist/waves.css", new CssRewriteUrlTransform())
                    .Include("~/lib/animate.css/animate.css", new CssRewriteUrlTransform())
                    .Include("~/css/materialize.css", new CssRewriteUrlTransform())
                    .Include("~/css/style.css", new CssRewriteUrlTransform())
                    .Include("~/css/themes/all-themes.css", new CssRewriteUrlTransform())
                );

            //~/Bundles/App/vendor/js
            bundles.Add(
                new ScriptBundle("~/Bundles/App/vendor/js")
                    .Include(

                        "~/lib/json2/json2.js",
                        "~/lib/jquery/dist/jquery.js",
                        "~/lib/bootstrap/dist/js/bootstrap.js",
                        "~/lib/moment/min/moment-with-locales.js",
                        "~/lib/jquery-validation/dist/jquery.validate.js",
                        "~/lib/blockUI/jquery.blockUI.js",
                        "~/lib/toastr/toastr.js",
                        "~/lib/sweetalert/dist/sweetalert.min.js",
                        "~/lib/spin.js/spin.js",
                        "~/lib/spin.js/jquery.spin.js",
                        "~/lib/bootstrap-select/dist/js/bootstrap-select.js",
                        "~/lib/jquery-slimscroll/jquery.slimscroll.js",
                        "~/lib/Waves/dist/waves.js",
                        "~/lib/push.js/push.js",
                        "~/lib/jquery.serializejson/jquery.serializejson.js",

                        "~/Scripts/angular.min.js",
                        "~/Scripts/angular-animate.min.js",
                        "~/Scripts/angular-sanitize.min.js",
                        "~/Scripts/angular-ui-router.min.js",
                        "~/Scripts/angular-ui/ui-bootstrap.min.js",
                        "~/Scripts/angular-ui/ui-bootstrap-tpls.min.js",
                        "~/Scripts/angular-ui/ui-utils.min.js",

                        "~/Abp/Framework/scripts/abp.js",
                        "~/Abp/Framework/scripts/libs/abp.jquery.js",
                        "~/Abp/Framework/scripts/libs/abp.toastr.js",
                        "~/Abp/Framework/scripts/libs/abp.blockUI.js",
                        "~/Abp/Framework/scripts/libs/abp.spin.js",
                        "~/Abp/Framework/scripts/libs/abp.sweet-alert.js",
                        "~/Abp/Framework/scripts/libs/angularjs/abp.ng.js",

                        "~/js/admin.js",
                        "~/Scripts/jquery.signalR-2.2.3.min.js",
                        "~/js/main.js"
                    )
                );

            //Home-Index Bundles
            bundles.Add(
                new ScriptBundle("~/Bundles/home-index")
                    .Include(
                        "~/lib/jquery-countTo/jquery.countTo.js",
                        "~/lib/raphael/raphael.js",
                        "~/lib/morris.js/morris.js",
                        "~/lib/chart.js/dist/Chart.bundle.js",
                        "~/lib/Flot/jquery.flot.js",
                        "~/lib/Flot/jquery.flot.resize.js",
                        "~/lib/Flot/jquery.flot.pie.js",
                        "~/lib/Flot/jquery.flot.categories.js",
                        "~/lib/Flot/jquery.flot.time.js",
                        "~/lib/jquery-sparkline/dist/jquery.sparkline.js"
                    )
            );

            //APPLICATION RESOURCES

            //~/Bundles/App/Main/css
            bundles.Add(
                new StyleBundle("~/Bundles/App/Main/css")
                    .IncludeDirectory("~/App/Main", "*.css", true)
                );

            //~/Bundles/App/Main/js
            bundles.Add(
                new ScriptBundle("~/Bundles/App/Main/js")
                    .IncludeDirectory("~/Common/Scripts", "*.js", true)
                    .IncludeDirectory("~/App/Main", "*.js", true)
                );



            //PAKET THEME RESOURCES



            //~/Bundles/App/Main/css
            bundles.Add(
                new StyleBundle("~/Content/StoremeyTheme")
                    .Include("~/Content/StoremeyTheme/ANGULARJS/bower_components/bootstrap/dist/css/bootstrap.min.css")
                    .Include("~/Content/StoremeyTheme/ANGULARJS/bower_components/font-awesome/css/font-awesome.min.css")
                    .Include("~/Content/StoremeyTheme/ANGULARJS/bower_components/themify-icons/css/themify-icons.css")
                    .Include("~/Content/StoremeyTheme/ANGULARJS/bower_components/flag-icon-css/css/flag-icon.min.css")
                    .Include("~/Content/StoremeyTheme/ANGULARJS/bower_components/angular-loading-bar/build/loading-bar.min.css")
                    .Include("~/Content/StoremeyTheme/ANGULARJS/bower_components/animate.css/animate.min.css")
                    .Include("~/Content/StoremeyTheme/ANGULARJS/bower_components/perfect-scrollbar/css/perfect-scrollbar.min.css")
                    .Include("~/Content/StoremeyTheme/ANGULARJS/bower_components/bootstrap-daterangepicker/daterangepicker.css")
                    .Include("~/Content/StoremeyTheme/ANGULARJS/bower_components/angular-ui-switch/angular-ui-switch.min.css")
                    .Include("~/Content/StoremeyTheme/ANGULARJS/bower_components/AngularJS-Toaster/toaster.css")
                    .Include("~/Content/StoremeyTheme/ANGULARJS/bower_components/angular-aside/dist/css/angular-aside.min.css")
                    .Include("~/Content/StoremeyTheme/ANGULARJS/bower_components/angular-notification-icons/dist/angular-notification-icons.min.css")
                    .Include("~/Content/StoremeyTheme/ANGULARJS/bower_components/v-accordion/dist/v-accordion.min.css")
                    .Include("~/Content/StoremeyTheme/ANGULARJS/bower_components/v-button/dist/v-button.min.css")
                    .Include("~/Content/StoremeyTheme/ANGULARJS/bower_components/sweetalert/dist/sweetalert.css")
                    .Include("~/Content/StoremeyTheme/ANGULARJS/bower_components/ladda/dist/ladda-themeless.min.css")
                    .Include("~/Content/StoremeyTheme/ANGULARJS/bower_components/angular-awesome-slider/dist/css/angular-awesome-slider.min.css")
                    .Include("~/Content/StoremeyTheme/ANGULARJS/bower_components/slick-carousel/slick/slick.css")
                    .Include("~/Content/StoremeyTheme/ANGULARJS/bower_components/slick-carousel/slick/slick-theme.css")
                    .Include("~/Content/StoremeyTheme/ANGULARJS/LAYOUT-1/STANDARD/assets/css/styles.css")
                    .Include("~/Content/StoremeyTheme/ANGULARJS/LAYOUT-1/STANDARD/assets/css/plugins.css")

                );

            //~/Bundles/App/Main/js
            bundles.Add(
                new ScriptBundle("~/Bundles/App/Main/js")
                    .IncludeDirectory("~/Common/Scripts", "*.js", true)
                    .IncludeDirectory("~/App/Main", "*.js", true)
                );

            
            BundleTable.EnableOptimizations = false;
        }
    }
}