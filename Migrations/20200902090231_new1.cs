using Microsoft.EntityFrameworkCore.Migrations;

namespace Lubricants.Migrations
{
    public partial class new1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriesBooks",
                columns: table => new
                {
                    id = table.Column<string>(maxLength: 50, nullable: false),
                    CatName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesBooks", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "catItems",
                columns: table => new
                {
                    ItemId = table.Column<string>(maxLength: 50, nullable: false),
                    ItemName = table.Column<string>(nullable: true),
                    CatId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_catItems", x => x.ItemId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriesBooks");

            migrationBuilder.DropTable(
                name: "catItems");
        }
    }
}
