using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Web;
using System.Web.Mvc;
using vidly.Models;
using Vidly.Models;
using vidly.ViewModels;

namespace vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context=new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult New()
        {

            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel()
            {
                Customer= new Customer(),
                MembershipTypes = membershipTypes
            };
            
            return View("CustomerForm",viewModel);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()

                };
                return View("CustomerForm",viewModel);
            }


            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }

            else
            {
                var customerInDb = _context.Customers.Single(c=> c.Id==customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.isSubscribedToNewsLetter = customer.isSubscribedToNewsLetter;

            }
            
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }


        // GET: Customers
        public ActionResult Index()
        {



            return View();


        }

        [Route("customers/details/{id}")]
        public ActionResult Details(int id)
        {
            var customers = _context.Customers.Include(c=> c.MembershipType).ToList();


            for (int i = 0; i <customers.Count; i++)
            {
                if (customers[i].Id == id)
                {
                   
                    return View(customers[i]);
                }
            }

            return HttpNotFound();

        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                var viewModel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                
                return View("CustomerForm",viewModel);
            }
        }
    }

  
}