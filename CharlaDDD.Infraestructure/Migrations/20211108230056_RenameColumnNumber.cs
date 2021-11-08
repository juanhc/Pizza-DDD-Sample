using Microsoft.EntityFrameworkCore.Migrations;

namespace CharlaDDD.Infrastructure.Migrations
{
    public partial class RenameColumnNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Number",
                table: "PizzaOrderItem",
                newName: "NumberOfItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumberOfItems",
                table: "PizzaOrderItem",
                newName: "Number");
        }
    }
}
