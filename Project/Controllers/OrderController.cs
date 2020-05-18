using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;
using Project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class OrderController : Controller
    {
        private ApplicationDbContext _context;
        private CartService _cartService;
        private IOrderService _orderService;
        public OrderController(ApplicationDbContext context, CartService cartService, IOrderService orderService)
        {
            _context = context;
            _cartService = cartService;
            _orderService = orderService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Complete(Order order)
        {
            if(_cartService.Lines.Count() == 0)
            {
                var model = "В корзине ничего нет!";
                return View(model);
            }
            order.Lines = _cartService.Lines.ToList();
            await _orderService.SaveOrder(order);
            _cartService.Clear();
            return View();
        }
    }
}
