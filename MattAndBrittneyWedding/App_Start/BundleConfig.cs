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
                      "~/app/assets/vendorscripts/angular/angular.min.js",
                      "~/app/assets/vendorscripts/angular/angular-route.min.js",
                      "~/app/assets/vendorscripts/angular/angular-animate.min.js",
                      "~/app/assets/vendorscripts/angular-ui/ui-bootstrap-tpls.min.js",
                      "~/app/assets/vendorscripts/angular-timer.min.js",
                      "~/app/assets/vendorscripts/humanize-duration.js",
                      "~/app/assets/vendorscripts/moment.min.js", 
                      "~/app/app.module.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/controllers").Include(
                      "~/app/home/homeController.js",
                      "~/app/shared/page/pageController.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/directives").Include(
                     "~/app/shared/sidebar/sidebar.js"
                      ));

            bundles.Add(new StyleBundle("~/bundles/bootstrap").Include(
                      "~/app/assets/vendorcss/bootstrap.min.css",
                      "~/app/assets/vendorcss/ui-bootstrap-csp.css", 
                      "~/app/assets/vendorcss/nga.min.css"
                      ));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/app/assets/css/*.css"
                      ));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = false;
        }
    }
}