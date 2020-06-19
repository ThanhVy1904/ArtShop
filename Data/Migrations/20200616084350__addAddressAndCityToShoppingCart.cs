using Microsoft.EntityFrameworkCore.Migrations;

namespace ArtShop.Data.Migrations
{
    public partial class _addAddressAndCityToShoppingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "OrderHeader",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "OrderHeader",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "OrderHeader");

            migrationBuilder.DropColumn(
                name: "City",
                table: "OrderHeader");
        }
    }
}
