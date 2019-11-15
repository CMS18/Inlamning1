using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inlamning1.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inlamning1.Controllers
{
    public class AccountController : Controller
    {
        private readonly BankRepository _repo;
        public AccountController(BankRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Withdraw(int acctId, decimal amount)
        {
            var account = _repo.accounts.Where(m => m.accountId == acctId).SingleOrDefault();
            if (account != null)
            {
                try
                {
                    _repo.Withdraw(account, amount);
                    TempData["info"] = "New balance:" + account.balance;
                }

                catch(ArgumentException)
                {
                    TempData["info"] = "Higher than balance!! try again.";
                }
            }
            else
            {
                TempData["info"] = "Wrong account!";
            }
                        
            return RedirectToAction("Index");
        }

        public IActionResult Deposit(decimal amount, int acctId)
        {
            var account = _repo.accounts.Where(m => m.accountId == acctId).SingleOrDefault();

            if (account != null)
            {
                try
                {
                    _repo.Deposit(account, amount);
                    TempData["info"] = "New balance:" + account.balance;
                }
                catch(ArgumentException)
                {
                    TempData["info"] = "Amount should be higher than zero";
                }
            }
            else
            {
                TempData["info"] = "Wrong account";
            }

            return RedirectToAction("Index");
        }
    }
}
