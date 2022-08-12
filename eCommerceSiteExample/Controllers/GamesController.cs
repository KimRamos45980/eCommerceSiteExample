using eCommerceSiteExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceSiteExample.Controllers
{
    public class GamesController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
