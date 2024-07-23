using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class AddCartEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartOrder",
                table: "Products",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Order = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TotalPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    AmountProducts = table.Column<int>(type: "INTEGER", nullable: false),
                    TypePayment = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Order);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CartOrder",
                table: "Products",
                column: "CartOrder");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Carts_CartOrder",
                table: "Products",
                column: "CartOrder",
                principalTable: "Carts",
                principalColumn: "Order",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Carts_CartOrder",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Products_CartOrder",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CartOrder",
                table: "Products");
        }
    }
}
