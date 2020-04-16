using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TruckApp.Models;
using TruckApp.ViewModels;

namespace TruckApp.Controllers.Api
{
    public class ReportsController : ApiController
    {
        private ApplicationDbContext _context;
        public ReportsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpPost]
        public List<DriversReportViewModel> GetDriverReport(InputDriversReportViewModel input)
        {

            var allDrivers = _context.Drivers.ToList();
            var allLegs = _context.Legs.ToList();

            if (input != null)
            {
                allDrivers = _context.Drivers
                    .Where(c => input.DriverId == null || c.Id == input.DriverId)
                    .Where(t => input.DriverName == null || t.Name == input.DriverName)
                    .ToList();


                allLegs = _context.Legs
                    .Where(c => input.LegId == 0 || c.Id == input.LegId)
                    .Where(t => input.LoadConfirmationId == 0 || t.LoadConfirmationId == input.LoadConfirmationId)
                    .Where(m => input.Distance1 == null || m.Distance >= input.Distance1)
                    .Where(a => input.Distance2 == null || a.Distance <= input.Distance2)
                    .Where(m => input.DriverPay1 == null || m.DriverPay >= input.DriverPay1)
                    .Where(a => input.DriverPay2 == null || a.DriverPay <= input.DriverPay2)
                    .ToList();
            }



                //.Where(m => input.TimeSpent1 == null || (m.DateTime2 - m.DateTime1) >= input.TimeSpent1)
                //.Where(a => input.TimeSpent2 == null || (a.DateTime2 - a.DateTime1) <= input.TimeSpent2)

            List<DriversReportViewModel> driversReport = new List<DriversReportViewModel>();

            foreach (var driver in allDrivers)
            {
                var legsForDriver = allLegs.Where(c => c.DriverId == driver.Id);

                foreach(var leg in legsForDriver)
                {
                    var timeSpan = new TimeSpan();


                    var newReport = new DriversReportViewModel
                    {
                        DriverId=driver.Id,
                        DriverName=driver.Name,
                        LegId=leg.Id,
                        LoadConfirmationId=leg.LoadConfirmationId,
                        Distance=leg.Distance,
                        TimeSpent= leg.DateTime2 - leg.DateTime1,
                        DriverPay=leg.DriverPay
                    };
                    driversReport.Add(newReport);
                }
            }

            return driversReport;
        }





        [HttpPost]
        [Route("api/getloadreport")]
        public List<LoadConfirmation> GetLoadReport (InputLoadReportViewModel input)
        {

            var allLoads = _context.LoadConfirmations
                   .ToList();

            if (input != null)
            {
                allLoads = _context.LoadConfirmations
                    .Where(c => input.CustomerId == 0 || c.CustomerId == input.CustomerId)
                    .Where(c => input.DispatchId == 0 || c.DispatchId == input.DispatchId)
                    .Where(c => input.Rate1 == 0 || c.Rate >= input.Rate1)
                    .Where(c => input.Rate2 == 0 || c.Rate <= input.Rate2)                    
                    .Where(c => input.CreditHold==null || c.CreditHold == input.CreditHold)
                    .Where(c => input.POD == null || c.POD == input.POD)
                    .Where(c => input.Closed == null || c.Closed == input.Closed)
                    .Where(c => input.Void == null || c.Void == input.Void)
                    .Where(c => input.Exported == null || c.Exported == input.Exported)
                    .Include(c=>c.Dispatch)
                    .Include(c => c.Customer)
                    .ToList();
            }

                    //            
                    //.Where(c => c.Closed == input.Closed)
                    //.Where(c => c.Void == input.Void)
                    //.Where(c => c.Exported == input.Exported)



            return allLoads;
        }
    }
}
