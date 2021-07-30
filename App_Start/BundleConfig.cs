using System.Web;
using System.Web.Optimization;

namespace demo_02
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                       "~/Scripts/bootstrap.min.js",
                       "~/Scripts/jquery-3.4.1.js",
                       "~/Scripts/jquery-3.4.1.min.js",
                       "~/Scripts/jquery-3.2.1.slim.min.js",
                       "~/Scripts/popper.min.js"
                       ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap.min.css",
                      "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Bebroom/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap.min.css",
                      "~/Content/BedroomSite.css"));
            bundles.Add(new StyleBundle("~/Livingroom/css").Include(
                     "~/Content/bootstrap.css",
                     "~/Content/bootstrap.min.css",
                     "~/Content/LivingroomSite.css"));
            bundles.Add(new StyleBundle("~/Diningroom/css").Include(
                     "~/Content/bootstrap.css",
                     "~/Content/bootstrap.min.css",
                     "~/Content/DiningroomSite.css"));
            bundles.Add(new StyleBundle("~/Workroom/css").Include(
                     "~/Content/bootstrap.css",
                     "~/Content/bootstrap.min.css",
                     "~/Content/WorkroomSite.css"));
            bundles.Add(new StyleBundle("~/Product/css").Include(
                     "~/Content/bootstrap.css",
                     "~/Content/bootstrap.min.css",
                     "~/Content/ProductSite.css"));
            bundles.Add(new StyleBundle("~/AboutUs/css").Include(
                    "~/Content/bootstrap.css",
                    "~/Content/bootstrap.min.css",
                    "~/Content/aboutusSite.css"));


            bundles.Add(new ScriptBundle("~/bundles/script_furniture").Include(
                      "~/Scripts/js/jquery-2.1.4.min.js",

                        "~/Scripts/js/jquery.magnific-popup.js",
                        "~/Scripts/js/minicart.js",
                        //"~/Scripts/js/SmoothScroll.min.js",
                        "~/Scripts/js/move-top.js",
                        "~/Scripts/js/easing.js",

                        //"~/Scripts/js/jquery-ui.js",

                        "~/Scripts/js/imagezoom.js",
                        "~/Scripts/js/jquery.flexslider.js",
                        "~/Scripts/js/jquery.flexisel.js",
                        "~/Scripts/js/bootstrap.js"
                       ));

            bundles.Add(new ScriptBundle("~/bundles/furniture_detail").Include(
                      "~/Scripts/js/jquery-2.1.4.min.js",

                        "~/Scripts/js/jquery.magnific-popup.js",
                        "~/Scripts/js/imagezoom.js",
                        "~/Scripts/js/jquery.flexisel.js"
                       ));

            bundles.Add(new StyleBundle("~/Content/furniture_css").Include(
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/style.css",
                      "~/Content/css/popuo-box.css",
                      "~/Content/css/jquery-ui1.css"
                      /*"~/Content/css/flexslider.css"*/));

        }
    }
}
