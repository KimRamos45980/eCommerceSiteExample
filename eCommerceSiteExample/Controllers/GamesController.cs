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

        public async Task<IActionResult> Index(int? id)
        {
            const int NumGamesToDisplayPerPage = 3;
            const int PageOffset = 1; // Page offset for num of game displayed on current page

            int currPage = id ?? 1; // Set currPage to id if it has a value, otherwise use 1

            int totalNumOfProducts = await _context.Games.CountAsync();
            double MaxNumPages = Math.Ceiling((double)totalNumOfProducts / NumGamesToDisplayPerPage);
            int lastPage = Convert.ToInt32(MaxNumPages); // Round pages up to next whole number

            List<Game> games = await (from game in _context.Games
                                      select game)
                                      .Skip(NumGamesToDisplayPerPage * (currPage - PageOffset))
                                      .Take(NumGamesToDisplayPerPage)
                                      .ToListAsync();

            GameCatalogViewModel catalogModel = new(games, lastPage, currPage);
            return View(catalogModel);
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

        public async Task<IActionResult> Edit(int id)
        {
            Game? gameToEdit = await _context.Games.FindAsync(id);

            if (gameToEdit == null)
            {
                return NotFound();
            }

            return View(gameToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Game gameModel)
        {
            if (ModelState.IsValid)
            {
                _context.Games.Update(gameModel);
                await _context.SaveChangesAsync();

                TempData["Message"] = $"{gameModel.Title} was updated successfully!";
                return RedirectToAction("Index");
            }

            return View(gameModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Game? gameToDelete = await _context.Games.FindAsync(id);

            if (gameToDelete == null)
            {
                return NotFound();
            }

            return View(gameToDelete);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Game gameToDelete = await _context.Games.FindAsync(id);

            if (gameToDelete != null)
            {
                _context.Games.Remove(gameToDelete);
                await _context.SaveChangesAsync();
                TempData["Message"] = gameToDelete.Title + " was deleted successdully";
                return RedirectToAction("Index");
            }

            TempData["Message"] = "This game was already deleted";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            Game? gameDetails = await _context.Games.FindAsync(id);

            if (gameDetails == null)
            {
                return NotFound();
            }

            return View(gameDetails);

        }
    }
}
