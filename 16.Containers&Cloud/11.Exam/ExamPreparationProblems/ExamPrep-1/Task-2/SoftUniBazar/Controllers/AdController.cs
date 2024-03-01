using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using SoftUniBazar.Data;
using SoftUniBazar.Data.Models;
using SoftUniBazar.Models.Ad;
using SoftUniBazar.Models.Category;

namespace SoftUniBazar.Controllers
{
    [Authorize]
    public class AdController : Controller
    {
        private readonly BazarDbContext _data;

        public AdController(BazarDbContext data)
        {
            _data = data;
        }


        public async Task<IActionResult> Add()
        {
            AdFormModel adModel = new AdFormModel()
            {
                Categories = GetCategories()
            };

            return View(adModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AdFormModel adModel)
        {
            if (!GetCategories().Any(e => e.Id == adModel.CategoryId))
            {
                ModelState.AddModelError(nameof(adModel.CategoryId), "Category does not exist!");
            }

            if (!ModelState.IsValid)
            {
                return View(adModel);
            }

            string currentUserId = GetUserId();

            var adToAdd = new Ad()
            {
                Name = adModel.Name,
                Description = adModel.Description,
                CreatedOn = DateTime.Now,
                CategoryId = adModel.CategoryId,
                Price = adModel.Price,
                OwnerId = currentUserId,
                ImageUrl = adModel.ImageUrl
            };

            await _data.Ads.AddAsync(adToAdd);
            await _data.SaveChangesAsync();

            return RedirectToAction("All", "Ad");
        }

        public async Task<IActionResult> All()
        {
            var adsToDisplay = await _data
                .Ads
                .Select(e => new AdViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    CreatedOn = e.CreatedOn.ToString("dd/MM/yyyy H:mm"),
                    Category = e.Category.Name,
                    Price = e.Price,
                    Owner = e.Owner.UserName,
                    ImageUrl = e.ImageUrl,
                })
                .ToListAsync();

            return View(adsToDisplay);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var adToEdit = await _data.Ads.FindAsync(id);

            if (adToEdit == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();
            if (currentUserId != adToEdit.OwnerId)
            {
                return Unauthorized();
            }

            AdFormModel adModel = new AdFormModel()
            {
                Name = adToEdit.Name,
                Description = adToEdit.Description,
                Price = adToEdit.Price,
                CategoryId = adToEdit.CategoryId,
                Categories = GetCategories(),
                ImageUrl = adToEdit.ImageUrl
            };

            return View(adModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AdFormModel adModel)
        {
            var adToEdit = await _data.Ads.FindAsync(id);

            if (adToEdit == null)
            {
                return BadRequest();
            }

            string currentUser = GetUserId();
            if (currentUser != adToEdit.OwnerId)
            {
                return Unauthorized();
            }

            if (!GetCategories().Any(e => e.Id == adModel.CategoryId))
            {
                ModelState.AddModelError(nameof(adModel.CategoryId), "Category does not exist!");
            }

            adToEdit.Name = adModel.Name;
            adToEdit.Description = adModel.Description;
            adToEdit.Price = adModel.Price;
            adToEdit.CategoryId = adModel.CategoryId;
            adToEdit.ImageUrl = adModel.ImageUrl;

            await _data.SaveChangesAsync();
            return RedirectToAction("All", "Ad");
        }

        public async Task<IActionResult> Cart()
        {
            string currentUserId = GetUserId();

            var userAds = await _data
                .AdsBuyers
                .Where(ab => ab.BuyerId == currentUserId)
                .Select(ab => new AdViewModel()
                {
                    Id = ab.Ad.Id,
                    Name = ab.Ad.Name,
                    Description = ab.Ad.Description,
                    CreatedOn = ab.Ad.CreatedOn.ToString("dd/MM/yyyy H:mm"),
                    Category = ab.Ad.Category.Name,
                    Price = ab.Ad.Price,
                    ImageUrl = ab.Ad.ImageUrl,
                    Owner = ab.Ad.Owner.ToString()
                })
                .ToListAsync();

            return View(userAds);
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            var adToAdd = await _data
                .Ads
                .FindAsync(id);

            if (adToAdd == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();

            var entry = new AdBuyer()
            {
                AdId = adToAdd.Id,
                BuyerId = currentUserId,
            };

            if (await _data.AdsBuyers.ContainsAsync(entry))
            {
                return RedirectToAction("Cart", "Ad");
            }

            await _data.AdsBuyers.AddAsync(entry);
            await _data.SaveChangesAsync();

            return RedirectToAction("Cart", "Ad");
        }

        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var adId = id;
            var currentUser = GetUserId();

            var adToRemove = _data.Ads.FindAsync(adId);

            if (adToRemove == null)
            {
                return BadRequest();
            }

            var entry = await _data.AdsBuyers.FirstOrDefaultAsync(ab => ab.BuyerId == currentUser && ab.AdId == adId);
            _data.AdsBuyers.Remove(entry);
            await _data.SaveChangesAsync();

            return RedirectToAction("All", "Ad");
        }

        // Helper methods
        // Get Categories
        private IEnumerable<CategoryViewModel> GetCategories()
            => _data
                .Categories
                .Select(t => new CategoryViewModel()
                {
                    Id = t.Id,
                    Name = t.Name
                });

        // Get currently logged-in user's Id
        private string GetUserId()
           => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}