using clothingshopproject.Models;
using clothingshopproject.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace clothingshopproject.Controllers
{
    public class HomeController : Controller
    {
        public readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;

        public HomeController(ILogger<HomeController> logger, 
            IUserService userService,
           IEmailService emailService )
        {
            _logger = logger;
            _userService = userService;
           _emailService = emailService;
        }

        public async Task<ViewResult> Index()
        {
            UserEmailOptions options = new UserEmailOptions
            {
                ToEmail = new List<string>() { "fahadthereal666@gmail.com" },

                PlaceHolders = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string , string>("{{UserName}}", "Fahad Haider")

                }

           
            };
           await _emailService.SendTestEmail(options);



            var UserId = _userService.GetUserId();

            var IsLogedin = _userService.IsAuthenticated();

            ViewBag.Id= UserId;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
