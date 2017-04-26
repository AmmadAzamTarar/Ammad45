using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Starcounter;

namespace Ammad.Database
{
    [Database]
    public class Franchise : Entity
    {
        public string Name;
        public Address Address;
        public Company Company;

        public IEnumerable<Transaction> Transactions =>
            Db.SQL<Transaction>("Select t from Ammad.Database.Transaction t where t.Franchise = ?", this);

        public long NumberOfHomesSold => 
            Db.SQL<long>("SELECT count(t) FROM Ammad.Database.Transaction t where t.Franchise = ?", this).First;

        public long TotalCommission => 
            (long)Db.SQL<decimal>("SELECT sum(t.Commission) FROM Ammad.Database.Transaction t where t.Franchise = ?", this).First;

        public long AverageCommission => 
            (long)Db.SQL<decimal>("SELECT avg(t.Commission) FROM Ammad.Database.Transaction t where t.Franchise = ?", this).First;
    }
}
