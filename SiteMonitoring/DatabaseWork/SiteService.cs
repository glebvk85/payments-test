using DatabaseWork.Interfaces;
using System;
using System.Collections.Generic;
using DatabaseWork.Entities;
using DatabaseWork.Repositories.Interfaces;

namespace DatabaseWork
{
    public class SiteService : ISiteService
    {
        private readonly ISiteRepository siteRepository;

        public SiteService(ISiteRepository siteRepository)
        {
            this.siteRepository = siteRepository;
        }

        public IEnumerable<Site> GetAllSites()
        {
            return siteRepository.GetAll();
        }
    }
}
