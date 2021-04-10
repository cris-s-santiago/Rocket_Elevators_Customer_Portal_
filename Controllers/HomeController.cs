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
            var customer = new HttpClient();
            var email = _userManager.GetUserName(User);
            var responseApiCustomer = customer.GetStringAsync("https://rocket-elevators.azurewebsites.net/api/customers/FullInfo/" + email).GetAwaiter().GetResult();
            Customer customerInfo = JsonConvert.DeserializeObject<Customer>(responseApiCustomer);
            Console.WriteLine("***************");
            Console.WriteLine(customerInfo.buildings.Where(building => building.id == 2));
            Console.WriteLine("***************");
            ViewBag.customer = customerInfo;

            return View();
        }

        public IActionResult Product()
        {
            var customer = new HttpClient();
            var email = _userManager.GetUserName(User);
            var responseApiCustomer = customer.GetStringAsync("https://rocket-elevators.azurewebsites.net/api/customers/FullInfo/" + email).GetAwaiter().GetResult();
            Customer customerInfo = JsonConvert.DeserializeObject<Customer>(responseApiCustomer);
            ViewBag.customer = customerInfo;
            
            return View(customerInfo);
        }

        public IActionResult Profile()
        {
            var customer = new HttpClient();
            var email = _userManager.GetUserName(User);
            var responseApiCustomer = customer.GetStringAsync("https://rocket-elevators.azurewebsites.net/api/customers/FullInfo/" + email).GetAwaiter().GetResult();
            Customer customerInfo = JsonConvert.DeserializeObject<Customer>(responseApiCustomer);
            ViewBag.customer = customerInfo;

            return View();
        }

        public IActionResult InterventionViaProduct( string columnId, string elevatorId, string buildingId, string batteryId)
        {
            var customer = new HttpClient();
            var email = _userManager.GetUserName(User);
            var responseApiCustomer = customer.GetStringAsync("https://rocket-elevators.azurewebsites.net/api/customers/FullInfo/" + email).GetAwaiter().GetResult();
            Customer customerInfo = JsonConvert.DeserializeObject<Customer>(responseApiCustomer);
            
            ViewBag.customer = customerInfo;
            ViewBag.columnId = columnId;
            ViewBag.elevatorId = elevatorId;
            ViewBag.buildingId = buildingId;
            ViewBag.batteryId = batteryId;
            ViewBag.pageProduct = true;

            return View("~/Views/Home/Intervention.cshtml");
        }

        [HttpPost]
        public ActionResult UpdateCustomer(Customer custumerInfo)
        {
            using (var http = new HttpClient())
            {
                // Define authorization headers here, if any
                // http.DefaultRequestHeaders.Add("Authorization", authorizationHeaderValue);

                var data = custumerInfo;

                var content = new StringContent(JsonConvert.SerializeObject(data));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var request = http.PostAsync("https://rocket-elevators.azurewebsites.net/api/Customers", content);

                request.Wait();

                var result = request.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Profile");
                }
            }

            //ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}