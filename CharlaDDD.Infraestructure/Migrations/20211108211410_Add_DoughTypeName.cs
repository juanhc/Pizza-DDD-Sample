using Microsoft.EntityFrameworkCore.Migrations;

namespace CharlaDDD.Infrastructure.Migrations
{
    public partial class Add_DoughTypeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DoughTypeName",
                table: "PizzaOrderItem",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoughTypeName",
                table: "PizzaOrderItem");
        }
    }
}
