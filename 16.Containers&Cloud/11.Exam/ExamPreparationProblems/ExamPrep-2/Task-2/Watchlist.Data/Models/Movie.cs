using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Watchlist.Data.Models
{
    using static Watchlist.Data.GlobalConstants;

    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(MovieTitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DirectorNameMaxLength)]
        public string Director { get; set; } = null!;

        [Required] 
        public string ImageUrl { get; set; } = null!;

        [Required]
        public decimal Rating { get; set; }

        public int? GenreId { get; set; }

        [ForeignKey(nameof(GenreId))]
        public Genre? Genre { get; set; }

        public List<UserMovie> UsersMovies { get; set; } = new List<UserMovie>();
    }
}
