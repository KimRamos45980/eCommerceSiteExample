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
        public async Task<IActionResult> Create(Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Games.Add(game);           // Prepares insert
                await _context.SaveChangesAsync();  // Execture pending insert

                ViewData["Message"] = $"{game.Title} was added successfully!";
                return View();
            }

            return View(game);
        }
    }
}
