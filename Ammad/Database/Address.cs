using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Starcounter;

namespace Ammad.Database
{
    [Database]
    public class Address
    {
        public string Street;
        public string Number;
        public int ZipCode;
        public string City;
        public string Country;

        public string FullAddress => $"{Street} {Number}, {ZipCode} {City}, {Country}";
    }
}
