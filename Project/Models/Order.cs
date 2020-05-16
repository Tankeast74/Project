using Microsoft.AspNetCore.Builder;
using Project.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Order
    {
        [Required]
        public string OrderId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Telephone { get; set; }

        public IList<CartLine> Lines { get; set; }
    }
}
