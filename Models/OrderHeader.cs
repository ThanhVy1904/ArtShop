using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ArtShop.Models
{
    public class OrderHeader
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0} VND")]
        [Display(Name ="Thành tiền")]
        public double OrderTotal { get; set; }
        [Required]
        [Display(Name ="Ngày giao hàng")]
        public DateTime PickupDate { get; set; }

        public string Status { get; set; }
        public string PaymentStatus { get; set; }

        [Display(Name ="Tên người nhận")]
        public string PickupName { get; set; }
        [Display(Name = "Số điện thoại")]
        public string PickupPhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string TransId { get; set; }
        public string Comment { get; set; }
        [Display(Name ="Hình thức thanh toán")]
        public string Httt { get; set; }
    }
}
