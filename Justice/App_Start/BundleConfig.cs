using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;

namespace Justice
{
    public class BundleConfig
    {
        // For more information on Bundling, visit https://go.microsoft.com/fwlink/?LinkID=303951
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/WebFormsJs").Include(
                            "~/Scripts/WebForms/WebForms.js",
                            "~/Scripts/WebForms/WebUIValidation.js",
                            "~/Scripts/WebForms/MenuStandards.js",
                            "~/Scripts/WebForms/Focus.js",
                            "~/Scripts/WebForms/GridView.js",
                            "~/Scripts/WebForms/DetailsView.js",
                            "~/Scripts/WebForms/TreeView.js",
                            "~/Scripts/WebForms/WebParts.js"));

            // Order is very important for these files to work, they have explicit dependencies
            bundles.Add(new ScriptBundle("~/bundles/MsAjaxJs").Include(
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjax.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"));

            bundles.Add(new ScriptBundle("~/bundles/indexJs").Include(
                "~/Scripts/Main/bootstrap.js",
                "~/Scripts/Main/jquery-3.1.1.min.js",
                "~/Scripts/Main/bootstrap.min.js",
                "~/Scripts/Main/script.js",
                "~/Scripts/Main/font-awesome.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/adminJs").Include(
                "~/Content/Admin/plugins/jquery-1.8.3.min.js",
                "~/Content/Admin/plugins/jquery-ui/jquery-ui-1.10.1.custom.min.js",
                "~/Content/Admin/plugins/bootstrap/js/bootstrap.min.js",
                "~/Content/Admin/plugins/breakpoints.js",
                "~/Content/Admin/plugins/jquery-unveil/jquery.unveil.min.js",
                "~/Content/Admin/plugins/jquery-block-ui/jqueryblockui.js",
                "~/Content/Admin/plugins/jquery-lazyload/jquery.lazyload.min.js",
                "~/Content/Admin/plugins/jquery-slider/jquery.sidr.min.js",
                "~/Content/Admin/plugins/jquery-slimscroll/jquery.slimscroll.min.js",
                "~/Content/Admin/plugins/webarchScroll.js",
                "~/Content/Admin/plugins/pace/pace.min.js",
                "~/Content/Admin/plugins/jquery-numberAnimate/jquery.animateNumbers.js",
                "~/Content/Admin/plugins/skycons/skycons.js",
                "~/Content/Admin/plugins/owl-carousel/owl.carousel.min.js",
                "~/Content/Admin/plugins/bootstrap-select2/select2.min.js",
                "~/Content/Admin/plugins/jquery-datatable/js/jquery.dataTables.min.js",
                "~/Content/Admin/plugins/jquery-datatable/extra/js/TableTools.min.js",
                "~/Content/Admin//plugins/datatables-responsive/js/datatables.responsive.js",
                "~/Scripts/Admin/js/datatables.js",
                "~/Content/Admin//plugins/jquery-metrojs/MetroJs.min.js",
                "~/Scripts/Admin/js/core.js"));

            

            bundles.Add(new ScriptBundle("~/bundles/mainJs").IncludeDirectory("~/Scripts/Main/", "*.js", false));

            bundles.Add(new StyleBundle("~/bundles/mainCss").IncludeDirectory("~/Content/Main/css", "*.css", false));
            bundles.Add(new StyleBundle("~/bundles/mainSass").IncludeDirectory("~/Content/Main/sass", "*.sass", false));

            //bundles.Add(new StyleBundle("~/bundles/adminCss").IncludeDirectory("~/Scripts/Admin/plugins", "*.css", true)
            //                                   .IncludeDirectory("~/Content/Admin/css", "*.css"));

            bundles.Add(new StyleBundle("~/bundles/adminCss").Include(
                "~/Content/Admin/plugins/jquery-polymaps/style.css",
                "~/Content/Admin/plugins/jquery-metrojs/MetroJs.css",
                "~/Content/Admin/plugins/shape-hover/css/demo.css",
                "~/Content/Admin/plugins/shape-hover/css/component.css",
                "~/Content/Admin/plugins/owl-carousel/owl.carousel.css",
                "~/Content/Admin/plugins/owl-carousel/owl.theme.css",
                "~/Content/Admin/plugins/pace/pace-theme-flash.css",
                "~/Content/Admin/plugins/jquery-slider/css/jquery.sidr.light.css",
                "~/Content/Admin/plugins/jquery-isotope/isotope.css",
                "~/Content/Admin/plugins/boostrapv3/css/bootstrap.min.css",
                "~/Content/Admin/plugins/boostrapv3/css/bootstrap-theme.min.css",
                "~/Content/Admin/plugins/font-awesome/css/font-awesome.css",
                "~/Content/Admin/css/animate.min.css",
                "~/Content/Admin/css/style.css",
                "~/Content/Admin/css/responsive.css",
                "~/Content/Admin/css/custom-icon-set.css",
                "~/Content/Admin/css/magic_space.css",
                "~/Content/Admin/css/tiles_responsive.css",
                "~/Content/Admin/plugins/bootstrap-select2/select2.css",
                "~/Content/Admin/plugins/jquery-datatable/css/jquery.dataTables.css",
                "~/Content/Admin/plugins/boostrap-checkbox/css/bootstrap-checkbox.css",
                "~/Content/Admin/plugins/datatables-responsive/css/datatables.responsive.css"));

            ScriptManager.ScriptResourceMapping.AddDefinition(
                "respond",
                new ScriptResourceDefinition
                {
                    Path = "~/Scripts/respond.min.js",
                    DebugPath = "~/Scripts/respond.js",
                });
        }
    }
}