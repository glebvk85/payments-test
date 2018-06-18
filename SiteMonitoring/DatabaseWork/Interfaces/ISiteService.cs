using DatabaseWork.Entities;
using System.Collections.Generic;

namespace DatabaseWork.Interfaces
{
    public interface ISiteService
    {
        IList<Site> GetAllSites();
    }
}
