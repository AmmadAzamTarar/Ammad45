using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ammad.Database;
using Starcounter;

namespace Ammad.JSON
{
    partial class ManageFranchisees : Starcounter.Page
    {
        public IEnumerable<Company> Companies_ =>
            Db.SQL<Company>("select c from Ammad.Database.Company c");        

        void Handle(Input.Create action)
        {
            new Company
            {
                Name = NewCompany.Name
            };
            Transaction.Commit();
        }

        [ManageFranchisees_json.Companies]
        public partial class InvoicePageItems : Json
        {
            public Company ParentCompany => Data as Company;

            private IEnumerable<Franchise> _franchises;
            public IEnumerable<Franchise> FranchiseeList_ => _franchises ?? ParentCompany.Franchisee;

            public void RefreshList()
            {
                var query = new StringBuilder("Select f from Ammad.Database.Franchise f where f.Company = ?");
                if (!string.IsNullOrWhiteSpace(SortBy))
                {
                    query.Append($"Order by {SortBy} DESC");
                }
                _franchises = Db.SQL<Franchise>(query.ToString(), ParentCompany);
            }

            void Handle(Input.Create action)
            {
                new Franchise
                {
                    Address = new Address(),
                    Company = ParentCompany,
                    Name = NewFranchise.Name
                };

                Transaction.Commit();
            }

            void Handle(Input.SortAverageCommission action)
            {
                SortBy = nameof(Franchise.AverageCommission);
                RefreshList();
            }
            void Handle(Input.SortNumberOfHomesSold action)
            {
                SortBy = nameof(Franchise.NumberOfHomesSold);
                RefreshList();
            }
            void Handle(Input.SortTotalCommission action)
            {
                SortBy = nameof(Franchise.TotalCommission);
                RefreshList();
            }
            void Handle(Input.SortPositiveTrend action)
            {
            }
        }
    }
}
