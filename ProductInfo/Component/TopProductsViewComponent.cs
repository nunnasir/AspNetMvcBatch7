using Microsoft.AspNetCore.Mvc;
using ProductInfo.Models;

namespace ProductInfo.Component
{
    public class TopProductsViewComponent : ViewComponent
    {


        private static readonly List<Product> Data = [
            new Product {Id = 1, Name = "Laptop", Description = "A high-performance laptop", Price = 999.99m, Stock = 10},
                new Product {Id = 2, Name = "Smartphone", Description = "A latest model smartphone", Price = 699.99m, Stock = 25},
                new Product {Id = 3, Name = "Headphones", Description = "Noise-cancelling headphones", Price = 199.99m, Stock = 15},
                new Product {Id = 4, Name = "Smartwatch", Description = "A smartwatch with various features", Price = 299.99m, Stock = 30},
                new Product {Id = 5, Name = "Tablet", Description = "A lightweight tablet for everyday use", Price = 399.99m, Stock = 20}
        ];

        public IViewComponentResult Invoke(int count = 3)
        {
            var items = Data.Take(count).ToList();

            return View("TopProducts",items);
        }
    }
}
