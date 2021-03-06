﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using dashing.net.Infrastructure;

namespace dashing.net.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            var application = new ScriptBundle("~/bundles/application-js")
                .Include("~/Scripts/jquery-{version}.js")
                .Include("~/Scripts/jquery.signalR-{version}.js")
                .Include("~/Scripts/signalr-hubs.js")
                .Include("~/Scripts/es5-shim.js")
                .Include("~/Scripts/batman.js")
                .Include("~/Scripts/batman.jquery.js")
                .Include("~/Scripts/dashing.js")
                .Include("~/Scripts/jquery.leanModal.min.js")
                .Include("~/Scripts/jquery.knob.js")
                .Include("~/Scripts/d3.v3.js")
                .Include("~/Scripts/rickshaw.js")
                .Include("~/Scripts/jquery.gridster.js")
                .Include("~/Scripts/dashing.gridster.js")
                .Include("~/Scripts/application.js")
                .Include("~/Scripts/highcharts.js")
                .IncludeDirectory("~/Widgets", "*.js", true);

            bundles.Add(application);

            var styles = new Bundle("~/bundles/application-css")
                .Include("~/Content/css/font-awesome.css")
                .Include("~/Content/jquery.gridster.css")
                .IncludeDirectory("~/Widgets", "*.css", true)
                .Include("~/Content/application.css");

            bundles.Add(styles);
        }
    }
}