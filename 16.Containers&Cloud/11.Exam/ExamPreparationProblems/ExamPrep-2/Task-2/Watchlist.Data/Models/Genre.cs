using System.ComponentModel.DataAnnotations;
using static Watchlist.Data.GlobalConstants;

namespace Watchlist.Data.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [StringLength(GenreNameMaxLength)]
        [Required]
        public string Name { get; set; } = null!;
    }
}