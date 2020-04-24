using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CRM.Data;
using Microsoft.AspNetCore.Mvc;
using CRM.Models;

namespace CRM.Controllers
{
    public class HomeController : Controller
    {
        private readonly CRMContext _context;

        public HomeController(CRMContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            ViewData["CustomerList"] = _context.Customers.ToList<Customer>();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
