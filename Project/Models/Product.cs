using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }
        public string Description { get; set; }

        [Required]
        public string Category { get; set; }
        public string ImgPath { get; set; }
    }
}
