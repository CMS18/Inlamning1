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
        public class HomeController : Controller
        {
            private readonly BankRepository repo;
           

            public HomeController(BankRepository repo)
            {
                this.repo = repo;
                
            }
            public IActionResult Index()
            {
            var viewmodel = new CustAcctViewModel
            {
                accounts = repo.accounts,
                customers = repo.customers
            };
                return View(viewmodel);
            }

            public IActionResult Privacy()
            {
                return View();
            }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }
