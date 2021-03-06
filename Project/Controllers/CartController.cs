﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.Data;
using Project.Helpers;
using Project.Models;
using Project.Services;
using Project.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly CartService _cartService;
        public CartController(ApplicationDbContext context, CartService cartService)
        {
            _cartService = cartService;
            _context = context;
        }

        [HttpPost]
        public IActionResult AddToCart(int Id, string returnUrl)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == Id);
            if (product != null)
                _cartService.AddItem(product, 1);
            return ViewComponent("Cart", new { returnUrl });
        }

        [HttpPost]
        public RedirectToActionResult RemoveFromCart(int Id, string returnUrl)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == Id);
            if (product != null)
                _cartService.RemoveItem(product);
            return RedirectToAction("Index", new { returnUrl });
        }       

        public ActionResult Index(string returnUrl)
        {
            var model = new CartIndexViewModel
            {
                CartLine = _cartService.Lines,
                ReturnUrl = returnUrl
            };
            return View(model);
        }
    }
}
