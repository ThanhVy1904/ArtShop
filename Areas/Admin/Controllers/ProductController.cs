using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArtShop.Data;
using ArtShop.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Hosting;
using ArtShop.Models.ViewModels;
using System.IO;
using ArtShop.Utility;
using ArtShop.Extensions;
using Microsoft.AspNetCore.Authorization;
using System.Text;

namespace ArtShop.Areas.Admin.Controllers
{
    [Authorize(Roles = StaticDetail.AdminUser)]
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IProduct _productRepository;
        
        [BindProperty]
        public ProductViewModel ProductVM { get; set; }
        public ProductController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment, IProduct productRepository)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
            _productRepository = productRepository;
            ProductVM = new ProductViewModel()
            {
                Category = _db.Category,
                Product = new Models.Product(),               
                CategoryList1 = _db.Category.ToList().Select(i => new SelectListItem
                {
                    Text = i.CategoryName,
                    Value = i.CategoryId.ToString()
                }),
            };
        }

        // GET: Admin/Product - index
        public IActionResult Index(string searchName)
        {
            StringBuilder param = new StringBuilder();
            param.Append("/Admin/Product");
            param.Append("&searchName=");
            if (searchName != null)
            {
                param.Append(searchName);
            }

            if (searchName == null)
            {
                var products = _db.Products.Include(p => p.Category).Where(m => m.Status == "0").ToList();
                return View(products);
            }
            else
            {
                var products = _db.Products.Include(p => p.Category).Where(m => m.Status == "0").Where(p=>p.ProductName.ToLower().Contains(searchName.ToLower())).ToList();
                return View(products);
            }
            
        }

        //GET - Details
        public async Task<IActionResult> ChiTiet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductVM.Product = await _db.Products.Include(m => m.Category).SingleOrDefaultAsync(m => m.ProductId == id);
            

            if (ProductVM.Product == null)
            {
                return NotFound();
            }

            return View(ProductVM);
        }

        // GET: Them
        public IActionResult Them()
        {
            ProductVM.Product.Status = "0";
            return View(ProductVM);
        }

        // POST: Them

        [HttpPost, ActionName("Them")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ThemPOST()
        {
            if (!ModelState.IsValid)
            {
                return View(ProductVM);
            }
            
            _db.Products.Add(ProductVM.Product);
            await _db.SaveChangesAsync();

            //Lưu ảnh
            string webRootPath = _webHostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            var productFromDB = await _db.Products.FindAsync(ProductVM.Product.ProductId);

            if (files.Count > 0)
            {
                //files đã được upload
                var uploads = Path.Combine(webRootPath, @"img\product\"); //Đường dẫn
                var extension = Path.GetExtension(files[0].FileName);

                using (var filesStream = new FileStream(Path.Combine(uploads, ProductVM.Product.ProductId + extension), FileMode.Create))
                {
                    files[0].CopyTo(filesStream);
                }
            productFromDB.ImgUrl = @"\img\product\"+ProductVM.Product.ProductId + extension;   
            }           
            else
            {
                //Không có files được upload, dùng ảnh mặc định
                var uploads = Path.Combine(webRootPath, @"img\product\" + StaticDetail.DefaultProductImg);
                System.IO.File.Copy(uploads, webRootPath + @"\img\product\"+ProductVM.Product.ProductId+".png");
                productFromDB.ImgUrl = @"\img\product\"+ProductVM.Product.ProductId+".png";
            }
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Sua
        public async Task<IActionResult> Sua(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            ProductVM.Product = await _db.Products.Include(m => m.Category).SingleOrDefaultAsync(m => m.ProductId == id);
            if(ProductVM.Product == null)
            {
                return NotFound();
            }
            return View(ProductVM);
        }

        // POST: Sua

        [HttpPost, ActionName("Sua")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SuaPOST(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
               return View(ProductVM);
            }
            
            //Lưu ảnh
            string webRootPath = _webHostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            var productFromDB = await _db.Products.FindAsync(ProductVM.Product.ProductId);

            if (files.Count > 0)
            {
                //Ảnh cũ đã được upload
                var uploads = Path.Combine(webRootPath, @"img\product\"); //Đường dẫn
                var extension_new = Path.GetExtension(files[0].FileName);

                //Xóa ảnh cũ
                var imgPath = Path.Combine(webRootPath, productFromDB.ImgUrl.TrimStart('\\'));
                if(System.IO.File.Exists(imgPath))
                {
                    System.IO.File.Delete(imgPath);
                }
                //Upload ảnh mới
                using (var filesStream = new FileStream(Path.Combine(uploads, ProductVM.Product.ProductId + extension_new), FileMode.Create))
                {
                    files[0].CopyTo(filesStream);
                }
                productFromDB.ImgUrl = @"\img\product\" + ProductVM.Product.ProductId + extension_new;
            }
            
            productFromDB.ProductName = ProductVM.Product.ProductName;
            productFromDB.Description = ProductVM.Product.Description;
            productFromDB.Price = ProductVM.Product.Price;
            productFromDB.Status = ProductVM.Product.Status;
            productFromDB.CategoryId = ProductVM.Product.CategoryId;

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Xoa(int id)
        {
            var product = _productRepository.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }
            else
            {   
                product.Status = "1";
                string webRootPath = _webHostEnvironment.WebRootPath;
                var imagePath = Path.Combine(webRootPath, product.ImgUrl.TrimStart('\\'));
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
