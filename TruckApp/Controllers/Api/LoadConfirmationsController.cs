using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TruckApp.Models;
using TruckApp.ViewModels;
using System.Data.Entity;
using System.Web.Http.Cors;

namespace TruckApp.Controllers.API
{
    [Authorize(Roles = RoleName.CanEnter)]
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    public class LoadConfirmationsController : ApiController
    {
        private ApplicationDbContext _context;
        public LoadConfirmationsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////


        public IEnumerable<LoadConfirmation> GetLoadConfirmations()
        {
            return _context.LoadConfirmations.Include(c=>c.Customer).Include(c => c.Dispatch).ToList();
        }


        public IHttpActionResult GetLoadConfirmation(int id)
        {
            var loadConfirmationToGet = _context.LoadConfirmations
                .Include(c => c.Customer)
                .Include(m => m.HazMatStatus)
                .Include(a => a.Equipment)
                .Include(b => b.PriorityDelivery)
                .Include(d => d.PriorityEntry)
                .Include(e => e.Dispatch)
                .SingleOrDefault(c => c.Id == id);

            if (loadConfirmationToGet == null)
                return NotFound();

            return Ok(loadConfirmationToGet);
        }

        [HttpPost]
        public IHttpActionResult CreateLoadConfirmation(LoadConfirmation loadConfirmation)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.LoadConfirmations.Add(loadConfirmation);

            _context.SaveChanges();

            var userAction = new UserAction
            {
                UserName = User.Identity.Name,
                Action = "Load was created. Load id " + loadConfirmation.Id,
                DateTime = DateTime.Now,
                LoadConfirmationId=loadConfirmation.Id
            };
            _context.UserActions.Add(userAction);

            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + loadConfirmation.Id), loadConfirmation);
        }

        [HttpPut]
        public void EditLoadConfirmation(int id, LoadConfirmation loadConfirmation)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var loadConfirmationToEdit = _context.LoadConfirmations.SingleOrDefault(c => c.Id == id);

            var changes = "";

            if (loadConfirmationToEdit.CustomerId != loadConfirmation.CustomerId)
                changes = changes + " CustomerId. Was:" + loadConfirmationToEdit.CustomerId+" Became:"+ loadConfirmation.CustomerId;

            if (loadConfirmationToEdit.FreightDescription != loadConfirmation.FreightDescription)
                changes = changes + " FreightDescription. Was:" + loadConfirmationToEdit.FreightDescription + " Became:" + loadConfirmation.FreightDescription;

            if (loadConfirmationToEdit.Weight!= loadConfirmation.Weight)
                changes = changes + " Weight. Was:" + loadConfirmationToEdit.Weight + " Became:" + loadConfirmation.Weight;

            if (loadConfirmationToEdit.NumberOfPallets!= loadConfirmation.NumberOfPallets)
                changes = changes + " NumberOfPallets. Was:" + loadConfirmationToEdit.NumberOfPallets + " Became:" + loadConfirmation.NumberOfPallets;

            if (loadConfirmationToEdit.Rate!= loadConfirmation.Rate)
                changes = changes + " Rate. Was:" + loadConfirmationToEdit.Rate + " Became:" + loadConfirmation.Rate;

            if (loadConfirmationToEdit.HazMatStatusId!= loadConfirmation.HazMatStatusId)
                changes = changes + " HazMatStatusId. Was:" + loadConfirmationToEdit.HazMatStatusId + " Became:" + loadConfirmation.HazMatStatusId;

            if (loadConfirmationToEdit.EquipmentId!= loadConfirmation.EquipmentId)
                changes = changes + " EquipmentId. Was:" + loadConfirmationToEdit.EquipmentId + " Became:" + loadConfirmation.EquipmentId;

            if (loadConfirmationToEdit.PriorityDeliveryId!= loadConfirmation.PriorityDeliveryId)
                changes = changes + " PriorityDeliveryId. Was:" + loadConfirmationToEdit.PriorityDeliveryId + " Became:" + loadConfirmation.PriorityDeliveryId;

            if (loadConfirmationToEdit.PriorityEntryId!= loadConfirmation.PriorityEntryId)
                changes = changes + " PriorityEntryId. Was:" + loadConfirmationToEdit.PriorityEntryId + " Became:" + loadConfirmation.PriorityEntryId;

            if (loadConfirmationToEdit.DispatchId!= loadConfirmation.DispatchId)
                changes = changes + " DispatchId. Was:" + loadConfirmationToEdit.DispatchId + " Became:" + loadConfirmation.DispatchId;

           
            if (loadConfirmationToEdit.CreditHold!=loadConfirmation.CreditHold)
                changes = changes + " CreditHold. Was:" + loadConfirmationToEdit.CreditHold + " Became:" + loadConfirmation.CreditHold;
            
            if (loadConfirmationToEdit.POD!=loadConfirmation.POD)
                changes = changes + " POD. Was:" + loadConfirmationToEdit.POD + " Became:" + loadConfirmation.POD;

            if (loadConfirmationToEdit.ConfNumber!= loadConfirmation.ConfNumber)
                changes = changes + " ConfNumber. Was:" + loadConfirmationToEdit.ConfNumber + " Became:" + loadConfirmation.ConfNumber;

            if (loadConfirmationToEdit.CustomsBroker!= loadConfirmation.CustomsBroker)
                changes = changes + " CustomsBroker. Was:" + loadConfirmationToEdit.CustomsBroker + " Became:" + loadConfirmation.CustomsBroker;

            if (loadConfirmationToEdit.HazMatNumber!= loadConfirmation.HazMatNumber)
                changes = changes+ " HazMatNumber. Was:" + loadConfirmationToEdit.HazMatNumber + " Became:" + loadConfirmation.HazMatNumber;

            if (loadConfirmationToEdit.Void!= loadConfirmation.Void)
                changes = changes + " VoidStatus. Was:" + loadConfirmationToEdit.Void + " Became:" + loadConfirmation.Void;


            if (loadConfirmationToEdit.Closed != loadConfirmation.Closed)
                changes = changes + " ClosedStatus. Was:" + loadConfirmationToEdit.Closed + " Became:" + loadConfirmation.Closed;

            if (loadConfirmationToEdit.Exported!= loadConfirmation.Exported)
                changes = changes + " ExportedStatus. Was:" + loadConfirmationToEdit.Exported + " Became:" + loadConfirmation.Exported;




            loadConfirmationToEdit.CustomerId = loadConfirmation.CustomerId;
            loadConfirmationToEdit.FreightDescription = loadConfirmation.FreightDescription;
            loadConfirmationToEdit.Weight = loadConfirmation.Weight;
            loadConfirmationToEdit.NumberOfPallets = loadConfirmation.NumberOfPallets;
            loadConfirmationToEdit.Rate = loadConfirmation.Rate;
            loadConfirmationToEdit.HazMatStatusId = loadConfirmation.HazMatStatusId;
            loadConfirmationToEdit.EquipmentId = loadConfirmation.EquipmentId;
            loadConfirmationToEdit.PriorityDeliveryId = loadConfirmation.PriorityDeliveryId;
            loadConfirmationToEdit.PriorityEntryId = loadConfirmation.PriorityEntryId;
            loadConfirmationToEdit.DispatchId = loadConfirmation.DispatchId; 
            loadConfirmationToEdit.CreditHold = loadConfirmation.CreditHold;
            loadConfirmationToEdit.POD = loadConfirmation.POD;
            loadConfirmationToEdit.ConfNumber = loadConfirmation.ConfNumber;
            loadConfirmationToEdit.CustomsBroker = loadConfirmation.CustomsBroker;
            loadConfirmationToEdit.HazMatNumber = loadConfirmation.HazMatNumber;
            loadConfirmationToEdit.Void = loadConfirmation.Void;
            loadConfirmationToEdit.Closed = loadConfirmation.Closed;
            loadConfirmationToEdit.Exported = loadConfirmation.Exported;





            var userAction = new UserAction
            {
                UserName = User.Identity.Name,
                Action = "Load was edited. Load id " + id +" Changes were made: " +changes,
                DateTime = DateTime.Now,
                LoadConfirmationId=id
            };
            _context.UserActions.Add(userAction);

            _context.SaveChanges();

        }


        [HttpDelete]
        public void DeleteLoadConfirmation(int id)
        {
            var loadToVoid = _context.LoadConfirmations.SingleOrDefault(c => c.Id == id);
            

            if (loadToVoid == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);


            loadToVoid.Void = true;

            var userAction = new UserAction
            {
                UserName = User.Identity.Name,
                Action = "Load was voided. Load id " + loadToVoid.Id,
                DateTime = DateTime.Now
            };
            _context.UserActions.Add(userAction);
            _context.SaveChanges();



        }

       ///////////////////////////////////CHECK CONFIRMATION FOR DUPLICATES////////////////////////////////
       ///
        [HttpGet]
        [Route("api/checkconfirmationnumber")]
        public List<string> GetLoadNumbers(string query=null)
        {
            List < string > listOfLoadNumbers= new List<string>();

            List<LoadConfirmation> confirmations = new List<LoadConfirmation>();

            

            if (!string.IsNullOrEmpty(query))
            {
                confirmations = _context.LoadConfirmations.Where(c => c.ConfNumber.Contains(query)).ToList();
            }
            else
            {
                confirmations = _context.LoadConfirmations.ToList();
            }

                foreach (var load in confirmations)
            {
                var loadNumber = load.ConfNumber;
                listOfLoadNumbers.Add(loadNumber);
            }

            return listOfLoadNumbers;
        }


        [HttpGet]
        [Route("api/getloadbynumber")]
        public LoadConfirmation GetLoadByNumber(string query = null)
        {         

            return _context.LoadConfirmations.Include(t=>t.Customer).Single(c=>c.ConfNumber==query);
        }








        //[HttpDelete]
        //public void DeleteLoadConfirmation(int id)
        //{
        //    var loadToDelete = _context.LoadConfirmations.SingleOrDefault(c => c.Id == id);
        //    var legsToDelete = _context.Legs.Where(c => c.LoadConfirmationId == id);

        //    if (loadToDelete == null)
        //        throw new HttpResponseException(HttpStatusCode.NotFound);

        //    foreach(var leg in legsToDelete)
        //    {
        //        _context.Legs.Remove(leg);
        //    }

        //    _context.LoadConfirmations.Remove(loadToDelete);


        //    var userAction = new UserAction
        //    {
        //        UserName = User.Identity.Name,
        //        Action = "Load was deleted. Load id " + loadToDelete.Id,
        //        DateTime = DateTime.Now
        //    };
        //    _context.UserActions.Add(userAction);



        //    _context.SaveChanges();



        //}
    }
}
