using Microsoft.EntityFrameworkCore.Migrations;

namespace Lubricants.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category_item",
                table: "Items_category");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Items_category");

            migrationBuilder.AddColumn<string>(
                name: "Category_title",
                table: "Items_category",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category_title",
                table: "Items_category");

            migrationBuilder.AddColumn<string>(
                name: "Category_item",
                table: "Items_category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Items_category",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
