using System.Web;
using System.Web.Optimization;

namespace NewFashionWebsite
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-ajax").Include(
                        "~/Scripts/jquery.unobtrusive*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/json2").Include(
                "~/Scripts/json2.js"));
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/css/camera.css",
                        "~/Content/css/jcarousel.css",
                        "~/Content/css/prettyPhoto.css",
                        "~/Content/css/style.css",
                        "~/Content/css/tipsy.css",
                        "~/Content/css/menu-profile.css",
                        "~/Content/css/itemslider.css",
                        "~/Content/css/jquery.jqzoom.css"));

            //css dành cho trang admin
            bundles.Add(new StyleBundle("~/Content/css-admin").Include(
                        "~/assets/lib/bootstrap/css/bootstrap.css",
                        "~/assets/css/main.css",
                        "~/assets/lib/Font-Awesome/css/font-awesome.css",
                        "~/assets/css/theme.css"
                    ));

            //css dành cho trang admin 1
            bundles.Add(new StyleBundle("~/Content/css-admin-custom1").Include(
                        "~/assets/lib/fullcalendar-1.6.2/fullcalendar/fullcalendar.css"
                    ));

            //css dành cho trang admin 2
            bundles.Add(new StyleBundle("~/Content/css-admin-custom2").Include(
                        "~/assets/lib/datatables/css/demo_page.css",
                        "~/assets/lib/datatables/css/DT_bootstrap.css"
                    ));

            //css dành cho trang admin 3
            bundles.Add(new StyleBundle("~/Content/css-admin-custom3").Include(
                        "~/assets/lib/animate/animate.min.css"
                    ));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            //Script shopymart
            bundles.Add(new ScriptBundle("~/bundles/script-shopymart").Include(
                        "~/Scripts/js/jquery-1.8.2.1.js",
                        "~/Scripts/js/css3-mediaqueries.js", //mediaqueries-->
                        "~/Scripts/js/modernizr-1.7.js", //modernizr-->
                        "~/Scripts/js/modernizr.custom.js", //<!--itemslider-modernizr-->
                        "~/Scripts/js/jquery.prettyPhoto.js", // prettyPhoto -->
                        "~/Scripts/js/jquery.tipsy.js", //tooltip-->
                        "~/Scripts/js/jquery.easing.1.3.js",
                        "~/Scripts/js/camera.js",
                        "~/Scripts/js/jquery.jcarousel.js",
                        "~/Scripts/js/jquery-hover-effect.js", //Image Hover Effect-->
                        "~/Scripts/js/jquery.hoverIntent.minified.js", //menu-->
                        "~/Scripts/js/jquery.dcmegamenu.1.3.3.js", //menu-->
                        "~/Scripts/js/jquery.tweet.js",
                        "~/Scripts/js/jquery.quovolver.js", //blockquote-->
                        "~/Scripts/js/jquery.catslider.js",
                        "~/Scripts/js/custom.js",
                        "~/Scripts/js/jquery.jqzoom-core.js",
                        "~/Scripts/js/organictabs.jquery.js",
                        "~/Scripts/js/rating.js")); //custom-->

            

            //Script trang admin
            bundles.Add(new ScriptBundle("~/bundles/script-admin").Include(
                        "~/assets/lib/modernizr-2.6.2-respond-1.1.0.js",
                        
                        "~/assets/lib/bootstrap/js/bootstrap.js",
                        "~/assets/js/style-switcher.js",
                        "~/assets/js/main.js",
                        "~/Scripts/tinymce/jquery.tinymce.js",
                        "~/Scripts/tinymce/tinymce.js",
                        "~/Scripts/js/jquery.MultiFile.js",
                        "~/Scripts/js/jquery.blockUI.js"
                        ));

            //Script trang admin custom 1
            bundles.Add(new ScriptBundle("~/bundles/script-admin-custom1").Include(
                         "~/assets/lib/fullcalendar-1.6.2/fullcalendar/fullcalendar.js",
                         "~/assets/lib/tablesorter/js/jquery.tablesorter.js", 
                         "~/assets/lib/sparkline/jquery.sparkline.js", 
                         "~/assets/lib/flot/jquery.flot.js", 
                         "~/assets/lib/flot/jquery.flot.selection.js", 
                         "~/assets/lib/flot/jquery.flot.resize.js" 
                        ));

            //Script trang admin custom 2
            bundles.Add(new ScriptBundle("~/bundles/script-admin-custom2").Include(
                        "~/assets/lib/datatables/jquery.dataTables.js",
                        "~/assets/lib/datatables/DT_bootstrap.js",
                        "~/assets/lib/tablesorter/js/jquery.tablesorter.js",
                        "~/assets/lib/touch-punch/jquery.ui.touch-punch.js"
                        ));

            //Script trang admin custom 3
            bundles.Add(new ScriptBundle("~/bundles/script-admin-custom3").Include(
                        "~/assets/lib/flot/jquery.flot.js",
                        "~/assets/lib/flot/jquery.flot.pie.js",
                        "~/assets/lib/flot/jquery.flot.selection.js",
                        "~/assets/lib/flot/jquery.flot.resize.js"
                        ));
        }
    }
}