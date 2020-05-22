using Project.Services;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Telephone { get; set; }

        public virtual IList<CartLine> Lines { get; set; }
    }
}
