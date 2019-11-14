using System;
using System.Collections.Generic;
using System.Text;

namespace Inlamning1Data.Data
{
    public class BankRepository
    {
        private static List<Customer> Customers = new List<Customer>
        {
            new Customer
            {
                Id = 1,
                Name = "Parang",
                Accounts = new List<Account>
                {
                    new Account
                    {
                        AccountId = 111, Balance = 30000
                    }
                }
            },

            new Customer
            {
                Id = 2,
                Name = "Ellen",
                Accounts = new List<Account>
                {
                    new Account
                    {
                        AccountId = 333, Balance = 6000000
                    }
                }
            },

            new Customer
            {
                Id = 3,
                Name = "Caroline",
                Accounts = new List<Account>
                {
                    new Account
                    {
                        AccountId = 444, Balance = 500
                    }
                }
            }
        };

        public IList<Customer> GetAllCustomers()
        {
            return Customers;
        }
    }
}
