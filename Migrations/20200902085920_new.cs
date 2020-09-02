using Microsoft.EntityFrameworkCore.Migrations;

namespace Lubricants.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Item_categoryID",
                table: "Items_category",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_category_Item_categoryID",
                table: "Items_category",
                column: "Item_categoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_category_Items_category_Item_categoryID",
                table: "Items_category",
                column: "Item_categoryID",
                principalTable: "Items_category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_category_Items_category_Item_categoryID",
                table: "Items_category");

            migrationBuilder.DropIndex(
                name: "IX_Items_category_Item_categoryID",
                table: "Items_category");

            migrationBuilder.DropColumn(
                name: "Item_categoryID",
                table: "Items_category");
        }
    }
}
