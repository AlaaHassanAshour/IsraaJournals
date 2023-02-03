using IsraaJournals.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IsraaJournals.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }
        [HttpGet]
        public IActionResult Index()
        {
            
            return Redirect("/swagger");
        }
    }
}