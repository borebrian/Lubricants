using Microsoft.EntityFrameworkCore.Migrations;

namespace Lubricants.Migrations
{
    public partial class addedSubmitTable3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tezt");

            migrationBuilder.CreateTable(
                name: "Submited_stock",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    item_id = table.Column<int>(nullable: false),
                    DateTime = table.Column<string>(nullable: false),
                    item_sold = table.Column<int>(nullable: false),
                    Cash_made = table.Column<float>(nullable: false),
                    User_id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submited_stock", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Submited_stock");

            migrationBuilder.CreateTable(
                name: "Tezt",
                columns: table => new
                {
                    IDT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tezt", x => x.IDT);
                });
        }
    }
}
