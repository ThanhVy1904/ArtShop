using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace ArtShop.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set;}
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        public string ImgUrl { get; set; }
        [Display(Name = "Tình trạng")]
        public string Status { get; set;}
        public enum EStatus { On=0,Off=1}
        
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { set; get; }

    }
}
