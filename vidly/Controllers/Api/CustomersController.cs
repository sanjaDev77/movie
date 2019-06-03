﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using vidly.Dtos;
using vidly.Models;
using Vidly.Models;

namespace vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }


        //  GET/api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDto>);
        }


        // GET/api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Mapper.Map<Customer,CustomerDto>(customer));
            }
        }

        // POST/api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
                _context.Customers.Add(customer);
                _context.SaveChanges();

                customerDto.Id = customer.Id;

                return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
            }
        }



        // Put/api/customers/1

        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {
                var customerInDb = _context.Customers.SingleOrDefault(c=> c.Id==id);
                if (customerInDb == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                else
                {
                    Mapper.Map<CustomerDto, Customer>(customerDto,customerInDb);
                    //customerInDb.Name = customerDto.Name;
                    //customerInDb.BirthDate = customerDto.BirthDate;
                    //customerInDb.isSubscribedToNewsLetter = customerDto.isSubscribedToNewsLetter;
                    //customerInDb.MembershipTypeId = customerDto.MembershipTypeId;

                    _context.SaveChanges();

                }
            }
        }


        // Delete/api/customers/1

        [HttpDelete]
        public void DeleteCustomer(int id)
        {

            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {
                var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
                if (customerInDb == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                else
                {

                    _context.Customers.Remove(customerInDb);
                    _context.SaveChanges();

                }

            }
        }
    }
}
