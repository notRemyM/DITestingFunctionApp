using DITestingFunctionApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DITestingFunctionApp.Interfaces
{
    public interface IAccountProcessor
    {
        public int Process(List<Account> accounts);
    }
}
