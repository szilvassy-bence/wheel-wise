using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wheel_wise.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Types_TypeId",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transmission",
                table: "Transmission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FuelType",
                table: "FuelType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Color",
                table: "Color");

            migrationBuilder.RenameTable(
                name: "Transmission",
                newName: "Transmissions");

            migrationBuilder.RenameTable(
                name: "FuelType",
                newName: "FuelTypes");

            migrationBuilder.RenameTable(
                name: "Color",
                newName: "Colors");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Cars",
                newName: "CarTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_TypeId",
                table: "Cars",
                newName: "IX_Cars_CarTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transmissions",
                table: "Transmissions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FuelTypes",
                table: "FuelTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Colors",
                table: "Colors",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 8, 14, 54, 45, 230, DateTimeKind.Local).AddTicks(4623));

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Colors_ColorId",
                table: "Cars",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_FuelTypes_FuelTypeId",
                table: "Cars",
                column: "FuelTypeId",
                principalTable: "FuelTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Transmissions_TransmissionId",
                table: "Cars",
                column: "TransmissionId",
                principalTable: "Transmissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Types_CarTypeId",
                table: "Cars",
                column: "CarTypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Colors_ColorId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_FuelTypes_FuelTypeId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Transmissions_TransmissionId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Types_CarTypeId",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transmissions",
                table: "Transmissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FuelTypes",
                table: "FuelTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Colors",
                table: "Colors");

            migrationBuilder.RenameTable(
                name: "Transmissions",
                newName: "Transmission");

            migrationBuilder.RenameTable(
                name: "FuelTypes",
                newName: "FuelType");

            migrationBuilder.RenameTable(
                name: "Colors",
                newName: "Color");

            migrationBuilder.RenameColumn(
                name: "CarTypeId",
                table: "Cars",
                newName: "TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_CarTypeId",
                table: "Cars",
                newName: "IX_Cars_TypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transmission",
                table: "Transmission",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FuelType",
                table: "FuelType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Color",
                table: "Color",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 8, 13, 47, 47, 713, DateTimeKind.Local).AddTicks(2657));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Types_TypeId",
                table: "Cars",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
