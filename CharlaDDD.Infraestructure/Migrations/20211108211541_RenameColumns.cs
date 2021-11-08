using Microsoft.EntityFrameworkCore.Migrations;

namespace CharlaDDD.Infrastructure.Migrations
{
    public partial class RenameColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "_basePrice",
                table: "Pizzas",
                newName: "BasePrice");

            migrationBuilder.RenameColumn(
                name: "_date",
                table: "PizzaOrders",
                newName: "CreatedAt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BasePrice",
                table: "Pizzas",
                newName: "_basePrice");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "PizzaOrders",
                newName: "_date");
        }
    }
}
