using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Inlamning1.Models;
using Inlamning1.Models.ViewModels;
using Inlamning1Data.Data;

namespace Inlamning1.Controllers
{    
        public class HomeController : Controller
        {
            private readonly BankRepository repo;
            private HomeViewModel model;

            public HomeController(BankRepository repo)
            {
                this.repo = repo;
                model = new HomeViewModel();
            }
            public IActionResult Index()
            {
                model.Customers = repo.GetAllCustomers().ToList();
                return View(model);
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
