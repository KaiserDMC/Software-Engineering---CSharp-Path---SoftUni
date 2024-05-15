namespace URLShortener.Models.URLAddresses
{
    public class URLAddressViewModel
    {
        public int Id { get; init; }

        public string OriginalUrl { get; set; } = null!;

        public string ShortUrl { get; set; } = null!;

        public DateTime DateCreated { get; set; }

        public int Visits { get; set; }

    }
}
