using Microsoft.EntityFrameworkCore.Migrations;

namespace CharlaDDD.Infrastructure.Migrations
{
    public partial class PizzaIngredient_OnDeleteCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PizzaIngredient_Pizzas_PizzaId",
                table: "PizzaIngredient");

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaIngredient_Pizzas_PizzaId",
                table: "PizzaIngredient",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PizzaIngredient_Pizzas_PizzaId",
                table: "PizzaIngredient");

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaIngredient_Pizzas_PizzaId",
                table: "PizzaIngredient",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
