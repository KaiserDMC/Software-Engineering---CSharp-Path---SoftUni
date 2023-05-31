using System.Text;
using System.Text.Json;
using Microsoft.Net.Http.Headers;

namespace MVCIntroDemo.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Product;
    using static Seeding.ProductsData;

    public class ProductController : Controller
    {
        public IActionResult All(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return View(Products);
            }

            IEnumerable<ProductViewModel> productAfterSearch = Products
                .Where(p => p.Name.ToLower().Contains(keyword.ToLower()))
                .ToArray();

            return View(productAfterSearch);
        }

        [Route("/Product/Details/{id?}")]
        public IActionResult ById(string id)
        {
            ProductViewModel? product = Products
                .FirstOrDefault(p => p.Id.ToString().Equals(id));

            if (product == null)
            {
                return this.RedirectToAction("All");
            }

            return this.View(product);
        }

        public IActionResult AllAsJson()
        {
            return Json(Products, new JsonSerializerOptions()
            {
                WriteIndented = true
            });
        }

        public IActionResult DownloadProductsInfo()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var product in Products)
            {
                stringBuilder.AppendLine($"Product with Id: {product.Id}");
                stringBuilder.AppendLine($"## Product Name: {product.Name}");
                stringBuilder.AppendLine($"## Price: {product.Price}");
                stringBuilder.AppendLine($"---------------------------------");
            }

            Response.Headers.Add(HeaderNames.ContentDisposition, "attachment;filename=products.txt");

            return File(Encoding.UTF8.GetBytes(stringBuilder.ToString()), "text/plain");
        }
    }
}
