using Monitoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteMonitoring.Tests.Fakes
{
    class SiteCheckerFake : ISiteChecker
    {
        public bool CheckAsyncResult { get; set; }

        public void CheckAsync(string url, Action<bool> callback)
        {
            callback(CheckAsyncResult);
        }
    }
}
