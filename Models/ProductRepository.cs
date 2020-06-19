using ArtShop.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtShop.Models
{
    public class ProductRepository : IProduct
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Product> GetAllProduct
        {
            get
            {
                return _db.Products.Include(c => c.Category);
            }
        }

        public IEnumerable<Product> GetProductOnSale
        {
            get
            {
                return _db.Products.Include(c => c.Category).Where(p => p.Status == "0");
            }
        }
        public Product GetProductById(int productId)
        {
            return _db.Products.FirstOrDefault(c => c.ProductId == productId);
        }
    }
}
