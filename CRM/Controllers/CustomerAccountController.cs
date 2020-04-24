using System.Collections.Generic;
using System.Linq;
using CRM.Data;
using CRM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using SQLitePCL;

namespace CRM.Controllers
{
    public class CustomerAccountController : Controller
    {
        private readonly CRMContext _context;

        public CustomerAccountController(CRMContext context)
        {
            _context = context;
        }
        // GET
        public IActionResult Index(int custaccid)
        {
            var caProd = _context.CustomerAccountProducts.Where(c => c.CustomerAccoountId == custaccid).ToList();
            List<Product> products = caProd
                .Select(i => _context.Products.Where(p => p.ID == i.ProductId).SingleOrDefault()).ToList();
            var custAcc = _context.CustomerAccounts.SingleOrDefault(c => c.ID == custaccid);
            var customer = _context.Customers.SingleOrDefault(c => c.ID == custAcc.CustomerId);

            ViewData["Customer"] = customer;
            ViewData["CurrentCustomerAccount"] = custAcc;
            ViewData["Products"] = products;
            return View();
        }

        public IActionResult Create(int custid)
        {
            // _context.CustomerAccounts.Add(new CustomerAccount{})
            ViewData["Filials"] = _context.Filials.ToList();
            ViewData["CurrentCustomer"] = _context.Customers.SingleOrDefault(c => c.ID == custid);
            return View();
        }

        [HttpPost]
        public IActionResult Create(IFormCollection collection)
        {
            int filialId;
            int.TryParse(collection["Filial"], out filialId);
            int customerId;
            int.TryParse(collection["CustomerId"], out customerId);

            _context.CustomerAccounts.Add(new CustomerAccount {CustomerId = customerId, FilialId = filialId});
            _context.SaveChanges();
            return Redirect("/Customer/Details?id="+customerId);
        }
    }
}