using DatabaseWork.Entities;

namespace Monitoring
{
    public class SiteInfo
    {
        public Site Site { get; private set; }
        public bool IsAvailable { get; set; }

        public SiteInfo(Site site)
        {
            Site = site;
            IsAvailable = false;
        }
    }
}
