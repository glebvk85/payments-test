using System;

namespace Monitoring
{
    public interface ISiteChecker
    {
        void CheckAsync(string url, Action<bool> callback);
    }
}
