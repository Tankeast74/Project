using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Helpers;
using Project.Models;
using Project.Services;
using Project.Views.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;

        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 4;
            var source = _productRepository.Products.AsQueryable();
            var count = await source.CountAsync();
            var list = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            var pageModel = new PageViewModel() { PageNumber = page, PageSize = pageSize, TotalItems = count };
            IndexViewModel model = new IndexViewModel
            {
                Products = list,
                PageInfo = pageModel
            };
            return View(model);
        }

        //public async Task<IActionResult> Privacy()
        //{
        //    return View();
        //}
    }
}
