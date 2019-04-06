using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModel;


// install-package bootbox -version:4.3.0
// install-package jquery.datatables -version:1.10.11
// install-package automapper -version:4.1
//Admin123@
//Guest123@

namespace Vidly.Controllers
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
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();


            return View(customers);
        }

        //GET: Customers/Details/1
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return HttpNotFound();
            }

            //var customer = new ApplicationDbContext();
            //customer.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            //var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            return View(customer);
        }



        public ActionResult New()
        {

            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View("Create",viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }

            
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var customer = _context.Customers.SingleOrDefault(c => c.Id == id.Value);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            //return View("CustomerForm", viewModel);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            var customerToUpdate = _context.Customers.Single(c => c.Id == customer.Id);

            customerToUpdate.MembershipTypeId = customer.MembershipTypeId;
            customerToUpdate.Name = customer.Name;
            customerToUpdate.BirthDate = customer.BirthDate;
            customerToUpdate.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }




        public ActionResult Create()
        {
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create( Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Create");

        }


    }
}