using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

using URLShortener.Infrastructure;
using URLShortener.Models;
using URLShortener.Models.Home;
using URLShortener.Models.URLAddresses;

using URLShortenerData.Data;
using URLShortenerData.Data.Entities;

namespace URLShortenerData.Controllers
{
    public class HomeController : Controller
    {
        private readonly URLShortenerDbContext data;

        public HomeController(URLShortenerDbContext data)
        {
            this.data = data;
        }

        public IActionResult Index(int? pageNumber)
        {
            IndexViewModel allIndexInfo = new IndexViewModel()
            {
                TotalShortURLsCount = this.data.URLAddresses.Count(),
                TotalURLVisitorsCount = this.GetAllUrlsVisitsCount(),
                URLAddresses = this.data.URLAddresses.Select(x => new URLAddressViewModel
                {
                    Id = x.Id,
                    OriginalUrl = x.OriginalUrl,
                    ShortUrl = x.ShortUrl,
                    DateCreated = x.DateCreated,
                    Visits = x.Visits
                }).OrderByDescending(x => x.DateCreated).Take(3).ToList()
            };

            if (this.User.Identity is not null && this.User.Identity.IsAuthenticated)
            {
                allIndexInfo.URLAddresses = this.data.URLAddresses
                    .Where(x => x.UserId == this.User.UserId())
                    .Select(x => new URLAddressViewModel
                    {
                        Id = x.Id,
                        OriginalUrl = x.OriginalUrl,
                        ShortUrl = x.ShortUrl,
                        DateCreated = x.DateCreated,
                        Visits = x.Visits
                    }).ToList();

                allIndexInfo.MyShortURLsCount = allIndexInfo.URLAddresses.Count();
                allIndexInfo.MyTotalURLVisitorsCount = this.GetMyUrlsVisistsCount(allIndexInfo);
            };

            allIndexInfo.PageIndex = pageNumber ?? 1;

            allIndexInfo.TotalPages = (int)Math.Ceiling((decimal)allIndexInfo.MyShortURLsCount / allIndexInfo.URLsPerPage);

            allIndexInfo.URLAddresses = allIndexInfo.URLAddresses
                .Skip((allIndexInfo.PageIndex - 1) * allIndexInfo.URLsPerPage)
                .Take(allIndexInfo.URLsPerPage)
                .ToList();

            return this.View(allIndexInfo);
        }

        private int GetMyUrlsVisistsCount(IndexViewModel allIndexInfo)
        {
            int myTotalVisits = 0;
            foreach (URLAddressViewModel urlAddress in allIndexInfo.URLAddresses!)
            {
                myTotalVisits += urlAddress.Visits;
            }

            return myTotalVisits;
        }

        private int GetAllUrlsVisitsCount()
        {
            int countAllVisits = 0;
            foreach (URLAddress address in this.data.URLAddresses)
            {
                countAllVisits += address.Visits;
            }

            return countAllVisits;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => this.View(new ErrorViewModel
        { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
    }
}
