using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace wheel_wise.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Transmission",
                table: "Cars",
                newName: "TransmissionId");

            migrationBuilder.RenameColumn(
                name: "FuelType",
                table: "Cars",
                newName: "FuelTypeId");

            migrationBuilder.RenameColumn(
                name: "Color",
                table: "Cars",
                newName: "ColorId");

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuelType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transmission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transmission", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Advertisements",
                columns: new[] { "Id", "CarId", "CreatedAt", "Highlighted", "UserId" },
                values: new object[] { 1, 1, new DateTime(2024, 4, 8, 13, 36, 5, 117, DateTimeKind.Local).AddTicks(7800), false, null });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "TransmissionId",
                value: 1);

            migrationBuilder.InsertData(
                table: "Color",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "White" },
                    { 2, "Black" }
                });

            migrationBuilder.InsertData(
                table: "FuelType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Diesel" },
                    { 2, "Petrol" }
                });

            migrationBuilder.InsertData(
                table: "Transmission",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Manual" },
                    { 2, "Automatic" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "ColorId", "FuelTypeId", "Mileage", "Power", "Price", "Status", "TransmissionId", "TypeId", "Year" },
                values: new object[] { 2, 2, 2, 15000, 100, 20000m, 2, 2, 2, 2010 });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ColorId",
                table: "Cars",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_FuelTypeId",
                table: "Cars",
                column: "FuelTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_TransmissionId",
                table: "Cars",
                column: "TransmissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Color_ColorId",
                table: "Cars",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_FuelType_FuelTypeId",
                table: "Cars",
                column: "FuelTypeId",
                principalTable: "FuelType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Transmission_TransmissionId",
                table: "Cars",
                column: "TransmissionId",
                principalTable: "Transmission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Color_ColorId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_FuelType_FuelTypeId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Transmission_TransmissionId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "FuelType");

            migrationBuilder.DropTable(
                name: "Transmission");

            migrationBuilder.DropIndex(
                name: "IX_Cars_ColorId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_FuelTypeId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_TransmissionId",
                table: "Cars");

            migrationBuilder.DeleteData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "TransmissionId",
                table: "Cars",
                newName: "Transmission");

            migrationBuilder.RenameColumn(
                name: "FuelTypeId",
                table: "Cars",
                newName: "FuelType");

            migrationBuilder.RenameColumn(
                name: "ColorId",
                table: "Cars",
                newName: "Color");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "Transmission",
                value: 0);
        }
    }
}
