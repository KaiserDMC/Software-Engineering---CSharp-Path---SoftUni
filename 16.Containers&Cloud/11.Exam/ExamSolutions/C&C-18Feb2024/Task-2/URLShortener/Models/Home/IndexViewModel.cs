using URLShortener.Models.URLAddresses;

namespace URLShortener.Models.Home
{
    public class IndexViewModel
    {
        public int PageIndex { get;  set; }

        public int TotalPages { get;  set; }

        public bool HasPreviousPage => this.PageIndex > 1;

        public bool HasNextPage => this.PageIndex < this.TotalPages;

        public int URLsPerPage = 3;

        public int TotalShortURLsCount { get; set; }

        public int TotalURLVisitorsCount { get; set; }

        public int MyShortURLsCount { get; set; }

        public int MyTotalURLVisitorsCount { get; set; }

        public List<URLAddressViewModel>? URLAddresses { get; set; }
    }
}
