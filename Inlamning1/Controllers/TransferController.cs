using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Inlamning1.Models;
using Inlamning1.Models.ViewModels;

namespace Inlamning1.Controllers
{
    public class TransferController : Controller
    {
        private readonly BankRepository repo;

        public TransferController(BankRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Transfer(int fromacc, int toacc, decimal amount)
        {
            var fromAcc = repo.accounts.SingleOrDefault(a => a.accountId == fromacc);
            var toAcc = repo.accounts.SingleOrDefault(a => a.accountId == toacc);
            if (fromacc == toacc)
            {
                TempData["info"] = "From account & to account cannot be same";
            }
            else if (fromAcc != null || toAcc != null)
            {
                try
                {
                    repo.Transfer(fromAcc, toAcc, amount);
                    TempData["info"] = $"Successfully transfered from account {fromAcc.accountId} (new balance: {fromAcc.balance}) " +
                        $"to account {toAcc.accountId} (new balance {toAcc.balance})";
                }
                catch(ArgumentOutOfRangeException)
                {
                    TempData["info"] = "Invalid or too big amount";
                }
            }
            else
            {
                TempData["info"] = "Invalid account id";
            }
            return View("Index");
        }
    }
}
