using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Threading.Tasks;
using ArtShop.Data;
using ArtShop.Models;
using ArtShop.Models.ViewModels;
using ArtShop.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe;

namespace ArtShop.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public OrderDetailCart detailCart { get; set; }
        public CartController(ApplicationDbContext db)
        {
            _db = db;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            detailCart = new OrderDetailCart()
            {
                OrderHeader = new Models.OrderHeader()
            };
            detailCart.OrderHeader.OrderTotal = 0;

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var cart = _db.ShoppingCart.Where(c => c.ApplicationUserId == claim.Value);
            if(cart != null)
            {
                detailCart.listCart = cart.ToList();
            }
            foreach(var list in detailCart.listCart)
            {
                list.Product = await _db.Products.FirstOrDefaultAsync(m => m.ProductId == list.ProductId);
                detailCart.OrderHeader.OrderTotal = detailCart.OrderHeader.OrderTotal + (list.Product.Price * list.Count);
                
            }
            return View(detailCart);
        }

        //Đặt hàng
        public async Task<IActionResult> Summary()
        {
            detailCart = new OrderDetailCart()
            {
                OrderHeader = new Models.OrderHeader()
            };
            detailCart.OrderHeader.OrderTotal = 0;

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            ApplicationUser applicationUser = await _db.ApplicationUser.Where(c => c.Id == claim.Value).FirstOrDefaultAsync();
            var cart = _db.ShoppingCart.Where(c => c.ApplicationUserId == claim.Value);

            if (cart != null)
            {
                detailCart.listCart = cart.ToList();
            }
            foreach (var list in detailCart.listCart)
            {
                list.Product = await _db.Products.FirstOrDefaultAsync(m => m.ProductId == list.ProductId);
                detailCart.OrderHeader.OrderTotal = detailCart.OrderHeader.OrderTotal + (list.Product.Price * list.Count);

            }
            detailCart.OrderHeader.PickupName = applicationUser.Name;
            detailCart.OrderHeader.PickupPhoneNumber = applicationUser.PhoneNumber;
            detailCart.OrderHeader.Address = applicationUser.Address;
            detailCart.OrderHeader.City = applicationUser.City;
            detailCart.OrderHeader.PickupDate = DateTime.Now;

            return View(detailCart);
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Summary")]
        public async Task<IActionResult> SummaryPost(string stripeToken)
        {
            string httt = Request.Form["rdHttt"].ToString();
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            detailCart.listCart = await _db.ShoppingCart.Where(c => c.ApplicationUserId == claim.Value).ToListAsync();

            detailCart.OrderHeader.OrderDate = DateTime.Now;
            detailCart.OrderHeader.PaymentStatus = StaticDetail.PaymentStatusPending;
            detailCart.OrderHeader.UserId = claim.Value;
            detailCart.OrderHeader.Status = StaticDetail.PaymentStatusPending;
            detailCart.OrderHeader.PickupDate = Convert.ToDateTime(detailCart.OrderHeader.PickupDate.ToShortDateString());
            //Thêm httt
            if(httt == StaticDetail.HtttCod)
            {
                detailCart.OrderHeader.Httt = StaticDetail.HtttCod;     
            }
            else
            {
                detailCart.OrderHeader.Httt = StaticDetail.HtttCard;
                
            }
            List<OrderDetail> orderDetailList = new List<OrderDetail>();
            _db.OrderHeader.Add(detailCart.OrderHeader);
            await _db.SaveChangesAsync();

            detailCart.OrderHeader.OrderTotal = 0;

            foreach (var item in detailCart.listCart)
            {
                item.Product = await _db.Products.FirstOrDefaultAsync(m => m.ProductId == item.ProductId);
                OrderDetail orderDetail = new OrderDetail
                {
                    ProductId = item.ProductId,
                    OrderId = detailCart.OrderHeader.Id,
                    Name = item.Product.ProductName,
                    Price = item.Product.Price,
                    Count = item.Count
                };
                detailCart.OrderHeader.OrderTotal += orderDetail.Count * orderDetail.Price;
                _db.OrderDetail.Add(orderDetail);
            }

            await _db.SaveChangesAsync();
            _db.ShoppingCart.RemoveRange(detailCart.listCart); //Xóa dl trong giỏ hàng
            HttpContext.Session.SetInt32(StaticDetail.ssShoppingCartCount, 0);
            await _db.SaveChangesAsync();


            //Stripe

            var options = new ChargeCreateOptions
            {
                Amount = Convert.ToInt32(detailCart.OrderHeader.OrderTotal),
                Currency = "vnd",
                Description = "Order ID: " + detailCart.OrderHeader.Id,
                Source = stripeToken
            };

            var service = new ChargeService();
            Charge charge = service.Create(options);

            if (charge.BalanceTransactionId == null)
            {
                detailCart.OrderHeader.PaymentStatus = StaticDetail.PaymentStatusRejected;
            }
            else
            {
                detailCart.OrderHeader.TransId = charge.BalanceTransactionId;
            }

            if (charge.Status.ToLower() == "succeeded")
            {
                detailCart.OrderHeader.PaymentStatus = StaticDetail.PaymentStatusApproved;
                detailCart.OrderHeader.Status = StaticDetail.StatusSubmitted;

            }
            else
            {
                detailCart.OrderHeader.PaymentStatus = StaticDetail.PaymentStatusRejected;
            }
            await _db.SaveChangesAsync();
            //return RedirectToAction("Index", "Home");
            return RedirectToAction("Confirm","Order", new{id=detailCart.OrderHeader.Id});
        }

        //
        //Đặt hàng
        public async Task<IActionResult> SummaryCod()
        {
            detailCart = new OrderDetailCart()
            {
                OrderHeader = new Models.OrderHeader()
            };
            detailCart.OrderHeader.OrderTotal = 0;

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            ApplicationUser applicationUser = await _db.ApplicationUser.Where(c => c.Id == claim.Value).FirstOrDefaultAsync();
            var cart = _db.ShoppingCart.Where(c => c.ApplicationUserId == claim.Value);

            if (cart != null)
            {
                detailCart.listCart = cart.ToList();
            }
            foreach (var list in detailCart.listCart)
            {
                list.Product = await _db.Products.FirstOrDefaultAsync(m => m.ProductId == list.ProductId);
                detailCart.OrderHeader.OrderTotal = detailCart.OrderHeader.OrderTotal + (list.Product.Price * list.Count);

            }
            detailCart.OrderHeader.PickupName = applicationUser.Name;
            detailCart.OrderHeader.PickupPhoneNumber = applicationUser.PhoneNumber;
            detailCart.OrderHeader.Address = applicationUser.Address;
            detailCart.OrderHeader.City = applicationUser.City;
            detailCart.OrderHeader.PickupDate = DateTime.Now;

            return View(detailCart);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("SummaryCod")]
        public async Task<IActionResult> SummaryCodPost(string stripeToken)
        {
            string httt = Request.Form["rdHttt"].ToString();
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            detailCart.listCart = await _db.ShoppingCart.Where(c => c.ApplicationUserId == claim.Value).ToListAsync();

            detailCart.OrderHeader.OrderDate = DateTime.Now;
            detailCart.OrderHeader.PaymentStatus = StaticDetail.PaymentStatusPending;
            detailCart.OrderHeader.UserId = claim.Value;
            detailCart.OrderHeader.Status = StaticDetail.PaymentStatusPending;
            detailCart.OrderHeader.PickupDate = Convert.ToDateTime(detailCart.OrderHeader.PickupDate.ToShortDateString());
            //Thêm httt
            detailCart.OrderHeader.Httt = StaticDetail.HtttCod;
            
            List<OrderDetail> orderDetailList = new List<OrderDetail>();
            _db.OrderHeader.Add(detailCart.OrderHeader);
            await _db.SaveChangesAsync();

            detailCart.OrderHeader.OrderTotal = 0;

            foreach (var item in detailCart.listCart)
            {
                item.Product = await _db.Products.FirstOrDefaultAsync(m => m.ProductId == item.ProductId);
                OrderDetail orderDetail = new OrderDetail
                {
                    ProductId = item.ProductId,
                    OrderId = detailCart.OrderHeader.Id,
                    Name = item.Product.ProductName,
                    Price = item.Product.Price,
                    Count = item.Count
                };
                detailCart.OrderHeader.OrderTotal += orderDetail.Count * orderDetail.Price;
                _db.OrderDetail.Add(orderDetail);
            }

            await _db.SaveChangesAsync();
            _db.ShoppingCart.RemoveRange(detailCart.listCart); //Xóa dl trong giỏ hàng
            HttpContext.Session.SetInt32(StaticDetail.ssShoppingCartCount, 0);
            await _db.SaveChangesAsync();

            detailCart.OrderHeader.TransId ="cod";
            detailCart.OrderHeader.PaymentStatus = StaticDetail.PaymentStatusApproved;
            detailCart.OrderHeader.Status = StaticDetail.StatusSubmitted;

            
            await _db.SaveChangesAsync();
            //return RedirectToAction("Index", "Home");
            return RedirectToAction("Confirm","Order", new {id=detailCart.OrderHeader.Id});
        }



        //Tăng Số lượng SP
        public async Task<IActionResult> Plus(int cartId)
        {
            var cart = await _db.ShoppingCart.FirstOrDefaultAsync(c => c.Id == cartId);
            cart.Count += 1;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //Giảm Số lượng SP
        public async Task<IActionResult> Minus(int cartId)
        {
            var cart = await _db.ShoppingCart.FirstOrDefaultAsync(c => c.Id == cartId);
            if(cart.Count == 1)
            {
                _db.ShoppingCart.Remove(cart);
                await _db.SaveChangesAsync();

                var cnt = _db.ShoppingCart.Where(u => u.ApplicationUserId == cart.ApplicationUserId).ToList().Count;
                HttpContext.Session.SetInt32(StaticDetail.ssShoppingCartCount, cnt);
            }
            else
            {
                cart.Count -= 1;
                await _db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
        //Xóa SP trong giỏ hàng
        public async Task<IActionResult> Remove(int cartId)
        {
            var cart = await _db.ShoppingCart.FirstOrDefaultAsync(c => c.Id == cartId);

            _db.ShoppingCart.Remove(cart);
            await _db.SaveChangesAsync();

            var cnt = _db.ShoppingCart.Where(u => u.ApplicationUserId == cart.ApplicationUserId).ToList().Count;
            HttpContext.Session.SetInt32(StaticDetail.ssShoppingCartCount, cnt);

            return RedirectToAction(nameof(Index));
        }

        

    }
}