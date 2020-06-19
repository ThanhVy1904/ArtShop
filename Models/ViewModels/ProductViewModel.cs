using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtShop.Models.ViewModels
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<Category> Category { get; set; }
        public Category CategoryList { get; set; }
        public IEnumerable<SelectListItem> CategoryList1 { get; set; }
    }
}
