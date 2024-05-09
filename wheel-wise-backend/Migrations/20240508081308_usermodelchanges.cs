using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wheel_wise.Migrations
{
    /// <inheritdoc />
    public partial class usermodelchanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 8, 10, 13, 7, 656, DateTimeKind.Local).AddTicks(7579));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 8, 10, 13, 7, 656, DateTimeKind.Local).AddTicks(7628));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 8, 10, 13, 7, 656, DateTimeKind.Local).AddTicks(7630));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 8, 10, 13, 7, 656, DateTimeKind.Local).AddTicks(7632));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2024, 5, 8, 10, 13, 7, 656, DateTimeKind.Local).AddTicks(7633), "falevél" });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 8, 10, 13, 7, 656, DateTimeKind.Local).AddTicks(7635));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 8, 10, 13, 7, 656, DateTimeKind.Local).AddTicks(7636));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 8, 10, 13, 7, 656, DateTimeKind.Local).AddTicks(7638));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 8, 10, 13, 7, 656, DateTimeKind.Local).AddTicks(7639));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 8, 10, 13, 7, 656, DateTimeKind.Local).AddTicks(7641));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 8, 10, 13, 7, 656, DateTimeKind.Local).AddTicks(7643));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 8, 10, 13, 7, 656, DateTimeKind.Local).AddTicks(7644));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 8, 10, 13, 7, 656, DateTimeKind.Local).AddTicks(7646));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 8, 10, 13, 7, 656, DateTimeKind.Local).AddTicks(7647));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 8, 10, 13, 7, 656, DateTimeKind.Local).AddTicks(7649));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 8, 10, 13, 7, 656, DateTimeKind.Local).AddTicks(7650));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 8, 10, 13, 7, 656, DateTimeKind.Local).AddTicks(7652));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 8, 10, 13, 7, 656, DateTimeKind.Local).AddTicks(7653));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 8, 10, 13, 7, 656, DateTimeKind.Local).AddTicks(7655));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 26, 10, 56, 14, 634, DateTimeKind.Local).AddTicks(5484));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 26, 10, 56, 14, 634, DateTimeKind.Local).AddTicks(5537));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 26, 10, 56, 14, 634, DateTimeKind.Local).AddTicks(5541));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 26, 10, 56, 14, 634, DateTimeKind.Local).AddTicks(5543));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2024, 4, 26, 10, 56, 14, 634, DateTimeKind.Local).AddTicks(5546), "description" });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 26, 10, 56, 14, 634, DateTimeKind.Local).AddTicks(5549));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 26, 10, 56, 14, 634, DateTimeKind.Local).AddTicks(5551));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 26, 10, 56, 14, 634, DateTimeKind.Local).AddTicks(5554));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 26, 10, 56, 14, 634, DateTimeKind.Local).AddTicks(5557));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 26, 10, 56, 14, 634, DateTimeKind.Local).AddTicks(5560));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 26, 10, 56, 14, 634, DateTimeKind.Local).AddTicks(5563));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 26, 10, 56, 14, 634, DateTimeKind.Local).AddTicks(5565));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 26, 10, 56, 14, 634, DateTimeKind.Local).AddTicks(5568));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 26, 10, 56, 14, 634, DateTimeKind.Local).AddTicks(5571));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 26, 10, 56, 14, 634, DateTimeKind.Local).AddTicks(5574));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 26, 10, 56, 14, 634, DateTimeKind.Local).AddTicks(5577));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 26, 10, 56, 14, 634, DateTimeKind.Local).AddTicks(5580));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 26, 10, 56, 14, 634, DateTimeKind.Local).AddTicks(5583));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 26, 10, 56, 14, 634, DateTimeKind.Local).AddTicks(5585));
        }
    }
}
