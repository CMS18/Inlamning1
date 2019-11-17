using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inlamning1.Models
{
    public class BankRepository
    {
        public List<Customer> customers { get; set; } = new List<Customer>();
        public List<Account> accounts { get; set; } = new List<Account>();

        public BankRepository()
        {
            customers.Add(new Customer { customerId = 1, customerName = "Parang" });
            customers.Add(new Customer { customerId = 2, customerName = "Ellen" });
            customers.Add(new Customer { customerId = 3, customerName = "Caroline" });

            accounts.Add(new Account { accountId = 1, balance = 100m });
            accounts.Add(new Account { accountId = 2, balance = 2000m });
            accounts.Add(new Account { accountId = 3, balance = 3000m });
        }
    }
}
