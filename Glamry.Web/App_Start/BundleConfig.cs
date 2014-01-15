using System.Web.Optimization;

namespace Glamry.Web
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterStyleBundles(bundles);
            RegisterJavascriptBundles(bundles);
        }

        private static void RegisterStyleBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/css")
                          .Include("~/Content/bootstrap.css")
                .Include("~/Content/bootstrap-colorselector.css")
                            .Include("~/Content/carousel.css")
                            .Include("~/Content/pick-a-color-1.1.8.min.css")
                // .Include("~/Content/docs.css")
                // .Include("~/Content/prettify.css")
                            .Include("~/Content/site.css")
                            );
        }

        private static void RegisterJavascriptBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js")
         .Include("~/Scripts/jquery-{version}.js")
                           .Include("~/Scripts/jquery-ui-{version}.js")
                           .Include("~/Scripts/tinycolor-0.9.15.min.js")
                //.Include("~/Scripts/modernizr-2.7.1.js")
                            .Include("~/Scripts/pick-a-color.js")
                //.Include("~/Scripts/angular.min.js")
                            .Include("~/Scripts/bootstrap-colorselector.js")
                            .Include("~/Scripts/shemiloge.js")
                            .Include("~/Scripts/bootstrap.js"));

        }
    }
}