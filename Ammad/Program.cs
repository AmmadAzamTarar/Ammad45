using Ammad.Database;
using Ammad.JSON;
using Starcounter;

namespace Ammad
{
    internal class Program
    {
        private static void Main()
        {
            Handle.GET("/Ammad/start", (Request request) =>
            {
                if (Session.Current == null)
                {
                    Session.Current = new Session(SessionOptions.PatchVersioning);
                }
                ManageFranchisees start = null;
                Db.Scope(() =>
                {
                    start = new ManageFranchisees
                    {
                        Html = "/manageFranchisees.html",
                        Session = Session.Current
                    };
                });
                return start;
            }); 
            Handle.GET("/Ammad/franchise/{?}", (string objectId, Request request) =>
            {
                if (Session.Current == null)
                {
                    Session.Current = new Session(SessionOptions.PatchVersioning);
                }
                FranchiseSettings start = null;
                Db.Scope(() =>
                {
                    start = new FranchiseSettings
                    {
                        Html = "/franchiseSettings.html",
                        Session = Session.Current,
                        Data = Db.SQL<Franchise>("SELECT f from Ammad.Database.Franchise f where ObId = ?", objectId).First
                    };
                });
                return start;
            });
        }
    }
}