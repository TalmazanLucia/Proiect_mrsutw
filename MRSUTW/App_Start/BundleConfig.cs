using System;
using System.Web.Optimization;

namespace MRSUTW
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include(
                "~/Content/themes/bootstrap.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/font-awesome/css").Include(
                "~/Content/themes/font-awesome.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/flaticon/css").Include(
                "~/Content/themes/flaticon.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/owl-carousel/css").Include(
                "~/Content/themes/owl.carousel.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/barfiller/css").Include(
                "~/Content/themes/barfiller.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/magnific-popup/css").Include(
                "~/Content/themes/magnific-popup.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/slicknav/css").Include(
                "~/Content/themes/slicknav.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/style/css").Include(
                "~/Content/themes/style.css", new CssRewriteUrlTransform()));

            bundles.Add(new ScriptBundle("~/bundles/jquery-3.3.1/js").Include(
                "~/Scripts/jquery-3.3.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap/js").Include(
                "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery.magnific-popup/js").Include(
                "~/Scripts/jquery.magnific-popup.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/masonry-pkgd/js").Include(
                "~/Scripts/masonry.pkgd.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-barfiller/js").Include(
                "~/Scripts/jquery.barfiller.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-slicknav/js").Include(
                "~/Scripts/jquery.slicknav.js"));

            bundles.Add(new ScriptBundle("~/bundles/owl-carousel/js").Include(
                "~/Scripts/owl.carousel.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/main/js").Include(
                "~/Scripts/main.js"));

        }
    }

}
