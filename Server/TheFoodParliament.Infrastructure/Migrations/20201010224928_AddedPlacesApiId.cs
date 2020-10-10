using Microsoft.EntityFrameworkCore.Migrations;

namespace TheFoodParliament.Infrastructure.Migrations
{
    public partial class AddedPlacesApiId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlacesApiId",
                table: "Restaurants",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlacesApiId",
                table: "Restaurants");
        }
    }
}
