using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Web;
using dashing.net.common;

namespace dashing.net.App_Start
{
    using System.IO;

    public class JobConfig
    {
        public static void RegisterJobs()
        {
            var jobsPath = HttpContext.Current.Server.MapPath("~/Jobs/");
            if (!Directory.Exists(jobsPath))
            {
                return;
            }

            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(jobsPath));
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));

            var container = new CompositionContainer(catalog);
            container.ComposeParts();

            var exports = container.GetExportedValues<IJob>();

            foreach (var job in exports)
            {
                Jobs.Add(job);
            }
        }
    }
}