using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inlamning1.Models.ViewModels
{
    public class CustAcctViewModel
    {
        public List<Customer> customers { get; set; }
        public List<Account> accounts { get; set; }
    }
}