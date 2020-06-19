using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtShop.Data;
using ArtShop.Models;
using ArtShop.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ArtShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = StaticDetail.AdminUser)]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _db.Category.ToListAsync());
        }
        //Get - Them
        public IActionResult Them()
        {
            return View();
        }

        //Post-Them
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Them(Category category)
        {
            if(ModelState.IsValid)
            {
                //Nếu tên hợp lệ
                _db.Category.Add(category);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        //Get - Sua
        public async Task<IActionResult> Sua(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var category = await _db.Category.FindAsync(id);
            if(category==null)
            {
                return NotFound();
            }
            return View(category);
        }

        //Post - Sua
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Sua(Category category)
        {
            if(ModelState.IsValid)
            {
                _db.Update(category);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

    }
}