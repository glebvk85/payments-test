using System.Net;
using System;
using System.Threading.Tasks;

namespace Monitoring
{
    public class SiteChecker : ISiteChecker
    {
        public void CheckAsync(string url, Action<bool> callback)
        {
            Task.Run(() =>
            {
                try
                {
                    var request = WebRequest.Create(url);
                    using (var response = (HttpWebResponse)request.GetResponse())
                    {
                        callback(response != null && response.StatusCode == HttpStatusCode.OK);
                    }
                }
                catch
                (WebException)
                {
                    callback(false);
                }
            });
        }
    }
}