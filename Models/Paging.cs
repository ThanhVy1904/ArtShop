using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtShop.Models
{
    public class Paging
    {
        public int TotalItem { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int totalPage => (int)Math.Ceiling((decimal)TotalItem / ItemsPerPage);
        public string UrlParam { get; set; }
    }
}
