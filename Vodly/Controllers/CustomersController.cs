using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vodly.Models;
using Vodly.ViewModels;

namespace Vodly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
        public ViewResult Index()
        {
            return View();
        }

        public ActionResult CustomerDetail(int id)
        {
            var item = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (item != null)
                return View("CustomerDetail", item);
            else 
                return HttpNotFound();
        }

        public ActionResult New()
        {
            var memberShipTypes = _context.MemberShipTypes.ToList();
            var viewModel = new CustomerFormViewModel {
                MemberShipTypes = memberShipTypes
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (customer.Id == 0)
                    _context.Customers.Add(customer);
                else
                {
                    var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                    customerInDb.Name = customer.Name;
                    customerInDb.Birthday = customer.Birthday;
                    customerInDb.MemberShipTypeId = customer.MemberShipTypeId;
                    customerInDb.IsSubscribeToNewsLetter = customer.IsSubscribeToNewsLetter;
                }
                _context.SaveChanges();
                return RedirectToAction("Index", "Customers");
            }
            else {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MemberShipTypes = _context.MemberShipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MemberShipTypes = _context.MemberShipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }
    }
}