using eCommerceSiteExample.Data;
using eCommerceSiteExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceSiteExample.Controllers
{
    public class GamesController : Controller
    {
        private readonly VideoGameContext _context;

        public GamesController(VideoGameContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Games.Add(game); // Prepares insert
                _context.SaveChanges();   // Execture pending insert

                ViewData["Message"] = $"{game.Title} was added successfully!";
                return View();
            }

            return View(game);
        }
    }
}
