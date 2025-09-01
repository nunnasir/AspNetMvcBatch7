using Microsoft.AspNetCore.Mvc;
using ProductInfo.Models;

namespace ProductInfo.Controllers
{
    public class productController : Controller
    {
        public IActionResult Index()
        {
            List<Product> products = new List<Product>
            {
                new Product {Id = 1, Name = "Laptop", Description = "A high-performance laptop", Price = 999.99m, Stock = 10},
                new Product {Id = 2, Name = "Smartphone", Description = "A latest model smartphone", Price = 699.99m, Stock = 25},
                new Product {Id = 3, Name = "Headphones", Description = "Noise-cancelling headphones", Price = 199.99m, Stock = 15},
                new Product {Id = 4, Name = "Smartwatch", Description = "A smartwatch with various features", Price = 299.99m, Stock = 30},
                new Product {Id = 5, Name = "Tablet", Description = "A lightweight tablet for everyday use", Price = 399.99m, Stock = 20}
            };

            return View(products);
        }
    }
}
