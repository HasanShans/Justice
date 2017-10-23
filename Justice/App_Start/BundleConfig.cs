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

            bundles.Add(new StyleBundle("~/bundles/adminCss").Include(
               "~/Content/Admin/css/bootstrap.css",
               "~/Content/Admin/css/font-awesome.min.css",
               "~/Content/Admin/css/ionicons.css",
               "~/Content/Admin/css/dataTables.bootstrap.css",
               "~/Content/Admin/css/AdminLTE.css",
               "~/Content/Admin/css/_all-skins.css"
               ));

            bundles.Add(new ScriptBundle("~/bundles/adminJs").Include(
                "~/Scripts/Admin/js/jquery.js",
                "~/Scripts/Admin/js/bootstrap.js",
                "~/Scripts/Admin/js/jquery.dataTables.js",
                "~/Scripts/Admin/js/dataTables.bootstrap.js",
                "~/Scripts/Admin/js/jquery.slimscroll.js",
                "~/Scripts/Admin/js/fastclick.js",
                "~/Scripts/Admin/js/adminlte.js",
                "~/Scripts/Admin/js/demo.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/mainJs").IncludeDirectory("~/Scripts/Main/", "*.js", false));
            bundles.Add(new StyleBundle("~/bundles/mainCss").IncludeDirectory("~/Content/Main/css", "*.css", false));
            bundles.Add(new StyleBundle("~/bundles/mainSass").IncludeDirectory("~/Content/Main/sass", "*.sass", false));

            //bundles.Add(new StyleBundle("~/bundles/adminCss").IncludeDirectory("~/Scripts/Admin/plugins", "*.css", true)
            //                                   .IncludeDirectory("~/Content/Admin/css", "*.css"));

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