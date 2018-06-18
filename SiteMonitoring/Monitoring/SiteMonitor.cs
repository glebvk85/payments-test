﻿using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseWork.Entities;
using System.Threading;

namespace Monitoring
{
    public class SiteMonitor
    {
        private static SiteInfo[] sites;

        public static IEnumerable<SiteInfo> GetSiteStatuses()
        {
            return sites;
        }

        public static void Init(params Site[] sites)
        {
            SiteMonitor.sites = sites.Select(e => new SiteInfo(e)).ToArray();
        }

        public static void Start()
        {
            var checker = new SiteChecker();
            var thread = new Thread((state) =>
            {
                long leftSeconds = 0;
                while (true)
                {
                    int minPeriod = Math.Max((int)sites.Select(e => e.Site.CheckPeriodInSeconds - leftSeconds % e.Site.CheckPeriodInSeconds).Min(), 1);
                    Thread.Sleep(minPeriod * 1000);
                    leftSeconds += minPeriod;
                    foreach (var site in sites.Where(e => leftSeconds % e.Site.CheckPeriodInSeconds == 0))
                    {
                        checker.CheckAsync(site.Site.Url, (status) => { site.IsAvailable = status; });
                    }
                }
            });
            thread.Start();
        }
    }
}
