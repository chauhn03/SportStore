﻿using System.Web.Optimization;

namespace SportsStore.WebUI
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

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

            bundles.Add(new StyleBundle("~/Content/themes/smoothness/css").Include(
                     "~/Content/themes/smoothness/jquery-ui.css",
                     "~/Content/themes/smoothness/jquery-ui.min.css",
                     "~/Content/themes/smoothness/jquery.ui.theme.css"
                  ));

            bundles.Add(new StyleBundle("~/Content/themes/ui-lightness/css").Include(
                   "~/Content/themes/ui-lightness/jquery-ui.css",
                   "~/Content/themes/ui-lightness/jquery-ui.min.css",
                   "~/Content/themes/ui-lightness/jquery.ui.theme.css"
                ));

            #region Admin
            bundles.Add(new StyleBundle("~/Content/bluewhale-admin/css").Include(
                      "~/Content/admin/css/reset.css",
                      "~/Content/admin/css/text.css",
                      "~/Content/admin/css/grid.css",
                      "~/Content/admin/css/layout.css",
                      "~/Content/admin/css/nav.css",
                      "~/Content/admin/css/css/table/demo_page.css",
                      "~/Content/admin/css/css/table/demo_table.css",
                      "~/Content/admin/css/css/table/demo_table_jui.css"
                      ));

            //bundles.Add(new StyleBundle("~/bundles/bluewhale_admin_jquery").Include(
            //          "~/Content/admin/js/jquery-1.6.4.min.js"));

            //bundles.Add(new StyleBundle("~/bundles/bluewhale_admin_jquery_ui").Include(
            //          "~/Content/admin/js/jquery-ui/jquery.ui.core.min.js",
            //          "~/Content/admin/js/jquery-ui/jquery.ui.widget.min.js",
            //          "~/Content/admin/js/jquery-ui/jquery.ui.accordion.min.js",
            //          "~/Content/admin/js/jquery-ui/jquery.effects.core.min.js",
            //          "~/Content/admin/js/jquery-ui/jquery.effects.slide.min.js",
            //          "~/Content/admin/js/jquery-ui/jquery.ui.mouse.min.js",
            //          "~/Content/admin/js/jquery-ui/jquery.ui.sortable.min.js"
            //          ));
            #endregion
        }
    }
}