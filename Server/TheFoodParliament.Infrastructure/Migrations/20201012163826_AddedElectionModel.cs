using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TheFoodParliament.Infrastructure.Migrations
{
    public partial class AddedElectionModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.CreateTable(
                name: "Elections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    WinnerId = table.Column<int>(nullable: false),
                    Votes = table.Column<int>(nullable: false),
                    WinningDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elections", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Elections");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreationDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 10, 12, 9, 11, 35, 385, DateTimeKind.Local).AddTicks(6790), "João" },
                    { 2, new DateTime(2020, 10, 12, 9, 11, 35, 425, DateTimeKind.Local).AddTicks(5360), "Maria" },
                    { 3, new DateTime(2020, 10, 12, 9, 11, 35, 425, DateTimeKind.Local).AddTicks(5420), "Pedro" },
                    { 4, new DateTime(2020, 10, 12, 9, 11, 35, 425, DateTimeKind.Local).AddTicks(5420), "Paula" }
                });
        }
    }
}
