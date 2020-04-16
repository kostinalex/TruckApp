using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TruckApp.Models;
using TruckApp.ViewModels;
using System.Data.Entity;
using System.IO;
using System.Web.UI;
using TruckApp.Models;

namespace TruckApp.Controllers
{
    [Authorize(Roles = RoleName.CanEnter)]
    public class LoadConfirmationsController : Controller
    {

        private ApplicationDbContext _context;

        public object ClientScript { get; private set; }

        public LoadConfirmationsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View("New");
        }



        public ActionResult editNote(int id)
        {
            return View("NewNote", id);
        }

        public ActionResult NewNote()
        {
            return View("NewNote");
        }


        [Authorize(Roles = RoleName.CanSeeUsersActionsWithLoad)]
        public ActionResult UserActionsForLoad()
        {
            return View();
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////
        // GET: LoadConfirmations
        //public ActionResult Index()
        //{

        //    var viewModel1 = new LoadConfirmationsViewModel()
        //    {
        //        LoadConfirmations = _context.LoadConfirmations.ToList()

        //    };

        //    return View(viewModel1);

        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////
        //public ActionResult NewConfirmationLoad()
        //{

        //    var HazmatList = _context.HazMatStatuses.ToList();
        //    var EquipmentList = _context.Equipments.ToList();
        //    var PriorityDeliveryList = _context.PriorityDeliveries.ToList();
        //    var PriorityEntryList = _context.PriorityEntries.ToList();
        //    var DispatchList = _context.Dispatches.ToList();
        //    var DriverList = _context.Drivers.ToList();


        //    var viewModel1 = new LoadFormViewModel()
        //    {
        //        LoadConfirmation = new LoadConfirmation(),
        //        Customer = new Customer(),
        //        HazmatStatuses = HazmatList,
        //        Equipments = EquipmentList,
        //        PriorityDeliveries= PriorityDeliveryList,
        //        PriorityEntries = PriorityEntryList,
        //        Dispatches = DispatchList,
        //        Drivers=DriverList
        //    };

        //    return View("ConfirmationLoadForm", viewModel1);

        //}
        //////////////////////////////////////////////////////////////////////////////////////////////////
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Save(HttpPostedFileBase files, LoadFormViewModel loadFormViewModel)
        //{

        //    if (!ModelState.IsValid)
        //    {
        //        var viewModel1 = new LoadFormViewModel
        //        {
        //            Customer=loadFormViewModel.Customer,
        //            LoadConfirmation = loadFormViewModel.LoadConfirmation
        //        };
        //        return View("ConfirmationLoadForm", viewModel1);
        //    }

        //    if (loadFormViewModel.LoadConfirmation.Id != 0)
        //    {
        //        var loadToUpdate1 = _context.LoadConfirmations.Include(c => c.Customer).Single(c => c.Id == loadFormViewModel.LoadConfirmation.Id);
        //        var customerToUpdate1 = _context.Customers.SingleOrDefault(c => c.Id == loadToUpdate1.CustomerId);

        //        //customer is not new, if its properties were changed -> new customer, if not->nothing
        //        //if (customerToUpdate1 != null)
        //        //{
        //        //    ////If customer properties were changed, create new customer
        //        //    //if ((customerToUpdate1.Name != loadFormViewModel.Customer.Name) ||
        //        //    //(customerToUpdate1.Address != loadFormViewModel.Customer.Address) ||
        //        //    //(customerToUpdate1.City != loadFormViewModel.Customer.City) ||
        //        //    //(customerToUpdate1.State != loadFormViewModel.Customer.State) ||
        //        //    //(customerToUpdate1.Country != loadFormViewModel.Customer.Country) ||
        //        //    //(customerToUpdate1.Zipcode != loadFormViewModel.Customer.Zipcode))
        //        //    //{
        //        //    //    var newCustomer1=_context.Customers.Add(loadFormViewModel.Customer);
        //        //    //    loadToUpdate1.CustomerId = newCustomer1.Id;
        //        //    //}
        //        //}

        //        ////If customer is a new one, create customer
        //        //if (customerToUpdate1 == null)
        //        //{
        //        //    var newCustomer1 = _context.Customers.Add(loadFormViewModel.Customer);
        //        //    loadToUpdate1.CustomerId = newCustomer1.Id;
        //        //}

        //        //load is not a new one->update the rate


        //        loadToUpdate1.PickUpFacilityName = loadFormViewModel.LoadConfirmation.PickUpFacilityName;
        //        loadToUpdate1.PickUpAddress = loadFormViewModel.LoadConfirmation.PickUpAddress;
        //        loadToUpdate1.PickUpCity = loadFormViewModel.LoadConfirmation.PickUpCity;
        //        loadToUpdate1.PickUpState = loadFormViewModel.LoadConfirmation.PickUpState;
        //        loadToUpdate1.PickUpCountry = loadFormViewModel.LoadConfirmation.PickUpCountry;
        //        loadToUpdate1.PickUpZipcode = loadFormViewModel.LoadConfirmation.PickUpZipcode;

        //        loadToUpdate1.DeliveryFacilityName = loadFormViewModel.LoadConfirmation.DeliveryFacilityName;
        //        loadToUpdate1.DeliveryAddress = loadFormViewModel.LoadConfirmation.DeliveryAddress;
        //        loadToUpdate1.DeliveryCity = loadFormViewModel.LoadConfirmation.DeliveryCity;
        //        loadToUpdate1.DeliveryState = loadFormViewModel.LoadConfirmation.DeliveryState;
        //        loadToUpdate1.DeliveryCountry = loadFormViewModel.LoadConfirmation.DeliveryCountry;
        //        loadToUpdate1.DeliveryZipcode= loadFormViewModel.LoadConfirmation.DeliveryZipcode;

        //        loadToUpdate1.FreightDescription = loadFormViewModel.LoadConfirmation.FreightDescription;
        //        loadToUpdate1.Weight = loadFormViewModel.LoadConfirmation.Weight;
        //        loadToUpdate1.NumberOfPallets = loadFormViewModel.LoadConfirmation.NumberOfPallets;

        //        loadToUpdate1.Rate = loadFormViewModel.LoadConfirmation.Rate;

        //        loadToUpdate1.HazMatStatusId = loadFormViewModel.LoadConfirmation.HazMatStatusId;
        //        loadToUpdate1.EquipmentId = loadFormViewModel.LoadConfirmation.EquipmentId;

        //        loadToUpdate1.PriorityDeliveryId = loadFormViewModel.LoadConfirmation.PriorityDeliveryId;
        //        loadToUpdate1.PriorityEntryId = loadFormViewModel.LoadConfirmation.PriorityEntryId;
        //        loadToUpdate1.DispatchId = loadFormViewModel.LoadConfirmation.DispatchId;
        //        loadToUpdate1.DriverId = loadFormViewModel.LoadConfirmation.DriverId;
        //        loadToUpdate1.CreditHold = loadFormViewModel.LoadConfirmation.CreditHold;
        //        loadToUpdate1.POD = loadFormViewModel.LoadConfirmation.POD;
        //        loadToUpdate1.CustomsBroker = loadFormViewModel.LoadConfirmation.CustomsBroker;
        //        loadToUpdate1.HazMatNumber = loadFormViewModel.LoadConfirmation.HazMatNumber;
        //        loadToUpdate1.ConfNumber = loadFormViewModel.LoadConfirmation.ConfNumber;

        //        _context.SaveChanges();

        //    }




        //    //New load
        //    if (loadFormViewModel.LoadConfirmation.Id == 0)
        //    {

        //        // if customer exists -> find it and add customerId, if customer doesn't exist -new customer
        //        var suspectCustomers = _context.Customers.Where(c => c.Name == loadFormViewModel.Customer.Name.Trim());

        //        bool customerExists = false;

        //        if (suspectCustomers != null)
        //        {
        //            foreach (Customer suspectCustomer1 in suspectCustomers)
        //            {
        //                if (suspectCustomer1.Zipcode != null)
        //                {
        //                    if ((suspectCustomer1.Address.Trim() == loadFormViewModel.Customer.Address) &&
        //                   (suspectCustomer1.City.Trim() == loadFormViewModel.Customer.City) &&
        //                   (suspectCustomer1.State.Trim() == loadFormViewModel.Customer.State) &&
        //                   (suspectCustomer1.Country.Trim() == loadFormViewModel.Customer.Country) &&
        //                   (suspectCustomer1.Zipcode.Trim() == loadFormViewModel.Customer.Zipcode))
        //                    {
        //                        loadFormViewModel.LoadConfirmation.CustomerId = suspectCustomer1.Id;
        //                        customerExists = true;
        //                    }
        //                }


        //            }
        //        }

        //        if (customerExists == true)
        //        {
        //            _context.LoadConfirmations.Add(loadFormViewModel.LoadConfirmation);
        //            _context.SaveChanges();
        //        }
        //        else
        //        {
        //            var viewModel1 = new LoadFormViewModel
        //            {
        //                Customer = loadFormViewModel.Customer,
        //                LoadConfirmation = loadFormViewModel.LoadConfirmation
        //            };
        //            return View("ConfirmationLoadForm", viewModel1);
        //        }



        //    }


        //    return RedirectToAction("Edit/"+ loadFormViewModel.LoadConfirmation.Id);
        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////

        //public ActionResult Edit(int id)
        //{
        //    var loadConfirmationToEdit = _context.LoadConfirmations
        //        .SingleOrDefault(c => c.Id == id);

        //    var customerToEdit = _context.Customers
        //        .SingleOrDefault(c => c.Id == loadConfirmationToEdit.CustomerId);

        //    if (loadConfirmationToEdit == null)
        //        return HttpNotFound();

        //    var viewModel1 = new LoadFormViewModel
        //    {
        //        LoadConfirmation = loadConfirmationToEdit,
        //        Customer = customerToEdit,
        //        HazmatStatuses = _context.HazMatStatuses.ToList(),
        //        Equipments = _context.Equipments.ToList(),
        //        PriorityDeliveries = _context.PriorityDeliveries.ToList(),
        //        PriorityEntries=_context.PriorityEntries.ToList(),
        //        Dispatches=_context.Dispatches.ToList(),
        //        Drivers = _context.Drivers.ToList()
        //    };



        //    return View("ConfirmationLoadForm", viewModel1);

        //}


        //public ActionResult DeleteLoadConfirmation(int id)
        //{
        //    var loadConfirmationToDelete = _context.LoadConfirmations.SingleOrDefault(c => c.Id == id);
        //    if (loadConfirmationToDelete == null)
        //        return HttpNotFound();

        //    _context.LoadConfirmations.Remove(loadConfirmationToDelete);
        //    _context.SaveChanges();
        //    return RedirectToAction("IndexAPI", "LoadConfirmations");

        //}





        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult SaveAttachment(HttpPostedFileBase files, LoadFormViewModel loadFormViewModel)
        //{
        //    if (files != null && files.ContentLength > 0) //files.ContentType=="text" && && files.ContentLength < 102400
        //    {
        //        //// extract only the filename
        //        //var fileName = Path.GetFileName(files.FileName);
        //        //// store the file inside ~/App_Data/uploads folder
        //        var path = Path.Combine(Server.MapPath("~/Uploaded files"), "newfile.pdf");
        //        files.SaveAs(path);
        //    }


        //        //var viewModel1 = new LoadFormViewModel
        //        //{
        //        //    Customer = loadFormViewModel.Customer,
        //        //    LoadConfirmation = loadFormViewModel.LoadConfirmation
        //        //};


        //    return View("ConfirmationLoadForm", loadFormViewModel);
        //}

    }
}