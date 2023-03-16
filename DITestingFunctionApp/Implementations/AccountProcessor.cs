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
        public int Process(List<Account> accounts)
        {
            // This would have some processing, usually. This implementation just loops through and adds together all the Account ids.
            int idTotal = new();
            foreach (Account acc in accounts)
            {
                idTotal = idTotal + acc.id;
            }
            return idTotal;
        }

    }
}
