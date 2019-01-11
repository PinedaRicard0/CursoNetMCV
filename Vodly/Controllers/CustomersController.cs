using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vodly.Models;

namespace Vodly.Controllers
{
    public class CustomersController : Controller
    {
        List<Customer> customers = new List<Customer>
            {
                new Customer { Name = "Ricardo Pineda", Id = 1},
                new Customer { Name = "Patricia Montoya", Id = 2},
            };
        // GET: Customers
        public ViewResult Index()
        {
            return View(customers);
        }

        public ActionResult CustomerDetail(int id)
        {
            var item = customers.Where(a => a.Id == id).FirstOrDefault();
            if (item != null)
                return View("CustomerDetail", item);
            else
                return HttpNotFound();
        }
    }
}