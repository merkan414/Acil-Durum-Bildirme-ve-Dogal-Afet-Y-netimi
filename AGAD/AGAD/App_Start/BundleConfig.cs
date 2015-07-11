using System.Web;
using System.Web.Optimization;

namespace AGAD
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                                        "~/Scripts/jquery.validate*"));

            

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/jquery-ui.css",
                      "~/Content/style.css",
                      "~/Content/slimmenu.css",
                      "~/Content/plupload-2.1.7/js/jquery.ui.plupload/css/jquery.ui.plupload.css"
                      ));
        }
    }
}
