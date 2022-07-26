﻿using eCommerceSiteExample.Data;
using eCommerceSiteExample.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace eCommerceSiteExample.Controllers
{
    public class CartController : Controller
    {
        private readonly VideoGameContext _context;
        private const string Cart = "ShoppingCart";

        public CartController(VideoGameContext context)
        {
            _context = context;
        }

        public IActionResult Add(int id)
        {
            Game gameToAdd = _context.Games.Where(g => g.GameId == id).SingleOrDefault();

            if (gameToAdd == null)
            {
                // Game with specified id does not exist
                TempData["Message"] = "Sorry that game no longer exists";
                return RedirectToAction("Index", "Games");
            }

            CartGameViewModel cartGame = new()
            {
                GameId = gameToAdd.GameId,
                Title = gameToAdd.Title,
                Device = gameToAdd.Device,
                Price = gameToAdd.Price,
                Region = gameToAdd.Region
            };

            List<CartGameViewModel> cartGames = getExistingCartData();
            cartGames.Add(cartGame);
            WriteShoppingCartCookie(cartGames);

            TempData["Message"] = "Item added to cart";
            return RedirectToAction("Index", "Games");
        }

        private void WriteShoppingCartCookie(List<CartGameViewModel> cartGames)
        {
            string cookieData = JsonConvert.SerializeObject(cartGames);

            HttpContext.Response.Cookies.Append(Cart, cookieData, new CookieOptions()
            {
                Expires = DateTimeOffset.Now.AddYears(1)
            });
        }

        /// <summary>
        /// Return the current list of video games in the users shopping
        /// cart cookie. If there is no cookie, an empty list will be returned
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private List<CartGameViewModel> getExistingCartData()
        {
            string? cookie = HttpContext.Request.Cookies[Cart];
            if (string.IsNullOrWhiteSpace(cookie))
            {
                return new List<CartGameViewModel>();
            }

            return JsonConvert.DeserializeObject<List<CartGameViewModel>>(cookie);
        }

        public IActionResult Summary()
        {
            // Read shopping cart data and convert to list of view model
            List<CartGameViewModel> cartGames = getExistingCartData();
            return View(cartGames);
        }

        public IActionResult Remove(int id)
        {
            List<CartGameViewModel> cartGames = getExistingCartData();

            CartGameViewModel? targetGame =
                cartGames.FirstOrDefault(g => g.GameId == id);

            cartGames.Remove(targetGame);

            WriteShoppingCartCookie(cartGames);

            return RedirectToAction(nameof(Summary));
        }
    }
}
