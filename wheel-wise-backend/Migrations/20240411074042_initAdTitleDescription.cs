using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wheel_wise.Migrations
{
    /// <inheritdoc />
    public partial class initAdTitleDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Advertisements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Advertisements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "Title" },
                values: new object[] { new DateTime(2024, 4, 11, 9, 40, 42, 562, DateTimeKind.Local).AddTicks(9014), "description", "title" });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "Title" },
                values: new object[] { new DateTime(2024, 4, 11, 9, 40, 42, 562, DateTimeKind.Local).AddTicks(9071), "description", "title" });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description", "Title" },
                values: new object[] { new DateTime(2024, 4, 11, 9, 40, 42, 562, DateTimeKind.Local).AddTicks(9073), "description", "title" });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Description", "Title" },
                values: new object[] { new DateTime(2024, 4, 11, 9, 40, 42, 562, DateTimeKind.Local).AddTicks(9075), "description", "title" });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Description", "Title" },
                values: new object[] { new DateTime(2024, 4, 11, 9, 40, 42, 562, DateTimeKind.Local).AddTicks(9077), "description", "title" });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Description", "Title" },
                values: new object[] { new DateTime(2024, 4, 11, 9, 40, 42, 562, DateTimeKind.Local).AddTicks(9079), "description", "title" });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Description", "Title" },
                values: new object[] { new DateTime(2024, 4, 11, 9, 40, 42, 562, DateTimeKind.Local).AddTicks(9081), "description", "title" });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Description", "Title" },
                values: new object[] { new DateTime(2024, 4, 11, 9, 40, 42, 562, DateTimeKind.Local).AddTicks(9082), "description", "title" });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Description", "Title" },
                values: new object[] { new DateTime(2024, 4, 11, 9, 40, 42, 562, DateTimeKind.Local).AddTicks(9084), "description", "title" });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Description", "Title" },
                values: new object[] { new DateTime(2024, 4, 11, 9, 40, 42, 562, DateTimeKind.Local).AddTicks(9086), "description", "title" });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "Description", "Title" },
                values: new object[] { new DateTime(2024, 4, 11, 9, 40, 42, 562, DateTimeKind.Local).AddTicks(9087), "description", "title" });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "Description", "Title" },
                values: new object[] { new DateTime(2024, 4, 11, 9, 40, 42, 562, DateTimeKind.Local).AddTicks(9089), "description", "title" });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "Description", "Title" },
                values: new object[] { new DateTime(2024, 4, 11, 9, 40, 42, 562, DateTimeKind.Local).AddTicks(9091), "description", "title" });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "Description", "Title" },
                values: new object[] { new DateTime(2024, 4, 11, 9, 40, 42, 562, DateTimeKind.Local).AddTicks(9092), "description", "title" });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "Description", "Title" },
                values: new object[] { new DateTime(2024, 4, 11, 9, 40, 42, 562, DateTimeKind.Local).AddTicks(9094), "description", "title" });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "Description", "Title" },
                values: new object[] { new DateTime(2024, 4, 11, 9, 40, 42, 562, DateTimeKind.Local).AddTicks(9096), "description", "title" });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "Description", "Title" },
                values: new object[] { new DateTime(2024, 4, 11, 9, 40, 42, 562, DateTimeKind.Local).AddTicks(9097), "description", "title" });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Description", "Title" },
                values: new object[] { new DateTime(2024, 4, 11, 9, 40, 42, 562, DateTimeKind.Local).AddTicks(9099), "description", "title" });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Description", "Title" },
                values: new object[] { new DateTime(2024, 4, 11, 9, 40, 42, 562, DateTimeKind.Local).AddTicks(9101), "description", "title" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Advertisements");

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 10, 11, 37, 6, 963, DateTimeKind.Local).AddTicks(784));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 10, 11, 37, 6, 963, DateTimeKind.Local).AddTicks(842));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 10, 11, 37, 6, 963, DateTimeKind.Local).AddTicks(846));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 10, 11, 37, 6, 963, DateTimeKind.Local).AddTicks(849));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 10, 11, 37, 6, 963, DateTimeKind.Local).AddTicks(852));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 10, 11, 37, 6, 963, DateTimeKind.Local).AddTicks(855));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 10, 11, 37, 6, 963, DateTimeKind.Local).AddTicks(858));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 10, 11, 37, 6, 963, DateTimeKind.Local).AddTicks(861));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 10, 11, 37, 6, 963, DateTimeKind.Local).AddTicks(864));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 10, 11, 37, 6, 963, DateTimeKind.Local).AddTicks(867));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 10, 11, 37, 6, 963, DateTimeKind.Local).AddTicks(870));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 10, 11, 37, 6, 963, DateTimeKind.Local).AddTicks(873));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 10, 11, 37, 6, 963, DateTimeKind.Local).AddTicks(876));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 10, 11, 37, 6, 963, DateTimeKind.Local).AddTicks(879));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 10, 11, 37, 6, 963, DateTimeKind.Local).AddTicks(882));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 10, 11, 37, 6, 963, DateTimeKind.Local).AddTicks(885));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 10, 11, 37, 6, 963, DateTimeKind.Local).AddTicks(888));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 10, 11, 37, 6, 963, DateTimeKind.Local).AddTicks(891));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 10, 11, 37, 6, 963, DateTimeKind.Local).AddTicks(893));
        }
    }
}
