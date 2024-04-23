using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wheel_wise.Migrations
{
    /// <inheritdoc />
    public partial class modifiedhighlighted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 13, 18, 58, 30, 704, DateTimeKind.Local).AddTicks(3390));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 13, 18, 58, 30, 704, DateTimeKind.Local).AddTicks(3432));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 13, 18, 58, 30, 704, DateTimeKind.Local).AddTicks(3434));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 13, 18, 58, 30, 704, DateTimeKind.Local).AddTicks(3436));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 13, 18, 58, 30, 704, DateTimeKind.Local).AddTicks(3438));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 13, 18, 58, 30, 704, DateTimeKind.Local).AddTicks(3440));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 13, 18, 58, 30, 704, DateTimeKind.Local).AddTicks(3441));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 13, 18, 58, 30, 704, DateTimeKind.Local).AddTicks(3443));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Highlighted" },
                values: new object[] { new DateTime(2024, 4, 13, 18, 58, 30, 704, DateTimeKind.Local).AddTicks(3445), true });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Highlighted" },
                values: new object[] { new DateTime(2024, 4, 13, 18, 58, 30, 704, DateTimeKind.Local).AddTicks(3446), true });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "Highlighted" },
                values: new object[] { new DateTime(2024, 4, 13, 18, 58, 30, 704, DateTimeKind.Local).AddTicks(3448), true });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "Highlighted" },
                values: new object[] { new DateTime(2024, 4, 13, 18, 58, 30, 704, DateTimeKind.Local).AddTicks(3450), true });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "Highlighted" },
                values: new object[] { new DateTime(2024, 4, 13, 18, 58, 30, 704, DateTimeKind.Local).AddTicks(3451), true });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "Highlighted" },
                values: new object[] { new DateTime(2024, 4, 13, 18, 58, 30, 704, DateTimeKind.Local).AddTicks(3453), true });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 13, 18, 58, 30, 704, DateTimeKind.Local).AddTicks(3455));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 13, 18, 58, 30, 704, DateTimeKind.Local).AddTicks(3457));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 13, 18, 58, 30, 704, DateTimeKind.Local).AddTicks(3459));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 13, 18, 58, 30, 704, DateTimeKind.Local).AddTicks(3460));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 13, 18, 58, 30, 704, DateTimeKind.Local).AddTicks(3462));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 11, 9, 40, 42, 562, DateTimeKind.Local).AddTicks(9014));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 11, 9, 40, 42, 562, DateTimeKind.Local).AddTicks(9071));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 11, 9, 40, 42, 562, DateTimeKind.Local).AddTicks(9073));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 11, 9, 40, 42, 562, DateTimeKind.Local).AddTicks(9075));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 11, 9, 40, 42, 562, DateTimeKind.Local).AddTicks(9077));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 11, 9, 40, 42, 562, DateTimeKind.Local).AddTicks(9079));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 11, 9, 40, 42, 562, DateTimeKind.Local).AddTicks(9081));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 11, 9, 40, 42, 562, DateTimeKind.Local).AddTicks(9082));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Highlighted" },
                values: new object[] { new DateTime(2024, 4, 11, 9, 40, 42, 562, DateTimeKind.Local).AddTicks(9084), false });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Highlighted" },
                values: new object[] { new DateTime(2024, 4, 11, 9, 40, 42, 562, DateTimeKind.Local).AddTicks(9086), false });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "Highlighted" },
                values: new object[] { new DateTime(2024, 4, 11, 9, 40, 42, 562, DateTimeKind.Local).AddTicks(9087), false });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "Highlighted" },
                values: new object[] { new DateTime(2024, 4, 11, 9, 40, 42, 562, DateTimeKind.Local).AddTicks(9089), false });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "Highlighted" },
                values: new object[] { new DateTime(2024, 4, 11, 9, 40, 42, 562, DateTimeKind.Local).AddTicks(9091), false });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "Highlighted" },
                values: new object[] { new DateTime(2024, 4, 11, 9, 40, 42, 562, DateTimeKind.Local).AddTicks(9092), false });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 11, 9, 40, 42, 562, DateTimeKind.Local).AddTicks(9094));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 11, 9, 40, 42, 562, DateTimeKind.Local).AddTicks(9096));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 11, 9, 40, 42, 562, DateTimeKind.Local).AddTicks(9097));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 11, 9, 40, 42, 562, DateTimeKind.Local).AddTicks(9099));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 11, 9, 40, 42, 562, DateTimeKind.Local).AddTicks(9101));
        }
    }
}
