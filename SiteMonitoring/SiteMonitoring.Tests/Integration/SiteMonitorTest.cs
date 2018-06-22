using DatabaseWork.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monitoring;
using Moq;
using SiteMonitoring.Tests.Fakes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SiteMonitoring.Tests.Integration
{
    [TestClass]
    class SiteMonitorTest
    {
        [TestMethod]
        public void Test()
        {
            var site = new Site() { CheckPeriodInSeconds = 1, Url = "https://google.com" };
            var siteChecker = new SiteCheckerFake() { CheckAsyncResult = true };

            SiteMonitor.Init(siteChecker, site);

            SiteMonitor.Start();
            Thread.Sleep(3000);
            SiteMonitor.Stop();

            Assert.IsTrue(SiteMonitor.GetSiteStatuses().First().IsAvailable);
        }
    }
}
