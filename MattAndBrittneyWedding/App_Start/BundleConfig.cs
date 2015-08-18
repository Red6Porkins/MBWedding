using System;
using System.Web;
using System.Web.Optimization;

namespace MattAndBrittneyWedding.App_Start
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles (BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                      "~/app/assets/vendorscripts/jquery-2.1.4.min.js",
                      "~/app/assets/vendorscripts/jquery.gravity.min.js",
                      "~/app/assets/vendorscripts/jquery.konami.min.js",
                      "~/app/assets/vendorscripts/angular/angular.min.js",
                      "~/app/assets/vendorscripts/angular/angular-route.min.js",
                      "~/app/assets/vendorscripts/angular/angular-animate.min.js",
                      "~/app/assets/vendorscripts/angular-ui/ui-bootstrap-tpls.min.js",
                      "~/app/assets/vendorscripts/angular-timer.min.js",
                      "~/app/assets/vendorscripts/humanize-duration.js",
                      "~/app/assets/vendorscripts/moment.min.js",
                      "~/app/assets/vendorscripts/angular-sticky.min.js", 
                      "~/app/app.module.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/controllers").Include(
                      "~/app/home/homeController.js",
                      "~/app/our-story/ourStoryController.js",
                      "~/app/gallery/galleryController.js",
                      "~/app/guestbook/guestbookController.js",
                      "~/app/admin/adminController.js",
                      "~/app/login/loginController.js",
                      "~/app/shared/page/pageController.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/directives").Include(
                     "~/app/home/homeSliderDirective.js",
                     "~/app/shared/imgLoadDirective.js",
                     "~/app/shared/scrollTop/scrollTopDirective.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/services").Include(
                     "~/app/gallery/galleryService.js",
                     "~/app/guestbook/guestbookService.js",
                     "~/app/admin/adminService.js",
                     "~/app/shared/authService.js", 
                     "~/app/shared/authInterceptorservice.js"
                      ));

            bundles.Add(new StyleBundle("~/bundles/bootstrap").IncludeWithCssRewriteTransform(
                      "~/app/assets/vendorcss/bootstrap.min.css",
                      "~/app/assets/vendorcss/ui-bootstrap-csp.css", 
                      "~/app/assets/vendorcss/nga.min.css"
                      ));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/app/assets/css/*.css"
                      ));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
        }
    }

    public static class BundleCSSFix
    {
        /// <summary>
        /// Includes the specified <paramref name="virtualPaths"/> within the bundle and attached the
        /// <see cref="System.Web.Optimization.CssRewriteUrlTransform"/> item transformer to each item
        /// automatically.
        /// </summary>
        /// <param name="bundle">The bundle.</param>
        /// <param name="virtualPaths">The virtual paths.</param>
        /// <returns>Bundle.</returns>
        /// <exception cref="System.ArgumentException">Only available to StyleBundle;bundle</exception>
        /// <exception cref="System.ArgumentNullException">virtualPaths;Cannot be null or empty</exception>
        public static Bundle IncludeWithCssRewriteTransform (this Bundle bundle, params String[] virtualPaths)
        {
            if (!(bundle is StyleBundle))
            {
                throw new ArgumentException("Only available to StyleBundle", "bundle");
            }
            if (virtualPaths == null || virtualPaths.Length == 0)
            {
                throw new ArgumentNullException("virtualPaths", "Cannot be null or empty");
            }
            IItemTransform itemTransform = new CssRewriteUrlTransform();
            foreach (String virtualPath in virtualPaths)
            {
                if (!String.IsNullOrWhiteSpace(virtualPath))
                {
                    bundle.Include(virtualPath, itemTransform);
                }
            }
            return bundle;
        }
    }
}