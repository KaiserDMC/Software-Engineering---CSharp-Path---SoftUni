using System.ComponentModel.DataAnnotations;

using static URLShortenerData.Data.DataConstants;

namespace URLShortener.Models.URLAddresses
{
    public class URLAddressFormModel
    {
        [Required]
        [MaxLength(OriginalUrlMaxLenght)]
        [MinLength(OriginalUrlMinLenght)]
        public string URL { get; init; } = null!;

        [Required]
        [MaxLength(ShortUrlMaxLenght)]
        [MinLength(ShortUrlMinLenght)]
	    [Display(Name = "short code")]
        public string ShortCode { get; init; } = null!;
    }
}
