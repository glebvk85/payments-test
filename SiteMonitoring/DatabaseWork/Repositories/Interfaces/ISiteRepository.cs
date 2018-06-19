using DatabaseWork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseWork.Repositories.Interfaces
{
    public interface ISiteRepository
    {
        IEnumerable<Site> GetAll();
    }
}
