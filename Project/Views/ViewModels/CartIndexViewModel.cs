using Project.Services;
using System.Collections.Generic;

namespace Project.Views.ViewModels
{
    public class CartIndexViewModel
    {
        public IEnumerable<CartLine> CartLine { get; set; }
        public string ReturnUrl { get; set; }
    }
}
