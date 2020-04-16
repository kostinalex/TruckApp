using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TruckApp.Models;

namespace TruckApp.Controllers.Api
{
    public class CustomersAddressesController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersAddressesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////

        public IEnumerable<Customer> GetCustomersAddresses(string query = null)
        {
            if (!string.IsNullOrEmpty(query))
            {
                var customersQuery = _context.Customers.Where(c => c.Address.Contains(query));
                return customersQuery;
            }


            return _context.Customers.ToList();

        }
    }
}
