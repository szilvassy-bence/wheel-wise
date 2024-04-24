using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wheel_wise.Migrations
{
    /// <inheritdoc />
    public partial class FixInvalidColumnNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 10, 57, 7, 3, DateTimeKind.Local).AddTicks(5574));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 10, 57, 7, 3, DateTimeKind.Local).AddTicks(5643));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 10, 57, 7, 3, DateTimeKind.Local).AddTicks(5646));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 10, 57, 7, 3, DateTimeKind.Local).AddTicks(5648));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 10, 57, 7, 3, DateTimeKind.Local).AddTicks(5650));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 10, 57, 7, 3, DateTimeKind.Local).AddTicks(5651));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 10, 57, 7, 3, DateTimeKind.Local).AddTicks(5653));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 10, 57, 7, 3, DateTimeKind.Local).AddTicks(5654));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 10, 57, 7, 3, DateTimeKind.Local).AddTicks(5656));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 10, 57, 7, 3, DateTimeKind.Local).AddTicks(5658));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 10, 57, 7, 3, DateTimeKind.Local).AddTicks(5659));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 10, 57, 7, 3, DateTimeKind.Local).AddTicks(5661));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 10, 57, 7, 3, DateTimeKind.Local).AddTicks(5662));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 10, 57, 7, 3, DateTimeKind.Local).AddTicks(5664));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 10, 57, 7, 3, DateTimeKind.Local).AddTicks(5665));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 10, 57, 7, 3, DateTimeKind.Local).AddTicks(5667));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 10, 57, 7, 3, DateTimeKind.Local).AddTicks(5668));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 10, 57, 7, 3, DateTimeKind.Local).AddTicks(5670));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 10, 57, 7, 3, DateTimeKind.Local).AddTicks(5672));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 10, 19, 2, 952, DateTimeKind.Local).AddTicks(4514));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 10, 19, 2, 952, DateTimeKind.Local).AddTicks(4561));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 10, 19, 2, 952, DateTimeKind.Local).AddTicks(4563));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 10, 19, 2, 952, DateTimeKind.Local).AddTicks(4565));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 10, 19, 2, 952, DateTimeKind.Local).AddTicks(4567));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 10, 19, 2, 952, DateTimeKind.Local).AddTicks(4568));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 10, 19, 2, 952, DateTimeKind.Local).AddTicks(4570));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 10, 19, 2, 952, DateTimeKind.Local).AddTicks(4571));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 10, 19, 2, 952, DateTimeKind.Local).AddTicks(4573));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 10, 19, 2, 952, DateTimeKind.Local).AddTicks(4575));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 10, 19, 2, 952, DateTimeKind.Local).AddTicks(4577));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 10, 19, 2, 952, DateTimeKind.Local).AddTicks(4579));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 10, 19, 2, 952, DateTimeKind.Local).AddTicks(4580));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 10, 19, 2, 952, DateTimeKind.Local).AddTicks(4582));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 10, 19, 2, 952, DateTimeKind.Local).AddTicks(4583));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 10, 19, 2, 952, DateTimeKind.Local).AddTicks(4585));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 10, 19, 2, 952, DateTimeKind.Local).AddTicks(4586));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 10, 19, 2, 952, DateTimeKind.Local).AddTicks(4588));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 10, 19, 2, 952, DateTimeKind.Local).AddTicks(4589));
        }
    }
}
