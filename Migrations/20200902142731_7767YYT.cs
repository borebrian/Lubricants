using Microsoft.EntityFrameworkCore.Migrations;

namespace Lubricants.Migrations
{
    public partial class _7767YYT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items_category",
                columns: table => new
                {
                    IDT = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category_name = table.Column<string>(maxLength: 50, nullable: false),
                    ImageURL = table.Column<string>(nullable: true),
                    Add_itemid = table.Column<int>(nullable: true),
                    Item_categoryIDT = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items_category", x => x.IDT);
                    table.ForeignKey(
                        name: "FK_Items_category_Items_category_Item_categoryIDT",
                        column: x => x.Item_categoryIDT,
                        principalTable: "Items_category",
                        principalColumn: "IDT",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Add_item",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category_id = table.Column<int>(nullable: false),
                    Item_name = table.Column<string>(maxLength: 50, nullable: false),
                    Item_price = table.Column<float>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    DateTime = table.Column<string>(nullable: false),
                    IDT = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Add_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_Add_item_Items_category_IDT",
                        column: x => x.IDT,
                        principalTable: "Items_category",
                        principalColumn: "IDT",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Add_item_IDT",
                table: "Add_item",
                column: "IDT");

            migrationBuilder.CreateIndex(
                name: "IX_Items_category_Add_itemid",
                table: "Items_category",
                column: "Add_itemid");

            migrationBuilder.CreateIndex(
                name: "IX_Items_category_Item_categoryIDT",
                table: "Items_category",
                column: "Item_categoryIDT");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_category_Add_item_Add_itemid",
                table: "Items_category",
                column: "Add_itemid",
                principalTable: "Add_item",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Add_item_Items_category_IDT",
                table: "Add_item");

            migrationBuilder.DropTable(
                name: "Items_category");

            migrationBuilder.DropTable(
                name: "Add_item");
        }
    }
}
