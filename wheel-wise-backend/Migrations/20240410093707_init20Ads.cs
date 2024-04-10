using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace wheel_wise.Migrations
{
    /// <inheritdoc />
    public partial class init20Ads : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 10, 11, 37, 6, 963, DateTimeKind.Local).AddTicks(784));

            migrationBuilder.InsertData(
                table: "Advertisements",
                columns: new[] { "Id", "CarId", "CreatedAt", "Highlighted", "UserId" },
                values: new object[,]
                {
                    { 2, 2, new DateTime(2024, 4, 10, 11, 37, 6, 963, DateTimeKind.Local).AddTicks(842), false, null },
                    { 3, 3, new DateTime(2024, 4, 10, 11, 37, 6, 963, DateTimeKind.Local).AddTicks(846), false, null },
                    { 4, 4, new DateTime(2024, 4, 10, 11, 37, 6, 963, DateTimeKind.Local).AddTicks(849), false, null },
                    { 5, 5, new DateTime(2024, 4, 10, 11, 37, 6, 963, DateTimeKind.Local).AddTicks(852), false, null },
                    { 6, 6, new DateTime(2024, 4, 10, 11, 37, 6, 963, DateTimeKind.Local).AddTicks(855), false, null },
                    { 7, 7, new DateTime(2024, 4, 10, 11, 37, 6, 963, DateTimeKind.Local).AddTicks(858), false, null },
                    { 8, 8, new DateTime(2024, 4, 10, 11, 37, 6, 963, DateTimeKind.Local).AddTicks(861), false, null },
                    { 9, 9, new DateTime(2024, 4, 10, 11, 37, 6, 963, DateTimeKind.Local).AddTicks(864), false, null },
                    { 10, 10, new DateTime(2024, 4, 10, 11, 37, 6, 963, DateTimeKind.Local).AddTicks(867), false, null },
                    { 11, 11, new DateTime(2024, 4, 10, 11, 37, 6, 963, DateTimeKind.Local).AddTicks(870), false, null },
                    { 12, 12, new DateTime(2024, 4, 10, 11, 37, 6, 963, DateTimeKind.Local).AddTicks(873), false, null },
                    { 13, 13, new DateTime(2024, 4, 10, 11, 37, 6, 963, DateTimeKind.Local).AddTicks(876), false, null },
                    { 14, 14, new DateTime(2024, 4, 10, 11, 37, 6, 963, DateTimeKind.Local).AddTicks(879), false, null },
                    { 15, 15, new DateTime(2024, 4, 10, 11, 37, 6, 963, DateTimeKind.Local).AddTicks(882), false, null },
                    { 16, 16, new DateTime(2024, 4, 10, 11, 37, 6, 963, DateTimeKind.Local).AddTicks(885), false, null },
                    { 17, 17, new DateTime(2024, 4, 10, 11, 37, 6, 963, DateTimeKind.Local).AddTicks(888), false, null },
                    { 18, 18, new DateTime(2024, 4, 10, 11, 37, 6, 963, DateTimeKind.Local).AddTicks(891), false, null },
                    { 19, 19, new DateTime(2024, 4, 10, 11, 37, 6, 963, DateTimeKind.Local).AddTicks(893), false, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 10, 11, 35, 14, 364, DateTimeKind.Local).AddTicks(4470));
        }
    }
}
