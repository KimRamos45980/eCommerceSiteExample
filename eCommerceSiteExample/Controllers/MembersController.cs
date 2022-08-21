using Microsoft.AspNetCore.Mvc;

namespace eCommerceSiteExample.Controllers
{
    public class MembersController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
