using System.ComponentModel.DataAnnotations;
using static URLShortenerData.Data.DataConstants;
using Microsoft.AspNetCore.Identity;

namespace URLShortenerData.Data.Entities
{
    public class URLAddress
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(OriginalUrlMaxLenght)]
        public string OriginalUrl { get; set; }

        [Required]
        [MaxLength(ShortUrlMaxLenght)]
        public string ShortUrl { get; set; }

        [Required]
        public DateTime DateCreated { get; init; }

        public int Visits { get; set; }

        [Required]
        public string UserId { get; set; }

        public IdentityUser User { get; init; }
    }
}
