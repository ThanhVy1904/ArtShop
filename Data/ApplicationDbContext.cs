using System;
using System.Collections.Generic;
using System.Text;
using ArtShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ArtShop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }
        public DbSet<OrderHeader> OrderHeader { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().HasData(new Category { 
                CategoryId = 1,
                CategoryName = "Cọ vẽ"
            });
            builder.Entity<Category>().HasData(new Category
            {
                CategoryId = 2,
                CategoryName = "Màu"
            });
            builder.Entity<Category>().HasData(new Category
            {
                CategoryId = 3,
                CategoryName = "Giấy vẽ các loại"
            });
            builder.Entity<Category>().HasData(new Category
            {
                CategoryId = 4,
                CategoryName = "Bút"
            });
            builder.Entity<Category>().HasData(new Category
            {
                CategoryId = 5,
                CategoryName = "Phụ kiện"
            });
            //Product Seed DB
            builder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                ProductName = "Cọ vẽ ART SECRET Mop lông sóc thân đen",
                Price = 89000,
                Description = "Cọ vẽ lông sóc ART SECRET thân đen có 70% là cọ lông sóc tự nhiên nên không có hiện tượng rụng lông hay tòe cọ khi vẽ." +
                "Đầu cọ vuốt nhọn có thể vẽ tỉa nét, đồng thời cũng có độ ngậm nước rất tốt thích hợp cho loang tranh khổ rộng." +
                "Không bị biến dạng trong quá trình sử dụng, độ bền rất cao." +
                "Thích hợp vẽ tranh màu nước, gouache, poster, acrylic.",
                CategoryId = 1,
                Status = "0",
                ImgUrl = "\\img\\product\\1.jpg"
            });
            builder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                ProductName = "Cọ vẽ ART SECRET Mop lông sóc thân gỗ",
                Price = 88000,
                Description = "Cọ vẽ lông sóc ART SECRET thân gỗ có 70% là cọ lông sóc tự nhiên nên không có hiện tượng rụng lông hay tòe cọ khi vẽ." +
                " Đầu cọ vuốt nhọn có thể vẽ tỉa nét, đồng thời cũng có độ ngậm nước rất tốt thích hợp cho loang tranh khổ rộng." +
                " Không bị biến dạng trong quá trình sử dụng, độ bền rất cao." +
                " Thích hợp vẽ tranh màu nước, gouache, poster, acrylic.",
                CategoryId = 1,
                Status = "0",
                ImgUrl = "\\img\\product\\2.jpg"
            });
            builder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                ProductName = "Cọ vẽ ART SECRET đầu Tròn lông sóc thân đen",
                Price = 39000,
                Description = "Cọ nét ART SECRET lông sóc thân đen có 70% là cọ lông sóc tự nhiên nên không có hiện tượng rụng lông hay tòe cọ khi vẽ." +
                " Đầu cọ vuốt nhọn có thể vẽ tỉa nét, đồng thời cũng có độ ngậm nước rất tốt thích hợp cho loang tranh khổ rộng." +
                " Không bị biến dạng trong quá trình sử dụng, độ bền rất cao." +
                " Chuyên dụng trong tranh màu nước, màu Acrylic, màu bột",
                CategoryId = 1,
                Status = "0",
                ImgUrl = "\\img\\product\\3.jpg"
            });
            builder.Entity<Product>().HasData(new Product
            {
                ProductId = 4,
                ProductName = "Cọ Nước Waterbrush KURETAKE (thân ngắn)",
                Price = 74000,
                Description = "Lông cọ trong suốt, siêu mượt." +
                " Thiết kế gồm đầu cọ linh hoạt và thân cọ chứa nước." +
                " Thân cọ thiết kế vừa cầm, dễ mang theo." +
                " Tránh bơm màu trực tiếp có thể làm tắc ống dẫn nước.",
                CategoryId = 1,
                Status = "0",
                ImgUrl = "\\img\\product\\4.jpg"
            });
            builder.Entity<Product>().HasData(new Product
            {
                ProductId = 5,
                ProductName = "Cọ Nước Waterbrush KURETAKE thân dài (size Lớn)",
                Price = 83000,
                Description = "Lông cọ trong suốt, siêu mượt." +
                " Thiết kế gồm đầu cọ linh hoạt và thân cọ chứa nước." +
                " Thân cọ thiết kế vừa cầm, dễ mang theo." +
                " Tránh bơm màu trực tiếp có thể làm tắc ống dẫn nước.",
                CategoryId = 1,
                Status = "0",
                ImgUrl = "\\img\\product\\5.jpg"
            });
            builder.Entity<Product>().HasData(new Product
            {
                ProductId = 6,
                ProductName = "Bộ cọ vẽ ART SECRET vẽ sơn dầu và acrylic 10 cây",
                Price = 199000,
                Description = "Bộ cọ vẽ ART SECRET vẽ sơn dầu và acrylic được làm từ Lông lợn được nuôi trong khu vực của thành phố Chungking của Trung Quốc - vốn được xem là chất liệu tốt nhất dành để vẽ tranh gouache, acrylic và đặc biệt là sơn dầu." +
                " Dòng cọ vẽ Sơn Dầu thường có đầu lông rất cứng, có thể dùng chung cho màu Acrylic, nhưng rất hạn chế khi sử dụng màu Gouche, KHÔNG SỬ DỤNG CHO MÀU NƯỚC.",
                
                CategoryId = 1,
                Status = "0",
                ImgUrl = "\\img\\product\\6.jpg"
            });
            builder.Entity<Product>().HasData(new Product
            {
                ProductId = 7,
                ProductName = "Bộ cọ Thư Pháp ART SECRET lông Dê",
                Price = 410000,
                Description = "Cọ vẽ Thư Pháp ART SECRET làm từ lông Dê tự nhiên nên không có hiện tượng rụng lông hay tòe cọ." +
                " Đầu cọ vuốt nhọn có thể vẽ tỉa nét, đồng thời cũng có độ ngậm nước rất tốt thích hợp cho loang tranh khổ rộng." +
                " Không bị biến dạng trong quá trình sử dụng, độ bền rất cao." +
                " Thích hợp vẽ tranh màu nước, gouache, poster, acrylic.",
                CategoryId = 1,
                Status = "0",
                ImgUrl = "\\img\\product\\7.jpg"
            });
            builder.Entity<Product>().HasData(new Product
            {
                ProductId = 8,
                ProductName = "Bộ màu nước Nhũ 5/8 SUPERIOR",
                Price = 89000,
                Description = "Màu Nước NHŨ SUPERIOR với thiết kế mỗi thỏi màu được đựng trong một khay riêng và có thể gỡ ra khỏi bảng màu trong quá trình sử dụng." +
                " Bộ màu gồm những màu nhũ với tông màu ánh ngọc trai khác nhau, độ lên màu chuẩn và khả năng loang màu rộng, có thể dùng ngay màu gốc hoặc pha với các màu khác để có tông màu như ý." +
                " Bộ màu được đựng trong hộp nhưa tiện lợi, kèm theo một cọ nước, dễ dàng mang theo ra ngoài." +
                " Bảo quản mát, tránh nắng làm khô nứt màu.",
                CategoryId = 2,
                Status = "0",
                ImgUrl = "\\img\\product\\8.png"
            });
            builder.Entity<Product>().HasData(new Product
            {
                ProductId = 9,
                ProductName = "Bộ màu nước 18/24 OWIN",
                Price = 155000,
                Description = "Màu Nước O.WIN được thiết kế dạng nén nhỏ gọn, được đựng trong hộp nhựa tiện lợi." +
                " Độ lên màu chuẩn và khả năng loang màu rộng, màu sắc tươi sáng không chứa chất độc hại, có thể dùng ngay màu gốc hoặc pha với các màu khác để có tông màu như ý." +
                " Có kèm 1 cọ nước, nắp hộp được chia ngăn dùng làm khay pha màu, tiện dụng giúp mang theo bên người khi ra ngoài hoặc đi học. ",
                
                CategoryId = 2,
                Status = "0",
                ImgUrl = "\\img\\product\\9.png"
            });
            builder.Entity<Product>().HasData(new Product
            {
                ProductId = 10,
                ProductName = "Bộ màu nước 24/36 PRETTY EXCELLENT",
                Price = 89000,
                Description = "Màu Nước O.WIN dòng PRETTY EXCELLENT được thiết kế dạng nén nhỏ gọn, được đựng trong hộp thiếc có tông màu pastel nhã nhặn." +
                " Độ lên màu chuẩn và khả năng loang màu rộng, màu sắc tươi sáng không chứa chất độc hại, có thể dùng ngay màu gốc hoặc pha với các màu khác để có tông màu như ý." +
                " Có kèm 1 cọ nước nhỏ, nắp hộp được chia ngăn dùng làm khay pha màu,1  tiện dụng giúp mang theo bên người khi ra ngoài hoặc đi học. " +
                " Là sản phẩm lý tưởng làm quà tặng cho bạn bè, người thân trong các dịp lễ.",
                CategoryId = 2,
                Status = "0",
                ImgUrl = "\\img\\product\\10.png"
            });
            builder.Entity<Product>().HasData(new Product
            {
                ProductId = 11,
                ProductName = "Bút Marker MARIE'S màu Da",
                Price = 10000,
                Description = "Hãng MARIE được thành lập vào năm 1919, sau này hãng thành lập liên doanh và đổi tên là SHANGHAI SIIC MARIE PAINTING MATERIALS CO., LTD vào năm 1958. Các sản phẩm của Marie có mặt trên thị trường của các thành phố khác nhau trên khắp Trung Quốc và hơn 60 quốc gia trên thế giới, và đạt được chứng nhận chất lượng ISO 9001: 2000. Cái tên Marie's không chỉ nổi tiếng ở Trung Quốc mà ngày nay đã được công nhận là thương hiệu nổi tiếng của thị trường châu Âu và Mỹ.",
                CategoryId = 4,
                Status = "0",
                ImgUrl = "\\img\\product\\11.jpg"
            });
            builder.Entity<Product>().HasData(new Product
            {
                ProductId = 12,
                ProductName = "Bộ bút chì màu Khô 24/36/48 FABER & CASTELL",
                Price = 161000,
                Description = "Dùng như chì thông thường, tô theo lớp để chỉnh độ màu." +
                " Có khả năng chống gãy ngòi vượt trội. hơn hẳn tất cả các dòng chì màu trên thế giới, chất lượng họa sĩ thế giới tin dùng, màu sắc tươi sáng dễ pha trộn." +
                " Thể hiện bản vẽ kiến trúc - kỹ thuật, vẽ manga, chibi, minh họa,...",
                
                CategoryId = 2,
                Status = "0",
                ImgUrl = "\\img\\product\\12.jpg"
            });
            builder.Entity<Product>().HasData(new Product
            {
                ProductId = 13,
                ProductName = "Bộ bút chì màu Nước 24/36/48 FABER & CASTELL",
                Price = 216000,
                Description = "Không có mô tả..." ,
                
                CategoryId = 2,
                Status = "0",
                ImgUrl = "\\img\\product\\13.jpg"
            });
            builder.Entity<Product>().HasData(new Product
            {
                ProductId = 14,
                ProductName = "Bộ màu nước 12/24/36 WHITE NIGHTS",
                Price = 307000,
                Description = "White Nights là màu nước chuyên nghiệp có chất lượng cao nhất kết hợp phương pháp truyền thống của các bậc thầy xưa với kỹ thuật sản xuất hiện đại để tạo ra những thỏi màu nước nổi tiếng ngày  nay." +
                " Các thỏi màu dẻo, cô đặc được sản xuất từ chất màu mền mịn và thêm chất kết dính Gum Arabic - vốn được công nhận là chất kết dính tự nhiên tốt nhất cho màu nước chuyên nghiệp." +
                " Bảng màu bao gồm chủ yếu là các sắc tố đơn sắc tinh tế và không phai theo thời gian. Màu bền, ăn giấy tốt .Sử dụng tốt nhất là trong vẽ tranh lụa." +
                " Dùng nhiều trong ngành Mỹ Thuật , Kiến trúc … Và giới Mỹ Thuật chuyên nghiệp",
                CategoryId = 2,
                Status = "0",
                ImgUrl = "\\img\\product\\14.jpg"
            });
            builder.Entity<Product>().HasData(new Product
            {
                ProductId = 15,
                ProductName = "Bộ màu bột PENTEL Postercolors 12 màu",
                Price = 396000,
                Description = "Được thành lập hơn 70 năm, hãng Pentel tự hào đã cung cấp cho thế giới những sản phẩm chất lượng nhất. Pentel là công ty thiết bị văn phòng duy nhất nhận giải thưởng Deming Award về tiêu chuẩn chất lượng cao. Các sản phẩm từ bút chì bấm, chì than, gôm tẩy, bút vẽ, marker, vật liệu nghệ thuật... được sản xuất bởi các nhà máy thuộc sở hữu và giám sát của Pentel. Các sản phẩm của Pentel đều thân thiện với môi trường, có thể tái chế được. để tạo ra một môi trường lành mạnh hơn." +
                " Màu bột PENTEL rất dễ sử dụng, màu sắc sống động và độ lên màu tuyệt vời. " +
                " Có thể pha với nước để làm cho tranh vẽ mượt mà hơn hoặc làm tăng khả năng loang màu.",
                
                CategoryId = 2,
                Status = "0",
                ImgUrl = "\\img\\product\\15.jpg"
            });
            builder.Entity<Product>().HasData(new Product
            {
                ProductId = 16,
                ProductName = "Bộ màu bột PENTEL Postercolors 6 màu Cơ Bản (30ml)",
                Price = 246000,
                Description = "Không có mô tả...",
               
                CategoryId = 2,
                Status = "0",
                ImgUrl = "\\img\\product\\16.jpg"
            });
            builder.Entity<Product>().HasData(new Product
            {
                ProductId = 17,
                ProductName = "Giấy vẽ Canson MOULIN Du ROY 100% cotton 300gsm 56 x 38cm",
                Price = 54000,
                Description = "Canson là một hãng sản xuất giấy mỹ thuật hàng đầu thế giới có bề dày lịch sử bắt đầu từ năm 1557. Trong hơn 450 năm, Canson luôn mang cảm hứng cho nghệ sĩ khắp thế giới ở mọi lứa tuổi, mọi đối tượng từ người mới bắt đầu hoặc họa sĩ chuyên nghiệp. Canson luôn khẳng định khẩu hiệu “giấy khơi nguồn cảm hứng từ năm 1557.” Các dòng sản phẩm của hãng được nhiều họa sĩ chọn dùng do mang những đặc tính tuyệt vời : giấy dễ sử dụng, không chứa axit nên giấy không bị oxi hóa khi lưu trữ trong thời gian dài, hạn chế bị ẩm hay nấm mốc, không chứa bất kỳ chất phụ gia làm giấy trắng quá mức gây ảnh hưởng tới người dùng.",
                
                CategoryId = 3,
                Status = "0",
                ImgUrl = "\\img\\product\\17.jpg"
            });
            builder.Entity<Product>().HasData(new Product
            {
                ProductId = 18,
                ProductName = "Giấy vẽ Màu Nước HAPPY 300gsm",
                Price = 22000,
                Description = "Giấy hoàn toàn không chứa axit, không có chất làm sáng quang học, thân thiện với mội trường, độ trắng hoàn toàn tự nhiên giúp tăng thời gian bảo quản và lưu trữ tác phẩm được lâu hơn mà không bị ố vàng. Với những đặc điểm trên hãng đã được chứng nhận đạt tiêu chuẩn ISO 9706." +
                " Chuyên vẽ màu nước, màu Acrylic, màu bột, chì nước" ,
                
                CategoryId = 3,
                Status = "0",
                ImgUrl = "\\img\\product\\18.jpg"
            });
            builder.Entity<Product>().HasData(new Product
            {
                ProductId = 19,
                ProductName = "Giấy vẽ Canson PHÁP 125gsm",
                Price = 45000,
                Description = "anson là một hãng sản xuất giấy mỹ thuật hàng đầu thế giới có bề dày lịch sử bắt đầu từ năm 1557. Trong hơn 450 năm, Canson luôn mang cảm hứng cho nghệ sĩ khắp thế giới ở mọi lứa tuổi, mọi đối tượng từ người mới bắt đầu hoặc họa sĩ chuyên nghiệp. Canson luôn khẳng định khẩu hiệu “giấy khơi nguồn cảm hứng từ năm 1557.” Các dòng sản phẩm của hãng được nhiều họa sĩ chọn dùng do mang những đặc tính tuyệt vời : giấy dễ sử dụng, không chứa axit nên giấy không bị oxi hóa khi lưu trữ trong thời gian dài, hạn chế bị ẩm hay nấm mốc, không chứa bất kỳ chất phụ gia làm giấy trắng quá mức gây ảnh hưởng tới người dùng.",
               
                CategoryId = 3,
                Status = "0",
                ImgUrl = "\\img\\product\\19.jpg"
            });
            builder.Entity<Product>().HasData(new Product
            {
                ProductId = 20,
                ProductName = "Giấy vẽ Truyện Tranh HOLBEIN Maxon Standard Manga 110g A4",
                Price = 77000,
                Description = "Giấy không vân, mịn, giấy có kẻ sẵn khung tranh để vẽ truyện." +
                " Bề mặt giấy trơn nhẵn, vẽ mượt mà, giúp ngòi bút vẽ lâu bị mòn hơn." +
                " Giấy dai, chống sờn, gôm tẩy chì phác thảo thoải mái." ,
                CategoryId = 3,
                Status = "0",
                ImgUrl = "\\img\\product\\20.png"
            });
            builder.Entity<Product>().HasData(new Product
            {
                ProductId = 21,
                ProductName = "Bút đi nét MICRON SAKURA",
                Price = 24000,
                Description = " Không có mô tả...",
                
                CategoryId = 4,
                Status = "0",
                ImgUrl = "\\img\\product\\21.jpg"
            });
            builder.Entity<Product>().HasData(new Product
            {
                ProductId = 22,
                ProductName = "Bộ bút sắt SKYISTS (2 cây)",
                Price = 29000,
                Description = "Không có mô tả...",
               
                CategoryId = 4,
                Status = "0",
                ImgUrl = "\\img\\product\\22.jpg"
            });
            builder.Entity<Product>().HasData(new Product
            {
                ProductId = 23,
                ProductName = "Bút chì bấm PENTEL",
                Price = 65000,
                Description = "Không có mô tả...",
                
                CategoryId = 4,
                Status = "0",
                ImgUrl = "\\img\\product\\23.jpg"
            });
            builder.Entity<Product>().HasData(new Product
            {
                ProductId = 24,
                ProductName = "Bộ Bút Marker 24 TOUCHLIIT",
                Price = 200000,
                Description = " Bút có 2 đầu: 1 đầu nét và 1 đầu dẹp. Phù hợp với nhiều nét vẽ khác nhau." +
                " Mực gốc cồn, có chất lượng mực in được cải tiến hơn." +
                " Có thể sử dụng kết hợp với các loại bút marker gốc cồn khác." +
                " Màu không chứa Axit và không có mùi khó chịu.",
                CategoryId = 4,
                Status = "0",
                ImgUrl = "\\img\\product\\24.jpg"
            });
            builder.Entity<Product>().HasData(new Product
            {
                ProductId = 25,
                ProductName = "Bộ Bút Marker TOUCHLIIT 200 màu",
                Price = 1722000,
                Description = " Bút có 2 đầu: 1 đầu nét và 1 đầu dẹp. Phù hợp với nhiều nét vẽ khác nhau." +
                " Mực gốc cồn, có chất lượng mực in được cải tiến hơn." +
                " Có thể sử dụng kết hợp với các loại bút marker gốc cồn khác." +
                " Màu không chứa Axit và không có mùi khó chịu.",
                CategoryId = 4,
                Status = "0",
                ImgUrl = "\\img\\product\\25.jpg"
            });
            builder.Entity<Product>().HasData(new Product
            {
                ProductId = 26,
                ProductName = "Bảng vẽ ARTDOOR gỗ tự nhiên (3 lớp)",
                Price = 50000,
                Description = "Kê giấy vẽ, có tay cầm tiện dụng." +
                " Tuyết đối không ngâm bảng vẽ trong nước hoặc phơi bảng ngoài nắng sẽ làm cong sản phẩm." ,
                CategoryId = 5,
                Status = "0",
                ImgUrl = "\\img\\product\\26.png"
            });
            builder.Entity<Product>().HasData(new Product
            {
                ProductId = 27,
                ProductName = "Giá vẽ ART SECRET Nhỏ xách tay có ngăn kéo",
                Price = 462000,
                Description = "Giá vẽ ART SECRET Nhỏ xách tay với thiết kế thêm ngăn kéo dùng đựng màu và dụng cụ vẽ tiện lợi khi mang theo ra ngoài, cấu trúc kiểu chống sau, có nhiều mức nghiêng để điều chỉnh được độ nghiêng phù hợp với mọi góc vẽ. Sản phẩm phù hợp cho nhu cầu vẽ tranh khổ nhỏ, có thể đặt trực tiếp trên bàn để vẽ.",
                CategoryId = 5,
                Status = "0",
                ImgUrl = "\\img\\product\\27.jpg"
            });
            builder.Entity<Product>().HasData(new Product
            {
                ProductId = 28,
                ProductName = "Giá vẽ ART SECRET Mini để bàn",
                Price = 145000,
                Description = "Giá vẽ ART SECRET Mini với thiết kế gỗ nhỏ gọn, dễ thương, cấu trúc kiểu khung đế chịu lực tốt. Sản phẩm phù hợp cho nhu cầu vẽ tranh khổ nhỏ, có thể đặt trực tiếp trên bàn để vẽ.",
                CategoryId = 5,
                Status = "0",
                ImgUrl = "\\img\\product\\28.jpg"
            });
            builder.Entity<Product>().HasData(new Product
            {
                ProductId = 29,
                ProductName = "Cặp A3 (màu đen)",
                Price = 65000,
                Description = "Không có mô tả...",
                
                CategoryId = 5,
                Status = "0",
                ImgUrl = "\\img\\product\\29.jpg"
            });

        }

    }
}
