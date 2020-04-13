using Project.Models;
using System.Collections.Generic;

namespace Project.Services
{
    public interface IProductRepository
    {
        public IEnumerable<Product> Products { get; }
    }
}
