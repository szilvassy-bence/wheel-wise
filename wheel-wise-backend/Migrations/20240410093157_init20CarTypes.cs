using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace wheel_wise.Migrations
{
    /// <inheritdoc />
    public partial class init20CarTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 10, 11, 31, 56, 540, DateTimeKind.Local).AddTicks(8251));

            migrationBuilder.InsertData(
                table: "CarTypes",
                columns: new[] { "Id", "Brand", "Model" },
                values: new object[,]
                {
                    { 3, "Ford", "Fiesta" },
                    { 4, "Toyota", "Corolla" },
                    { 5, "Volkswagen", "Golf" },
                    { 6, "BMW", "3 Series" },
                    { 7, "Mercedes-Benz", "C-Class" },
                    { 8, "Audi", "A3" },
                    { 9, "Honda", "Civic" },
                    { 10, "Hyundai", "i30" },
                    { 11, "Kia", "Rio" },
                    { 12, "Mazda", "3" },
                    { 13, "Nissan", "Micra" },
                    { 14, "Peugeot", "208" },
                    { 15, "Subaru", "Impreza" },
                    { 16, "Suzuki", "Swift" },
                    { 17, "Tesla", "Model 3" },
                    { 18, "Volvo", "V40" },
                    { 19, "Fiat", "500" },
                    { 20, "Skoda", "Octavia" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CarTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CarTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CarTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CarTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CarTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CarTypes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CarTypes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CarTypes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CarTypes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CarTypes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "CarTypes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "CarTypes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "CarTypes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "CarTypes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "CarTypes",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "CarTypes",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "CarTypes",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 9, 14, 11, 18, 458, DateTimeKind.Local).AddTicks(4633));
        }
    }
}
