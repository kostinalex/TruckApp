using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TruckApp.Models;

namespace TruckApp.Controllers.Api
{
    public class EquipmentController : ApiController
    {

        private ApplicationDbContext _context;
        public EquipmentController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////


        public IEnumerable<Equipment> GetEquipment()
        {
            return _context.Equipments.ToList();
        }


        public IHttpActionResult GetEquipment(int id)
        {
            var equipmentToGet = _context.Equipments.SingleOrDefault(c => c.Id == id);

            if (equipmentToGet == null)
                return NotFound();

            return Ok(equipmentToGet);
        }

        [HttpPost]
        public IHttpActionResult New(Equipment equipment)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Equipments.Add(equipment);

            var userAction = new UserAction
            {
                UserName = User.Identity.Name,
                Action = "Equipment was added. Equipment name " + equipment.Name,
                DateTime = DateTime.Now
            };
            _context.UserActions.Add(userAction);


            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + equipment.Id), equipment);
        }

        [HttpPut]
        public void Editequipment(int id, Equipment equipment)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var equipmentStatusToEdit = _context.Equipments.SingleOrDefault(c => c.Id == id);

            equipmentStatusToEdit.Name = equipment.Name;

            var userAction = new UserAction
            {
                UserName = User.Identity.Name,
                Action = "Equipment was edited. Equipment name " + equipment.Name,
                DateTime = DateTime.Now
            };
            _context.UserActions.Add(userAction);

            _context.SaveChanges();

        }

        [HttpDelete]
        public void DeleteEquipment(int id)
        {
            var equipmentToDelete = _context.Equipments.SingleOrDefault(c => c.Id == id);

            if (equipmentToDelete == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Equipments.Remove(equipmentToDelete);

            var userAction = new UserAction
            {
                UserName = User.Identity.Name,
                Action = "Equipment was deleted. Equipment name " + equipmentToDelete.Name,
                DateTime = DateTime.Now
            };
            _context.UserActions.Add(userAction);


            _context.SaveChanges();

        }

    }
}
