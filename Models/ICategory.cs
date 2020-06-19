using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtShop.Models
{
    public interface ICategory
    {
        IEnumerable<Category> GetAllCategory { get; }
    }
}
