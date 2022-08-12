using eCommerceSiteExample.Data;
using eCommerceSiteExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerceSiteExample.Controllers
{
    public class GamesController : Controller
    {
        private readonly VideoGameContext _context;

        public GamesController(VideoGameContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            //List<Game> games = _context.Games.ToList();
            List<Game> games = await (from game in _context.Games
                                      select game).ToListAsync();

            return View(games);
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
