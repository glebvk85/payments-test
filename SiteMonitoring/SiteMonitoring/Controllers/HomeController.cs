using DatabaseWork;
using SiteMonitoring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Monitoring;

namespace SiteMonitoring.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var sites = SiteMonitor.GetSiteStatuses().ToList();
            return View(sites.Select(e => new CheckStatusInfo() { Url = e.Site.Url, IsAvailable = e.IsAvailable }));
        }
    }
}