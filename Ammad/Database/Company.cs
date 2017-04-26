using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Starcounter;

namespace Ammad.Database
{
    [Database]
    public class Company : Entity
    {
        public string Name;

        public IEnumerable<Franchise> Franchisee =>
            Db.SQL<Franchise>("Select f from Ammad.Database.Franchise f where f.Company = ?", this);
    }
}
