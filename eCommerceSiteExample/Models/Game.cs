using System.ComponentModel.DataAnnotations;

namespace eCommerceSiteExample.Models
{
    /// <summary>
    /// Represents a single game for purchase
    /// </summary>
    public class Game
    {
        /// <summary>
        /// THe unique identifier for each game product
        /// </summary>
        [Key]
        public int GameId { get; set; }

        /// <summary>
        /// The official title of the Video Game
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Device listed game can be played on
        /// </summary>
        [Required]
        public string Device { get; set; }

        /// <summary>
        /// The sales price of the game
        /// </summary>
        [Range (0, 1000)]
        public double Price { get; set; }

        /// <summary>
        /// The game's distributed region for device playability
        /// </summary>
        public string? Region { get; set; }

        // Todo: Add rating

    }

    /// <summary>
    /// A single video game that has been added to the users
    /// shopping cart cookie
    /// </summary>
    public class CartGameViewModel
    {
        public int GameId { get; set; }

        public string Title { get; set; }

        public string Device { get; set; }

        public double Price { get; set; }

        public string? Region { get; set; }
    }
}
