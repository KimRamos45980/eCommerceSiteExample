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
        /// The sales price of the game
        /// </summary>
        [Range (0, 1000)]
        public double Price { get; set; }

        // Todo: Add rating

    }
}
