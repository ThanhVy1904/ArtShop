using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtShop.Models.ViewModels
{
    public class OrderListViewModel
    {
        public IList<OrderDetailViewModel> Orders { get; set; }
        public Paging Pagings { get; set; }
    }
}
