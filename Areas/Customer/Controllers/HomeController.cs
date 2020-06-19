using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ArtShop.Models;
using ArtShop.Models.ViewModels;
using ArtShop.Data;
using Microsoft.EntityFrameworkCore;
using ArtShop.Extensions;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using ArtShop.Utility;
using System.Text;

namespace ArtShop.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        
        private readonly ApplicationDbContext _db;
        private readonly IProduct _productRepository;
        private readonly ICategory _categoryRepository;

        public HomeController(ApplicationDbContext db, IProduct productRepository, ICategory categoryRepository)
        {
            _db = db;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
           
        }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null)
            {
                var cnt = _db.ShoppingCart.Where(u => u.ApplicationUserId == claim.Value).ToList().Count;
                HttpContext.Session.SetInt32(StaticDetail.ssShoppingCartCount, cnt);
            }

            return View();
           
        }

        public IActionResult Contact()
        {
            return View();

        }
        public IActionResult QA()
        {
            return View();

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //Index SP
        public async Task<IActionResult> ProductIndex(string searchProduct)
        {
            ProductIndexViewModel PIndexVM = new ProductIndexViewModel();
            StringBuilder param = new StringBuilder();
            param.Append("/Customer/Home/ProductIndex");
            param.Append("&searchName=");

            if (searchProduct != null)
            {
                param.Append(searchProduct);
            }

            if (searchProduct == null)
            {
                PIndexVM.Product = await _db.Products.Include(m => m.Category).Where(p => p.Status == "0").ToListAsync();
                PIndexVM.Category = await _db.Category.ToListAsync();
                
            }
            else
            {


                PIndexVM.Product = await _db.Products.Include(m => m.Category).Where(p => p.Status == "0").Where(p => p.ProductName.ToLower().Contains(searchProduct.ToLower())).ToListAsync();
                PIndexVM.Category = await _db.Category.ToListAsync();
                
            }


            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null)
            {
                var cnt = _db.ShoppingCart.Where(u => u.ApplicationUserId == claim.Value).ToList().Count;
                HttpContext.Session.SetInt32(StaticDetail.ssShoppingCartCount, cnt);
            }
            return View(PIndexVM);

        }       
        
        //Index SP 
       
        public IActionResult List(string category)
        {
            IEnumerable<Product> products;
            
            string currentCategory;
            if (string.IsNullOrEmpty(category))
            {
                products = _productRepository.GetAllProduct.OrderBy(c => c.ProductId).Where(s => s.Status == "0");
                currentCategory = "All";
            }
            else
            {
                products = _productRepository.GetAllProduct.Where(c => c.Category.CategoryName == category).Where(s => s.Status == "0");
                currentCategory = _categoryRepository.GetAllCategory.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }
            return View(new ProductIndexViewModel
            {
                Product = products,
                CurrentCategory = currentCategory
            }) ;

             
        }

        //[Authorize]
        //Chi tiet sp
        public async Task<IActionResult> ProductDetail(int id)
        {
            var productFromDb = await _db.Products.Include(m => m.Category).Where(m => m.ProductId == id).FirstOrDefaultAsync();
            ShoppingCart cartObj = new ShoppingCart()
            {
                Product = productFromDb,
                ProductId = productFromDb.ProductId
            };
            return View(cartObj);
        }

        //Add to cart
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductDetail(ShoppingCart cartObject)
        {
            cartObject.Id = 0;
            
            if(ModelState.IsValid)
            {
                
                var claimsIdentity = (ClaimsIdentity)this.User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                cartObject.ApplicationUserId = claim.Value;

                ShoppingCart cartFromDb = await _db.ShoppingCart.Where(c => c.ApplicationUserId == cartObject.ApplicationUserId && c.ProductId == cartObject.ProductId).FirstOrDefaultAsync();

                if(cartFromDb == null)
                {
                    await _db.ShoppingCart.AddAsync(cartObject);
                }
                else
                {
                    cartFromDb.Count = cartFromDb.Count + cartObject.Count ;
                }
                await _db.SaveChangesAsync();

                //Số lượng sp đã mua hiển thị trên giỏ hàng
                var count = _db.ShoppingCart.Where(c => c.ApplicationUserId == cartObject.ApplicationUserId).ToList().Count;
                HttpContext.Session.SetInt32(StaticDetail.ssShoppingCartCount, count);

                return RedirectToAction("ProductIndex");
            }
            else
            {
                var productFromDb = await _db.Products.Include(m => m.Category).Where(m => m.ProductId == cartObject.ProductId).FirstOrDefaultAsync();
                ShoppingCart cartObj = new ShoppingCart()
                {
                    Product = productFromDb,
                    ProductId = productFromDb.ProductId
                };
                return View(cartObj);
            }    
        }
        
    }
}
