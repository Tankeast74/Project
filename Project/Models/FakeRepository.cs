using Project.Services;
using System.Collections.Generic;

namespace Project.Models
{
    public class FakeRepository : IProductRepository
    {
        public IEnumerable<Product> Products => new List<Product>
        {
            new Product { Name = "Гамбургер", Price = 100, Category = "Бургеры"},
            new Product { Name = "Ролл", Price = 90, Category = "Роллы"},
            new Product { Name = "Пицца", Price = 150, Category = "Пицца"}
        };
    }
}
