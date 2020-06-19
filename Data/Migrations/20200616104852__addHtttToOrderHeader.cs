using Microsoft.EntityFrameworkCore.Migrations;

namespace ArtShop.Data.Migrations
{
    public partial class _addHtttToOrderHeader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Httt",
                table: "OrderHeader",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Httt",
                table: "OrderHeader");
        }
    }
}
