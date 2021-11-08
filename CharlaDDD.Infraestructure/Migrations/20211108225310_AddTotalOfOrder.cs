using Microsoft.EntityFrameworkCore.Migrations;

namespace CharlaDDD.Infrastructure.Migrations
{
    public partial class AddTotalOfOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Total",
                table: "PizzaOrders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "PizzaOrders");
        }
    }
}
