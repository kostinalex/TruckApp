using System.Web;
using System.Web.Optimization;

namespace TruckApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                            "~/Scripts/jquery-{version}.js",
                            "~/Scripts/bootstrap.js",
                            "~/Scripts/bootbox.js",
                            "~/Scripts/bootstrap-datepicker.js",
                            "~/Scripts/respond.js",
                            "~/Scripts/DataTables/jquery.datatables.js",
                            "~/Scripts/typeahead.bundle.js",
                            "~/Scripts/DataTables/datatables.bootstrap.js"
                         ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-lumen.css",
                      "~/Content/DataTables/css/dataTables.bootstrap4.css",
                      "~/Content/typeahead.css",
                      "~/Content/datepicker.css"));

            bundles.Add(new StyleBundle("~/ContentDefault/css").Include(
                  "~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/ContentDark/css").Include(
                            "~/Content/SiteDark.css"));
        }
    }
}
