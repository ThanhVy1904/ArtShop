using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtShop.Models.ViewModels
{
    public class ProductListViewModel
    {
        public IList<ProductViewModel> Products { get; set; }
        public Paging Pagings { get; set; }
    }
}
