using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtShop.Models.ViewModels
{
    public class ProductIndexViewModel
    {
        public IEnumerable<Product> Product { get; set; }
        public IEnumerable<Category> Category { get; set; }
        public string CurrentCategory { get; set; }
    }
}
