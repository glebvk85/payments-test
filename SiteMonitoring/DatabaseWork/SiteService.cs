using DatabaseWork.Interfaces;
using System;
using System.Collections.Generic;
using DatabaseWork.Entities;

namespace DatabaseWork
{
    public class SiteService : ISiteService
    {
        public IList<Site> GetAllSites()
        {
            return new List<Site>{ new Site()
            { Url = "https://google.com", CheckPeriodInSeconds = 5 },
          // new Site() { Url = "http://google.com/22", CheckPeriodInSeconds = 2 },
         //  new Site() { Url = "http://google.com/333", CheckPeriodInSeconds = 3 },
            };
        }
    }
}
