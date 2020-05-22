using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext _context { get; set; }

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _context.Products.ToListAsync();
            return View(model);
        }

        public async Task<IActionResult> Edit(int productId)
        {
            var model = await _context.Products.FirstAsync(p => p.Id == productId);
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.Id == 0)
                {
                    _context.Add(product);
                }
                else
                {
                    var existedProduct = await _context.Products.FirstAsync(p => p.Id == product.Id);
                    existedProduct.Name = product.Name;
                    existedProduct.Description = product.Description;
                    existedProduct.Category = product.Category;
                    existedProduct.Price = product.Price;
                }
                await _context.SaveChangesAsync();
                TempData["message"] = $"{product.Name} успешно сохранен";
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int ProductId)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == ProductId);

            if (product == null)
                TempData["message"] = $"Продукт с таким Id не найден";
            else
            {
                TempData["message"] = $"Продукт {product.Name} успешно удален";
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
