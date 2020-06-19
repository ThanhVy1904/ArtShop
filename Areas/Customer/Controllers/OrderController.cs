using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ArtShop.Data;
using ArtShop.Models;
using ArtShop.Models.ViewModels;
using ArtShop.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtShop.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _db;
        private int PageSize = 5; //Số item trên 1 page.
        

        public OrderController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Authorize]
        public async Task<IActionResult> Confirm(int id)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            OrderDetailViewModel orderDetailViewModel = new OrderDetailViewModel()
            {
                OrderHeader = await _db.OrderHeader.Include(o=>o.ApplicationUser).FirstOrDefaultAsync(o=>o.Id == id && o.UserId == claim.Value),
                OrderDetail = await _db.OrderDetail.Where(o=>o.OrderId == id).ToListAsync()
            };
            return View(orderDetailViewModel);
        }

        //Xem lịch sử đặt hàng
        [Authorize]
        public async Task<IActionResult> OrderHistory(int productPage = 1)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            OrderListViewModel orderListVM = new OrderListViewModel()
            {
                Orders = new List<OrderDetailViewModel>(),
            };

            
            List<OrderHeader> orderHeaderList = await _db.OrderHeader.Include(o => o.ApplicationUser).Where(u => u.UserId == claim.Value).ToListAsync();

            foreach (OrderHeader item in orderHeaderList)
            {
                OrderDetailViewModel individual = new OrderDetailViewModel
                {
                    OrderHeader = item,
                    OrderDetail = await _db.OrderDetail.Where(o => o.OrderId == item.Id).ToListAsync()
                };
                orderListVM.Orders.Add(individual);
            }
            var count = orderListVM.Orders.Count;
            orderListVM.Orders = orderListVM.Orders.OrderByDescending(x => x.OrderHeader.Id).Skip((productPage-1)*PageSize).Take(PageSize).ToList();
            orderListVM.Pagings = new Paging
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItem = count,
                UrlParam = "/Customer/Order/OrderHistory?productPage=:"
            };
            return View(orderListVM);
        }

        public async Task<IActionResult> OrderDetails(int id)
        {
            OrderDetailViewModel orderDetailViewModel = new OrderDetailViewModel()
            {
                OrderHeader = await _db.OrderHeader.FirstOrDefaultAsync(m => m.Id == id),
                OrderDetail = await _db.OrderDetail.Where(m => m.OrderId == id).ToListAsync()
            };
            orderDetailViewModel.OrderHeader.ApplicationUser = await _db.ApplicationUser.FirstOrDefaultAsync(u => u.Id == orderDetailViewModel.OrderHeader.UserId);

            return PartialView("_OrderDetails", orderDetailViewModel);
        }

        //Quản lý đơn hàng
        [Authorize(Roles = StaticDetail.AdminUser)]//Thêm role
        public async Task<IActionResult> OrderPickup(int productPage = 1, string searchEmail = null, string searchName = null, string searchPhone = null)
        {
            //var claimsIdentity = (ClaimsIdentity)User.Identity;
            //var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            OrderListViewModel orderListVM = new OrderListViewModel()
            {
                Orders = new List<OrderDetailViewModel>(),
            };

            StringBuilder param = new StringBuilder();
            param.Append("/Customer/Order/OrderPickup?productPage=:");
            param.Append("&searchName=");
            if (searchName != null)
            {
                param.Append(searchName);
            }
            param.Append("&searchEmail=");
            if (searchEmail != null)
            {
                param.Append(searchEmail);
            }
            param.Append("&searchPhone=");
            if (searchPhone != null)
            {
                param.Append(searchPhone);
            }

            List<OrderHeader> orderHeaderList = new List<OrderHeader>();
            if (searchName != null || searchEmail != null || searchPhone != null)
            {
                var user = new ApplicationUser();

                if (searchName != null)
                {
                    orderHeaderList = await _db.OrderHeader.Include(o => o.ApplicationUser).Where(u => u.PickupName.ToLower().Contains(searchName.ToLower())).OrderByDescending(o => o.OrderDate).ToListAsync();
                }
                else
                {
                    if (searchEmail != null)
                    {
                        user = await _db.ApplicationUser.Where(u => u.Email.ToLower().Contains(searchEmail.ToLower())).FirstOrDefaultAsync();
                        orderHeaderList = await _db.OrderHeader.Include(o => o.ApplicationUser)
                            .Where(o => o.UserId == user.Id)
                            .OrderByDescending(o => o.OrderDate)
                            .ToListAsync();
                    }
                    else
                    {
                        if (searchPhone != null)
                        {
                            orderHeaderList = await _db.OrderHeader.Include(o => o.ApplicationUser).Where(u => u.PickupPhoneNumber.Contains(searchPhone)).OrderByDescending(o => o.OrderDate).ToListAsync();
                        }
                    }
                }
            }
            else
            {

                orderHeaderList = await _db.OrderHeader.Include(o => o.ApplicationUser).ToListAsync();//Where(u => u.Status == StaticDetail.StatusSubmitted)
            }
                foreach (OrderHeader item in orderHeaderList)
                {
                    OrderDetailViewModel individual = new OrderDetailViewModel
                    {
                        OrderHeader = item,
                        OrderDetail = await _db.OrderDetail.Where(o => o.OrderId == item.Id).ToListAsync()
                    };
                    orderListVM.Orders.Add(individual);
                }
            
            var count = orderListVM.Orders.Count;
            orderListVM.Orders = orderListVM.Orders.OrderByDescending(x => x.OrderHeader.Id).Skip((productPage - 1) * PageSize).Take(PageSize).ToList();
            orderListVM.Pagings = new Paging
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItem = count,
                UrlParam = param.ToString()
            };
            return View(orderListVM);
        }

        [HttpPost]
        [ActionName("OrderPickup")]
        [Authorize(Roles = StaticDetail.AdminUser)]
        public async Task<IActionResult> OrderPickupPost(int orderId)
        {
            OrderHeader orderHeader = await _db.OrderHeader.FindAsync(orderId);
            orderHeader.Status = StaticDetail.StatusCompleted;
            await _db.SaveChangesAsync();
            return RedirectToAction("OrderPickup", "Order");

        }

        
        [Authorize(Roles = StaticDetail.AdminUser)]
        public async Task<IActionResult> Cancel(int id)
        {
            OrderHeader orderHeader = await _db.OrderHeader.FindAsync(id);
            orderHeader.Status = StaticDetail.StatusCancelled;
            await _db.SaveChangesAsync();
            
            
            return RedirectToAction("OrderPickup", "Order");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}