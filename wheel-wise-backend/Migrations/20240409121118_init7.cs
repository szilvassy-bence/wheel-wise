using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wheel_wise.Migrations
{
    /// <inheritdoc />
    public partial class init7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Types_CarTypeId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Cars_CarId",
                table: "Equipments");

            migrationBuilder.DropIndex(
                name: "IX_Equipments_CarId",
                table: "Equipments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Types",
                table: "Types");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Equipments");

            migrationBuilder.RenameTable(
                name: "Types",
                newName: "CarTypes");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Cars",
                type: "decimal(20,10)",
                precision: 20,
                scale: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarTypes",
                table: "CarTypes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CarEquipment",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false),
                    EquipmentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarEquipment", x => new { x.CarId, x.EquipmentsId });
                    table.ForeignKey(
                        name: "FK_CarEquipment_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarEquipment_Equipments_EquipmentsId",
                        column: x => x.EquipmentsId,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 9, 14, 11, 18, 458, DateTimeKind.Local).AddTicks(4633));

            migrationBuilder.CreateIndex(
                name: "IX_CarEquipment_EquipmentsId",
                table: "CarEquipment",
                column: "EquipmentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarTypes_CarTypeId",
                table: "Cars",
                column: "CarTypeId",
                principalTable: "CarTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarTypes_CarTypeId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "CarEquipment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarTypes",
                table: "CarTypes");

            migrationBuilder.RenameTable(
                name: "CarTypes",
                newName: "Types");

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Equipments",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Cars",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(20,10)",
                oldPrecision: 20,
                oldScale: 10);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Types",
                table: "Types",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 8, 14, 54, 45, 230, DateTimeKind.Local).AddTicks(4623));

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CarId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CarId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_CarId",
                table: "Equipments",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Types_CarTypeId",
                table: "Cars",
                column: "CarTypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Cars_CarId",
                table: "Equipments",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id");
        }
    }
}
