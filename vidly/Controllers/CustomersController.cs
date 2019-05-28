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



        // GET: Customers
        public ActionResult Index()
        {

            var viewModel = new CustomerListViewModel()
            {

                Customers = _context.Customers.Include(c=> c.MembershipType).ToList()
            };

            return View(viewModel);


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
    }

  
}