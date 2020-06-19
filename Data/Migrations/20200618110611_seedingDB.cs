using Microsoft.EntityFrameworkCore.Migrations;

namespace ArtShop.Data.Migrations
{
    public partial class seedingDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Cọ vẽ" },
                    { 2, "Màu" },
                    { 3, "Giấy vẽ các loại" },
                    { 4, "Bút" },
                    { 5, "Phụ kiện" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "ImgUrl", "Price", "ProductName", "Status" },
                values: new object[,]
                {
                    { 1, 1, "Cọ vẽ lông sóc ART SECRET thân đen có 70% là cọ lông sóc tự nhiên nên không có hiện tượng rụng lông hay tòe cọ khi vẽ.Đầu cọ vuốt nhọn có thể vẽ tỉa nét, đồng thời cũng có độ ngậm nước rất tốt thích hợp cho loang tranh khổ rộng.Không bị biến dạng trong quá trình sử dụng, độ bền rất cao.Thích hợp vẽ tranh màu nước, gouache, poster, acrylic.", "~\\img\\product\\1.jpg", 89000.0, "Cọ vẽ ART SECRET Mop lông sóc thân đen", "0" },
                    { 2, 1, "Cọ vẽ lông sóc ART SECRET thân đen có 70% là cọ lông sóc tự nhiên nên không có hiện tượng rụng lông hay tòe cọ khi vẽ.Đầu cọ vuốt nhọn có thể vẽ tỉa nét, đồng thời cũng có độ ngậm nước rất tốt thích hợp cho loang tranh khổ rộng.Không bị biến dạng trong quá trình sử dụng, độ bền rất cao.Thích hợp vẽ tranh màu nước, gouache, poster, acrylic.", "~\\img\\product\\2.jpg", 89000.0, "Cọ vẽ ART SECRET Mop lông sóc thân đen", "0" },
                    { 3, 1, "Cọ vẽ lông sóc ART SECRET thân đen có 70% là cọ lông sóc tự nhiên nên không có hiện tượng rụng lông hay tòe cọ khi vẽ.Đầu cọ vuốt nhọn có thể vẽ tỉa nét, đồng thời cũng có độ ngậm nước rất tốt thích hợp cho loang tranh khổ rộng.Không bị biến dạng trong quá trình sử dụng, độ bền rất cao.Thích hợp vẽ tranh màu nước, gouache, poster, acrylic.", "~\\img\\product\\3.jpg", 89000.0, "Cọ vẽ ART SECRET Mop lông sóc thân đen", "0" },
                    { 4, 1, "Cọ vẽ lông sóc ART SECRET thân đen có 70% là cọ lông sóc tự nhiên nên không có hiện tượng rụng lông hay tòe cọ khi vẽ.Đầu cọ vuốt nhọn có thể vẽ tỉa nét, đồng thời cũng có độ ngậm nước rất tốt thích hợp cho loang tranh khổ rộng.Không bị biến dạng trong quá trình sử dụng, độ bền rất cao.Thích hợp vẽ tranh màu nước, gouache, poster, acrylic.", "~\\img\\product\\4.jpg", 89000.0, "Cọ vẽ ART SECRET Mop lông sóc thân đen", "0" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1);
        }
    }
}
