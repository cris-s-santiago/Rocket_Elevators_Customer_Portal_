using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rocket_Elevators_Customer_Portal.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;
using Rocket_Elevators_Customer_Portal.Areas.Identity.Data;
using System.Net.Http.Headers;

namespace Rocket_Elevators_Customer_Portal.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager; // Added/Injection UserManager to find the current logged user

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Intervention()
        {
            ViewBag.customer = getFullData();

            return View();
        }

        public IActionResult Product()
        {
            var customerInfoProduct = getFullData();
            ViewBag.customer = customerInfoProduct;

            return View(customerInfoProduct);
        }

        public IActionResult Profile()
        {
            var customerInfoProfile = getFullData();
            ViewBag.customer = customerInfoProfile;

            var address = new HttpClient();
            var responseApiAddress = address.GetStringAsync("https://rocket-elevators.azurewebsites.net/api/addresses/" + customerInfoProfile.address_id).GetAwaiter().GetResult();
            Address customerAdress = JsonConvert.DeserializeObject<Address>(responseApiAddress);
            ViewBag.address = customerAdress;

            return View();
        }

        public IActionResult InterventionViaProduct( string columnId, string elevatorId, string buildingId, string batteryId)
        {
            ViewBag.customer = getFullData();

            ViewBag.columnId = columnId;
            ViewBag.elevatorId = elevatorId;
            ViewBag.buildingId = buildingId;
            ViewBag.batteryId = batteryId;
            ViewBag.pageProduct = true;

            return View("~/Views/Home/Intervention.cshtml");
        }

        public Customer getFullData()
        {
            var customer = new HttpClient();
            var email = _userManager.GetUserName(User);
            var responseApiCustomer = customer.GetStringAsync("https://rocket-elevators.azurewebsites.net/api/customers/FullInfo/" + email).GetAwaiter().GetResult();
            Customer customerInfo = JsonConvert.DeserializeObject<Customer>(responseApiCustomer);

            return customerInfo;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}