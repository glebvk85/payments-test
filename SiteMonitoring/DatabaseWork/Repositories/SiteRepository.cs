using DatabaseWork.Entities;
using DatabaseWork.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseWork.Repositories
{
    public class SiteRepository : ISiteRepository
    {
        private readonly string pathFile;

        public SiteRepository(string pathFile)
        {
            this.pathFile = pathFile;
        }

        public IEnumerable<Site> GetAll()
        {
            var content = File.ReadAllLines(pathFile);
            foreach ( var row in content)
            {
                var fields = row.Split(';');
                yield return new Site() { Url = fields[0], CheckPeriodInSeconds = int.Parse(fields[1]) };
            }
        }
    }
}
