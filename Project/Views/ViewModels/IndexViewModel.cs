using Project.Helpers;
using Project.Models;
using System.Collections.Generic;

namespace Project.Views.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PageViewModel PageInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
