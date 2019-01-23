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
            var customers = _context.Customers.Include(c => c.MemberShipType).ToList();
            return View(customers);
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
            var viewModel = new NewCustomerViewModel {
                MemberShipTypes = memberShipTypes
            };
            return View("NewCustomer",viewModel);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
    }
}