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

            bundles.Add(new ScriptBundle("~/Scripts/Custom").Include(
                  "~/Scripts/Custom/font-awesome.js",
                  "~/Scripts/Custom/jquery.js",
                  "~/Scripts/Custom/jssor.slider-25.2.0.min.js",
                  "~/Scripts/Custom/npm.js",
                  "~/Scripts/Custom/script.js",
                  "~/Scripts/Custom/smoothproducts.min.js",
                  "~/Scripts/Custom/smoothproducts.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Content/css/bootstrap-theme.min.css",
                    "~/Content/css/bootstrap.min.css",
                    "~/Content/css/bootstrap.css",
                    "~/Content/css/bootstrap-theme.css",
                    "~/Content/css/font-awesome.min.css",
                    "~/Content/css/font-awesome.css",
                    "~/Content/css/jqzoom.css",
                    "~/Content/css/smoothproducts.min.css",
                    "~/Content/css/smoothproducts.css",
                    "~/Content/css/style.css"));

            bundles.Add(new StyleBundle("~/Content/sass").Include(
                    "~/Content/sass/_basket.scss",
                    "~/Content/sass/_login.scss",
                    "~/Content/sass/_mehsulual.scss",
                    "~/Content/sass/_mypage.scss",
                    "~/Content/sass/_productsingle.scss",
                    "~/Content/sass/style.scss",
                    "~/Content/sass/_home.scss"));


            // Use the Development version of Modernizr to develop with and learn from. Then, when you’re
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                            "~/Scripts/modernizr-*"));

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