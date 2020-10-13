using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheFoodParliament.Infrastructure.Migrations
{
    public partial class AddDefaultUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreationDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 10, 13, 0, 11, 2, 907, DateTimeKind.Local).AddTicks(8300), "João" },
                    { 2, new DateTime(2020, 10, 13, 0, 11, 2, 935, DateTimeKind.Local).AddTicks(4070), "Maria" },
                    { 3, new DateTime(2020, 10, 13, 0, 11, 2, 935, DateTimeKind.Local).AddTicks(4130), "Pedro" },
                    { 4, new DateTime(2020, 10, 13, 0, 11, 2, 935, DateTimeKind.Local).AddTicks(4130), "Paula" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
