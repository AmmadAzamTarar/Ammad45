using System;
using System.Collections.Generic;
using Ammad.Database;
using Starcounter;
using Transaction = Ammad.Database.Transaction;

namespace Ammad.JSON
{
    partial class FranchiseSettings : Starcounter.Page
    {
        Franchise Franchise => Data as Franchise;

        public IEnumerable<Transaction> Transactions_ =>
            Franchise.Transactions;

        void Handle(Input.Save action)
        {
            Transaction.Commit();
        }

        void Handle(Input.Create action)
        {
            var newTransaction = new Transaction()
            {
                Commission = NewTransaction.Commission,
                Franchise = Franchise,
                Home = new Home()
                {
                    Address = new Address()
                    {
                        City = NewTransaction.Home.Address.City,
                        Country = NewTransaction.Home.Address.Country,
                        Number= NewTransaction.Home.Address.Number,
                        Street= NewTransaction.Home.Address.Street,
                        ZipCode= (int)NewTransaction.Home.Address.ZipCode,
                    }
                },
                Start = DateTime.Parse(NewTransaction.Start),
                TransactionValue = NewTransaction.TransactionValue
            };
            newTransaction.Home.Transaction = newTransaction;

            Transaction.Commit();
        }
    }
}
