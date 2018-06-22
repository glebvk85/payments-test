using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SiteMonitoring;
using SiteMonitoring.Controllers;
using Monitoring;
using Moq;
using DatabaseWork.Entities;

namespace SiteMonitoring.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexTest()
        {
            var controller = new HomeController();
            SiteMonitor.Init(Mock.Of<ISiteChecker>(), new Site());

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }
    }
}
