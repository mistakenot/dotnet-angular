using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Inbox");
            }

            return View();
        }

        [HttpGet]
        [Route("About")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [HttpGet]
        [Route("Contact")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [HttpGet]
        [Route("Error")]
        public IActionResult Error()
        {
            return View();
        }

        [HttpGet]
        [Route("Test")]
        public string Test()
        {
            return "OK";
        }
    }
}
