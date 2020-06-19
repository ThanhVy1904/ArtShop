using Microsoft.EntityFrameworkCore.Migrations;

namespace ArtShop.Data.Migrations
{
    public partial class _delComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "OrderHeader");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "OrderHeader",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
