using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Apsis.TenPinBowling.Simulator.App_Start
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui-{version}.js",
                        "~/Scripts/jquery.blockUI.js",
                        "~/Scripts/knockout-{version}.js",
                        "~/Scripts/knockout.validation.js",
                        "~/Scripts/knockout.bindings.js"));

            //Score card boundle
            bundles.Add(new ScriptBundle("~/bundles/scorecard").Include(
                    "~/Scripts/ScoreCard/Frame.js",
                    "~/Scripts/ScoreCard/ScoreCard.js",
                    "~/Scripts/ScoreCard/Controller.js"
                ));

            bundles.Add(new StyleBundle("~/bundles/styles").Include(
                    "~/Content/themes/base/core.css",
                    "~/Content/themes/base/accordion.css",
                    "~/Content/themes/base/autocomplete.css",
                    "~/Content/themes/base/button.css",
                    "~/Content/themes/base/datepicker.css",
                    "~/Content/themes/base/dialog.css",
                    "~/Content/themes/base/draggable.css",
                    "~/Content/themes/base/menu.css",
                    "~/Content/themes/base/progressbar.css",
                    "~/Content/themes/base/resizable.css",
                    "~/Content/themes/base/selectable.css",
                    "~/Content/themes/base/selectmenu.css",
                    "~/Content/themes/base/sortable.css",
                    "~/Content/themes/base/slider.css",
                    "~/Content/themes/base/spinner.css",
                    "~/Content/themes/base/tabs.css",
                    "~/Content/themes/base/tooltip.css",
                    "~/Content/themes/base/theme.css",
                    "~/Content/simplegrid.css"
                ));


            bundles.Add(new StyleBundle("~/bundles/main").Include(
                    "~/Content/main.css"
                ));
            

         

       
        }
    }
}