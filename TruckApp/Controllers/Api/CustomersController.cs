using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TruckApp.Models;

namespace TruckApp.Controllers.Api
{
    public class CustomersController : ApiController
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


        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////


        public IEnumerable<Customer> GetCustomers(string query=null)
        {
            if (!string.IsNullOrEmpty(query))
            {
                var customersQuery = _context.Customers.Where(t=>t.Void==false).Where(c => c.Name.Contains(query));
                return customersQuery;
            }


            return _context.Customers.ToList();
            
        }



        public IHttpActionResult GetCustomer(int id)
        {
            var customerToGet = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerToGet == null)
                return NotFound();


            return Ok(customerToGet);
        }

        [HttpPost]
        public IHttpActionResult New(Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Customers.Add(customer);

            var userAction = new UserAction
            {
                UserName = User.Identity.Name,
                Action = "New customer was added. Customer name " + customer.Name,
                DateTime = DateTime.Now
            };
            _context.UserActions.Add(userAction);

            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customer);
        }

        [HttpPut]
        public void EditCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var CustomerToEdit = _context.Customers.SingleOrDefault(c => c.Id == id);

            CustomerToEdit.Name = customer.Name;
            CustomerToEdit.Address = customer.Address;
            CustomerToEdit.City = customer.City;
            CustomerToEdit.State = customer.State;
            CustomerToEdit.Country = customer.Country;
            CustomerToEdit.Zipcode = customer.Zipcode;
            CustomerToEdit.Void = customer.Void;

            var userAction = new UserAction
            {
                UserName = User.Identity.Name,
                Action = "Customer was edited. Customer name " + customer.Name,
                DateTime = DateTime.Now
            };
            _context.UserActions.Add(userAction);

            _context.SaveChanges();

        }

        [HttpDelete]
        public void VoidCustomer(int id)
        {
            var customerToVoid = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerToVoid == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            customerToVoid.Void = true;
            //_context.Customers.Remove(customerToVoid);

            var userAction = new UserAction
            {
                UserName = User.Identity.Name,
                Action = "Customer was voided. Customer name " + customerToVoid.Name,
                DateTime = DateTime.Now
            };
            _context.UserActions.Add(userAction);

            _context.SaveChanges();

        }


        [HttpGet]
        [Route("api/getcustomerbyid")]
        public Customer GetLoadByNumber(int? query = null)
        {

            return _context.Customers.SingleOrDefault(c => (c.Id == query&&c.Void==false));
        }

        //[HttpDelete]
        //public void DeleteCustomer(int id)
        //{
        //    var customerToDelete = _context.Customers.SingleOrDefault(c => c.Id == id);

        //    if (customerToDelete == null)
        //        throw new HttpResponseException(HttpStatusCode.NotFound);


        //    _context.Customers.Remove(customerToDelete);

        //    var userAction = new UserAction
        //    {
        //        UserName = User.Identity.Name,
        //        Action = "Customer was deleted. Customer name " + customerToDelete.Name,
        //        DateTime = DateTime.Now
        //    };
        //    _context.UserActions.Add(userAction);

        //    _context.SaveChanges();

        //}
    }
}
