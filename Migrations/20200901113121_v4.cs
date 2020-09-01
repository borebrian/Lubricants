using Microsoft.EntityFrameworkCore.Migrations;



namespace Lubricants.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category_title",
                table: "Items_category");

            migrationBuilder.AddColumn<string>(
                name: "Category_name",
                table: "Items_category",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category_name",
                table: "Items_category");

            migrationBuilder.AddColumn<string>(
                name: "Category_title",
                table: "Items_category",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
