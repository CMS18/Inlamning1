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

        public void Withdraw(Account account, decimal WdAmount)
        {
            if(WdAmount > 0 && account.balance >= WdAmount )
            {
                account.balance -= WdAmount;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void Deposit(Account account, decimal DpAmount)
        {
            if(DpAmount > 0)
            {
                account.balance += DpAmount;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void Transfer(Account from, Account to, decimal amount)
        {
            if (amount > 0 && from.balance >= amount && int.TryParse(amount.ToString(), out int i))
            {
                from.balance -= amount;
                to.balance += amount;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
         
        }
    }
}
