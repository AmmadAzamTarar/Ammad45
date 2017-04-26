using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Starcounter;

namespace Ammad.Database
{
    [Database]
    public class Transaction
    {
        public Home Home;
        public DateTime Start;
        public long TransactionValue;
        public long Commission;

        public Franchise Franchise;
    }
}
