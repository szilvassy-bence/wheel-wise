using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace wheel_wise.Migrations
{
    /// <inheritdoc />
    public partial class init20Cars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 10, 11, 35, 14, 364, DateTimeKind.Local).AddTicks(4470));

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CarTypeId", "ColorId", "FuelTypeId", "Mileage", "Power", "Price", "Status", "TransmissionId", "Year" },
                values: new object[,]
                {
                    { 3, 3, 1, 1, 18000, 120, 25000m, 1, 1, 2012 },
                    { 4, 4, 2, 2, 20000, 140, 30000m, 2, 2, 2015 },
                    { 5, 5, 1, 1, 15000, 160, 35000m, 1, 1, 2018 },
                    { 6, 6, 2, 2, 10000, 180, 40000m, 0, 2, 2020 },
                    { 7, 7, 1, 1, 22000, 150, 32000m, 1, 1, 2016 },
                    { 8, 8, 2, 2, 19000, 130, 28000m, 1, 2, 2014 },
                    { 9, 9, 1, 1, 17000, 170, 33000m, 1, 1, 2017 },
                    { 10, 10, 2, 2, 14000, 190, 37000m, 0, 2, 2019 },
                    { 11, 11, 1, 1, 21000, 140, 26000m, 0, 1, 2013 },
                    { 12, 12, 2, 2, 18000, 160, 32000m, 0, 2, 2016 },
                    { 13, 13, 1, 1, 20000, 170, 33000m, 0, 1, 2017 },
                    { 14, 14, 2, 2, 18000, 150, 30000m, 0, 2, 2015 },
                    { 15, 15, 1, 1, 15000, 170, 35000m, 0, 1, 2018 },
                    { 16, 16, 2, 2, 12000, 190, 37000m, 0, 2, 2019 },
                    { 17, 17, 1, 1, 19000, 140, 28000m, 0, 1, 2014 },
                    { 18, 18, 2, 2, 18000, 160, 32000m, 0, 2, 2016 },
                    { 19, 19, 1, 1, 20000, 170, 33000m, 0, 1, 2017 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 10, 11, 31, 56, 540, DateTimeKind.Local).AddTicks(8251));
        }
    }
}
