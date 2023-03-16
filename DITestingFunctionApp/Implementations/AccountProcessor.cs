using DITestingFunctionApp.Classes;
using DITestingFunctionApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DITestingFunctionApp.Implementations
{
    class AccountProcessor : IAccountProcessor
    {
        // I wouldn't usually do this, but it's to express interdependence between two processes. 
        private readonly IAccountProvider _accountProvider;
        public AccountProcessor(IAccountProvider accountProvider)
        {
            _accountProvider = accountProvider;
        }

        public int Process()
        {
            // This would have some processing, usually. This implementation just loops through and adds together all the Account ids.
            List<Account> accounts = _accountProvider.GetAccounts();
            int idTotal = new();
            foreach (Account acc in accounts)
            {
                idTotal = idTotal + acc.id;
            }
            return idTotal;
        }

    }
}
