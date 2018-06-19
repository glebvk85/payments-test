using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Monitoring;
using DatabaseWork;
using DatabaseWork.Repositories.Interfaces;
using DatabaseWork.Repositories;
using System.Net;

namespace SiteMonitoring
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager
                .ServerCertificateValidationCallback +=
                (sender, cert, chain, sslPolicyErrors) => true;

            string pathFile = HttpContext.Current.Server.MapPath("~/App_Data/sites.csv");
            var siteRepository = new SiteRepository(pathFile);
            var service = new SiteService(siteRepository);
            var sites = service.GetAllSites();
            var siteChecker = new SiteChecker();

            SiteMonitor.Init(siteChecker, sites.ToArray());
            SiteMonitor.Start();
        }
    }
}
