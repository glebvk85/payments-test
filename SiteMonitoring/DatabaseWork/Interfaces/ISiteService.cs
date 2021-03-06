﻿using DatabaseWork.Entities;
using System.Collections.Generic;

namespace DatabaseWork.Interfaces
{
    public interface ISiteService
    {
        IEnumerable<Site> GetAllSites();
    }
}
