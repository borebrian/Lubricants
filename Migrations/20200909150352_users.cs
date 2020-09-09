using Microsoft.EntityFrameworkCore.Migrations;

namespace Lubricants.Migrations
{
    public partial class users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "c_Users",
                columns: table => new
                {
                    strUserId = table.Column<string>(maxLength: 50, nullable: false),
                    strPhone = table.Column<string>(nullable: false),
                    strDOB = table.Column<string>(nullable: false),
                    strEmail = table.Column<string>(nullable: false),
                    strPassword = table.Column<string>(nullable: false),
                    strRole = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_c_Users", x => x.strUserId);
                });

            migrationBuilder.CreateTable(
                name: "Stock_summary",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item_price = table.Column<float>(nullable: false),
                    Category_name = table.Column<string>(nullable: true),
                    Item_name = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    ImageURL = table.Column<string>(nullable: true),
                    IDT = table.Column<string>(nullable: true),
                    item_sold = table.Column<int>(nullable: false),
                    Cash_made = table.Column<float>(nullable: false),
                    User_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock_summary", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "c_Users");

            migrationBuilder.DropTable(
                name: "Stock_summary");
        }
    }
}
