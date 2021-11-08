using Microsoft.EntityFrameworkCore.Migrations;

namespace CharlaDDD.Infrastructure.Migrations
{
    public partial class PizzaOrderItem_FK_Pizza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PizzaOrderItem_PizzaId",
                table: "PizzaOrderItem",
                column: "PizzaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaOrderItem_Pizzas_PizzaId",
                table: "PizzaOrderItem",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PizzaOrderItem_Pizzas_PizzaId",
                table: "PizzaOrderItem");

            migrationBuilder.DropIndex(
                name: "IX_PizzaOrderItem_PizzaId",
                table: "PizzaOrderItem");
        }
    }
}
