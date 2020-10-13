using Microsoft.EntityFrameworkCore.Migrations;

namespace TheFoodParliament.Infrastructure.Migrations
{
    public partial class ChengedElectionPropertyNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WinnerId",
                table: "Elections");

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Elections",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Elections_RestaurantId",
                table: "Elections",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Elections_Restaurants_RestaurantId",
                table: "Elections",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elections_Restaurants_RestaurantId",
                table: "Elections");

            migrationBuilder.DropIndex(
                name: "IX_Elections_RestaurantId",
                table: "Elections");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Elections");

            migrationBuilder.AddColumn<int>(
                name: "WinnerId",
                table: "Elections",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
