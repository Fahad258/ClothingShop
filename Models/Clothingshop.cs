using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace clothingshopproject.Models
{
    public class Clothingshop
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Size { get; set; }

        [Required]
        [DisplayName("Product Code")]
        public string ProductCode { get; set; }
        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="Price Always Greater Then 0")]
        public int price { get; set; }
    }
}
