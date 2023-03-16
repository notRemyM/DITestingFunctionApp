using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DITestingFunctionApp.Classes;
using DITestingFunctionApp.Interfaces;

namespace DITestingFunctionApp.Providers
{
    public class AccountProvider : IAccountProvider
    {
        public List<Account> GetAccounts() 
        {
            // blah blah, logic etc. this would be your API/SQL/Dataverse account details retrieval method.
            // Will be replaced with other dummy data during the unit test process
            var accounts = new List<Account>();

            accounts.Add(new Account { id = 1, name = "Remy", password = "Test" });
            accounts.Add(new Account { id = 2, name = "Remy", password = "Test" });
            accounts.Add(new Account { id = 3, name = "Remy", password = "Test" });
            accounts.Add(new Account { id = 4, name = "Remy", password = "Test" });
            accounts.Add(new Account { id = 5, name = "Remy", password = "Test" });
            accounts.Add(new Account { id = 6, name = "Remy", password = "Test" });
            accounts.Add(new Account { id = 7, name = "Remy", password = "Test" });
            accounts.Add(new Account { id = 8, name = "Remy", password = "Test" });

            return accounts;
        }

    }
}
