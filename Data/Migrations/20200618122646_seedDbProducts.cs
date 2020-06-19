using Microsoft.EntityFrameworkCore.Migrations;

namespace ArtShop.Data.Migrations
{
    public partial class seedDbProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "ImgUrl",
                value: "\\img\\product\\1.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "Description", "ImgUrl", "Price", "ProductName" },
                values: new object[] { "Cọ vẽ lông sóc ART SECRET thân gỗ có 70% là cọ lông sóc tự nhiên nên không có hiện tượng rụng lông hay tòe cọ khi vẽ. Đầu cọ vuốt nhọn có thể vẽ tỉa nét, đồng thời cũng có độ ngậm nước rất tốt thích hợp cho loang tranh khổ rộng. Không bị biến dạng trong quá trình sử dụng, độ bền rất cao. Thích hợp vẽ tranh màu nước, gouache, poster, acrylic.", "\\img\\product\\2.jpg", 88000.0, "Cọ vẽ ART SECRET Mop lông sóc thân gỗ" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "Description", "ImgUrl", "Price", "ProductName" },
                values: new object[] { "Cọ nét ART SECRET lông sóc thân đen có 70% là cọ lông sóc tự nhiên nên không có hiện tượng rụng lông hay tòe cọ khi vẽ. Đầu cọ vuốt nhọn có thể vẽ tỉa nét, đồng thời cũng có độ ngậm nước rất tốt thích hợp cho loang tranh khổ rộng. Không bị biến dạng trong quá trình sử dụng, độ bền rất cao. Chuyên dụng trong tranh màu nước, màu Acrylic, màu bột", "\\img\\product\\3.jpg", 39000.0, "Cọ vẽ ART SECRET đầu Tròn lông sóc thân đen" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "Description", "ImgUrl", "Price", "ProductName" },
                values: new object[] { "Lông cọ trong suốt, siêu mượt. Thiết kế gồm đầu cọ linh hoạt và thân cọ chứa nước. Thân cọ thiết kế vừa cầm, dễ mang theo. Tránh bơm màu trực tiếp có thể làm tắc ống dẫn nước.", "\\img\\product\\4.jpg", 74000.0, "Cọ Nước Waterbrush KURETAKE (thân ngắn)" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "ImgUrl", "Price", "ProductName", "Status" },
                values: new object[,]
                {
                    { 29, 5, "Không có mô tả...", "\\img\\product\\29.jpg", 65000.0, "Cặp A3 (màu đen)", "0" },
                    { 28, 5, "Giá vẽ ART SECRET Mini với thiết kế gỗ nhỏ gọn, dễ thương, cấu trúc kiểu khung đế chịu lực tốt. Sản phẩm phù hợp cho nhu cầu vẽ tranh khổ nhỏ, có thể đặt trực tiếp trên bàn để vẽ.", "\\img\\product\\28.jpg", 145000.0, "Giá vẽ ART SECRET Mini để bàn", "0" },
                    { 27, 5, "Giá vẽ ART SECRET Nhỏ xách tay với thiết kế thêm ngăn kéo dùng đựng màu và dụng cụ vẽ tiện lợi khi mang theo ra ngoài, cấu trúc kiểu chống sau, có nhiều mức nghiêng để điều chỉnh được độ nghiêng phù hợp với mọi góc vẽ. Sản phẩm phù hợp cho nhu cầu vẽ tranh khổ nhỏ, có thể đặt trực tiếp trên bàn để vẽ.", "\\img\\product\\27.jpg", 462000.0, "Giá vẽ ART SECRET Nhỏ xách tay có ngăn kéo", "0" },
                    { 26, 5, "Kê giấy vẽ, có tay cầm tiện dụng. Tuyết đối không ngâm bảng vẽ trong nước hoặc phơi bảng ngoài nắng sẽ làm cong sản phẩm.", "\\img\\product\\26.png", 50000.0, "Bảng vẽ ARTDOOR gỗ tự nhiên (3 lớp)", "0" },
                    { 25, 4, " Bút có 2 đầu: 1 đầu nét và 1 đầu dẹp. Phù hợp với nhiều nét vẽ khác nhau. Mực gốc cồn, có chất lượng mực in được cải tiến hơn. Có thể sử dụng kết hợp với các loại bút marker gốc cồn khác. Màu không chứa Axit và không có mùi khó chịu.", "\\img\\product\\25.jpg", 1722000.0, "Bộ Bút Marker TOUCHLIIT 200 màu", "0" },
                    { 24, 4, " Bút có 2 đầu: 1 đầu nét và 1 đầu dẹp. Phù hợp với nhiều nét vẽ khác nhau. Mực gốc cồn, có chất lượng mực in được cải tiến hơn. Có thể sử dụng kết hợp với các loại bút marker gốc cồn khác. Màu không chứa Axit và không có mùi khó chịu.", "\\img\\product\\24.jpg", 200000.0, "Bộ Bút Marker 24 TOUCHLIIT", "0" },
                    { 23, 4, "Không có mô tả...", "\\img\\product\\23.jpg", 65000.0, "Bút chì bấm PENTEL", "0" },
                    { 22, 4, "Không có mô tả...", "\\img\\product\\22.jpg", 29000.0, "Bộ bút sắt SKYISTS (2 cây)", "0" },
                    { 21, 4, " Không có mô tả...", "\\img\\product\\21.jpg", 24000.0, "Bút đi nét MICRON SAKURA", "0" },
                    { 20, 3, "Giấy không vân, mịn, giấy có kẻ sẵn khung tranh để vẽ truyện. Bề mặt giấy trơn nhẵn, vẽ mượt mà, giúp ngòi bút vẽ lâu bị mòn hơn. Giấy dai, chống sờn, gôm tẩy chì phác thảo thoải mái.", "\\img\\product\\20.png", 77000.0, "Giấy vẽ Truyện Tranh HOLBEIN Maxon Standard Manga 110g A4", "0" },
                    { 19, 3, "anson là một hãng sản xuất giấy mỹ thuật hàng đầu thế giới có bề dày lịch sử bắt đầu từ năm 1557. Trong hơn 450 năm, Canson luôn mang cảm hứng cho nghệ sĩ khắp thế giới ở mọi lứa tuổi, mọi đối tượng từ người mới bắt đầu hoặc họa sĩ chuyên nghiệp. Canson luôn khẳng định khẩu hiệu “giấy khơi nguồn cảm hứng từ năm 1557.” Các dòng sản phẩm của hãng được nhiều họa sĩ chọn dùng do mang những đặc tính tuyệt vời : giấy dễ sử dụng, không chứa axit nên giấy không bị oxi hóa khi lưu trữ trong thời gian dài, hạn chế bị ẩm hay nấm mốc, không chứa bất kỳ chất phụ gia làm giấy trắng quá mức gây ảnh hưởng tới người dùng.", "\\img\\product\\19.jpg", 45000.0, "Giấy vẽ Canson PHÁP 125gsm", "0" },
                    { 17, 3, "Canson là một hãng sản xuất giấy mỹ thuật hàng đầu thế giới có bề dày lịch sử bắt đầu từ năm 1557. Trong hơn 450 năm, Canson luôn mang cảm hứng cho nghệ sĩ khắp thế giới ở mọi lứa tuổi, mọi đối tượng từ người mới bắt đầu hoặc họa sĩ chuyên nghiệp. Canson luôn khẳng định khẩu hiệu “giấy khơi nguồn cảm hứng từ năm 1557.” Các dòng sản phẩm của hãng được nhiều họa sĩ chọn dùng do mang những đặc tính tuyệt vời : giấy dễ sử dụng, không chứa axit nên giấy không bị oxi hóa khi lưu trữ trong thời gian dài, hạn chế bị ẩm hay nấm mốc, không chứa bất kỳ chất phụ gia làm giấy trắng quá mức gây ảnh hưởng tới người dùng.", "\\img\\product\\17.jpg", 54000.0, "Giấy vẽ Canson MOULIN Du ROY 100% cotton 300gsm 56 x 38cm", "0" },
                    { 16, 2, "Không có mô tả...", "\\img\\product\\16.jpg", 246000.0, "Bộ màu bột PENTEL Postercolors 6 màu Cơ Bản (30ml)", "0" },
                    { 15, 2, "Được thành lập hơn 70 năm, hãng Pentel tự hào đã cung cấp cho thế giới những sản phẩm chất lượng nhất. Pentel là công ty thiết bị văn phòng duy nhất nhận giải thưởng Deming Award về tiêu chuẩn chất lượng cao. Các sản phẩm từ bút chì bấm, chì than, gôm tẩy, bút vẽ, marker, vật liệu nghệ thuật... được sản xuất bởi các nhà máy thuộc sở hữu và giám sát của Pentel. Các sản phẩm của Pentel đều thân thiện với môi trường, có thể tái chế được. để tạo ra một môi trường lành mạnh hơn. Màu bột PENTEL rất dễ sử dụng, màu sắc sống động và độ lên màu tuyệt vời.  Có thể pha với nước để làm cho tranh vẽ mượt mà hơn hoặc làm tăng khả năng loang màu.", "\\img\\product\\15.jpg", 396000.0, "Bộ màu bột PENTEL Postercolors 12 màu", "0" },
                    { 14, 2, "White Nights là màu nước chuyên nghiệp có chất lượng cao nhất kết hợp phương pháp truyền thống của các bậc thầy xưa với kỹ thuật sản xuất hiện đại để tạo ra những thỏi màu nước nổi tiếng ngày  nay. Các thỏi màu dẻo, cô đặc được sản xuất từ chất màu mền mịn và thêm chất kết dính Gum Arabic - vốn được công nhận là chất kết dính tự nhiên tốt nhất cho màu nước chuyên nghiệp. Bảng màu bao gồm chủ yếu là các sắc tố đơn sắc tinh tế và không phai theo thời gian. Màu bền, ăn giấy tốt .Sử dụng tốt nhất là trong vẽ tranh lụa. Dùng nhiều trong ngành Mỹ Thuật , Kiến trúc … Và giới Mỹ Thuật chuyên nghiệp", "\\img\\product\\14.jpg", 307000.0, "Bộ màu nước 12/24/36 WHITE NIGHTS", "0" },
                    { 13, 2, "Không có mô tả...", "\\img\\product\\13.jpg", 216000.0, "Bộ bút chì màu Nước 24/36/48 FABER & CASTELL", "0" },
                    { 12, 2, "Dùng như chì thông thường, tô theo lớp để chỉnh độ màu. Có khả năng chống gãy ngòi vượt trội. hơn hẳn tất cả các dòng chì màu trên thế giới, chất lượng họa sĩ thế giới tin dùng, màu sắc tươi sáng dễ pha trộn. Thể hiện bản vẽ kiến trúc - kỹ thuật, vẽ manga, chibi, minh họa,...", "\\img\\product\\12.jpg", 161000.0, "Bộ bút chì màu Khô 24/36/48 FABER & CASTELL", "0" },
                    { 11, 4, "Hãng MARIE được thành lập vào năm 1919, sau này hãng thành lập liên doanh và đổi tên là SHANGHAI SIIC MARIE PAINTING MATERIALS CO., LTD vào năm 1958. Các sản phẩm của Marie có mặt trên thị trường của các thành phố khác nhau trên khắp Trung Quốc và hơn 60 quốc gia trên thế giới, và đạt được chứng nhận chất lượng ISO 9001: 2000. Cái tên Marie's không chỉ nổi tiếng ở Trung Quốc mà ngày nay đã được công nhận là thương hiệu nổi tiếng của thị trường châu Âu và Mỹ.", "\\img\\product\\11.jpg", 10000.0, "Bút Marker MARIE'S màu Da", "0" },
                    { 10, 2, "Màu Nước O.WIN dòng PRETTY EXCELLENT được thiết kế dạng nén nhỏ gọn, được đựng trong hộp thiếc có tông màu pastel nhã nhặn. Độ lên màu chuẩn và khả năng loang màu rộng, màu sắc tươi sáng không chứa chất độc hại, có thể dùng ngay màu gốc hoặc pha với các màu khác để có tông màu như ý. Có kèm 1 cọ nước nhỏ, nắp hộp được chia ngăn dùng làm khay pha màu,1  tiện dụng giúp mang theo bên người khi ra ngoài hoặc đi học.  Là sản phẩm lý tưởng làm quà tặng cho bạn bè, người thân trong các dịp lễ.", "\\img\\product\\10.png", 89000.0, "Bộ màu nước 24/36 PRETTY EXCELLENT", "0" },
                    { 9, 2, "Màu Nước O.WIN được thiết kế dạng nén nhỏ gọn, được đựng trong hộp nhựa tiện lợi. Độ lên màu chuẩn và khả năng loang màu rộng, màu sắc tươi sáng không chứa chất độc hại, có thể dùng ngay màu gốc hoặc pha với các màu khác để có tông màu như ý. Có kèm 1 cọ nước, nắp hộp được chia ngăn dùng làm khay pha màu, tiện dụng giúp mang theo bên người khi ra ngoài hoặc đi học. ", "\\img\\product\\9.png", 155000.0, "Bộ màu nước 18/24 OWIN", "0" },
                    { 8, 2, "Màu Nước NHŨ SUPERIOR với thiết kế mỗi thỏi màu được đựng trong một khay riêng và có thể gỡ ra khỏi bảng màu trong quá trình sử dụng. Bộ màu gồm những màu nhũ với tông màu ánh ngọc trai khác nhau, độ lên màu chuẩn và khả năng loang màu rộng, có thể dùng ngay màu gốc hoặc pha với các màu khác để có tông màu như ý. Bộ màu được đựng trong hộp nhưa tiện lợi, kèm theo một cọ nước, dễ dàng mang theo ra ngoài. Bảo quản mát, tránh nắng làm khô nứt màu.", "~\\img\\product\\8.png", 89000.0, "Bộ màu nước Nhũ 5/8 SUPERIOR", "0" },
                    { 7, 1, "Cọ vẽ Thư Pháp ART SECRET làm từ lông Dê tự nhiên nên không có hiện tượng rụng lông hay tòe cọ. Đầu cọ vuốt nhọn có thể vẽ tỉa nét, đồng thời cũng có độ ngậm nước rất tốt thích hợp cho loang tranh khổ rộng. Không bị biến dạng trong quá trình sử dụng, độ bền rất cao. Thích hợp vẽ tranh màu nước, gouache, poster, acrylic.", "~\\img\\product\\7.jpg", 410000.0, "Bộ cọ Thư Pháp ART SECRET lông Dê", "0" },
                    { 6, 1, "Bộ cọ vẽ ART SECRET vẽ sơn dầu và acrylic được làm từ Lông lợn được nuôi trong khu vực của thành phố Chungking của Trung Quốc - vốn được xem là chất liệu tốt nhất dành để vẽ tranh gouache, acrylic và đặc biệt là sơn dầu. Dòng cọ vẽ Sơn Dầu thường có đầu lông rất cứng, có thể dùng chung cho màu Acrylic, nhưng rất hạn chế khi sử dụng màu Gouche, KHÔNG SỬ DỤNG CHO MÀU NƯỚC.", "\\img\\product\\6.jpg", 199000.0, "Bộ cọ vẽ ART SECRET vẽ sơn dầu và acrylic 10 cây", "0" },
                    { 18, 3, "Giấy hoàn toàn không chứa axit, không có chất làm sáng quang học, thân thiện với mội trường, độ trắng hoàn toàn tự nhiên giúp tăng thời gian bảo quản và lưu trữ tác phẩm được lâu hơn mà không bị ố vàng. Với những đặc điểm trên hãng đã được chứng nhận đạt tiêu chuẩn ISO 9706. Chuyên vẽ màu nước, màu Acrylic, màu bột, chì nước", "\\img\\product\\18.jpg", 22000.0, "Giấy vẽ Màu Nước HAPPY 300gsm", "0" },
                    { 5, 1, "Lông cọ trong suốt, siêu mượt. Thiết kế gồm đầu cọ linh hoạt và thân cọ chứa nước. Thân cọ thiết kế vừa cầm, dễ mang theo. Tránh bơm màu trực tiếp có thể làm tắc ống dẫn nước.", "\\img\\product\\5.jpg", 83000.0, "Cọ Nước Waterbrush KURETAKE thân dài (size Lớn)", "0" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 29);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "ImgUrl",
                value: "~\\img\\product\\1.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "Description", "ImgUrl", "Price", "ProductName" },
                values: new object[] { "Cọ vẽ lông sóc ART SECRET thân đen có 70% là cọ lông sóc tự nhiên nên không có hiện tượng rụng lông hay tòe cọ khi vẽ.Đầu cọ vuốt nhọn có thể vẽ tỉa nét, đồng thời cũng có độ ngậm nước rất tốt thích hợp cho loang tranh khổ rộng.Không bị biến dạng trong quá trình sử dụng, độ bền rất cao.Thích hợp vẽ tranh màu nước, gouache, poster, acrylic.", "~\\img\\product\\2.jpg", 89000.0, "Cọ vẽ ART SECRET Mop lông sóc thân đen" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "Description", "ImgUrl", "Price", "ProductName" },
                values: new object[] { "Cọ vẽ lông sóc ART SECRET thân đen có 70% là cọ lông sóc tự nhiên nên không có hiện tượng rụng lông hay tòe cọ khi vẽ.Đầu cọ vuốt nhọn có thể vẽ tỉa nét, đồng thời cũng có độ ngậm nước rất tốt thích hợp cho loang tranh khổ rộng.Không bị biến dạng trong quá trình sử dụng, độ bền rất cao.Thích hợp vẽ tranh màu nước, gouache, poster, acrylic.", "~\\img\\product\\3.jpg", 89000.0, "Cọ vẽ ART SECRET Mop lông sóc thân đen" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "Description", "ImgUrl", "Price", "ProductName" },
                values: new object[] { "Cọ vẽ lông sóc ART SECRET thân đen có 70% là cọ lông sóc tự nhiên nên không có hiện tượng rụng lông hay tòe cọ khi vẽ.Đầu cọ vuốt nhọn có thể vẽ tỉa nét, đồng thời cũng có độ ngậm nước rất tốt thích hợp cho loang tranh khổ rộng.Không bị biến dạng trong quá trình sử dụng, độ bền rất cao.Thích hợp vẽ tranh màu nước, gouache, poster, acrylic.", "~\\img\\product\\4.jpg", 89000.0, "Cọ vẽ ART SECRET Mop lông sóc thân đen" });
        }
    }
}
