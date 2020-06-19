using Microsoft.EntityFrameworkCore.Migrations;

namespace ArtShop.Data.Migrations
{
    public partial class _delDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "OrderDetail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "OrderDetail",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
