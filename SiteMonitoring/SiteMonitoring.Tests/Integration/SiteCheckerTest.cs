using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monitoring;
using System.Threading;
using System.Net;

namespace SiteMonitoring.Tests.Integration
{
    [TestClass]
    class SiteCheckerTest
    {
        [TestMethod]
        public void CheckUrlFail()
        {
            var siteChecker = new SiteChecker();
            bool result = true;
            var wait = new ManualResetEvent(false);
            string url = "bad_link";

            siteChecker.CheckAsync(url, (status) => { result = status; wait.Set();  });
            wait.WaitOne();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckUrlSuccess()
        {
            var siteChecker = new SiteChecker();
            bool result = true;
            var wait = new ManualResetEvent(false);
            string url = "https://google.com";

            siteChecker.CheckAsync(url, (status) => { result = status; wait.Set(); });
            wait.WaitOne();

            Assert.IsTrue(result);
        }
    }
}
