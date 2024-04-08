using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wheel_wise.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 8, 13, 47, 47, 713, DateTimeKind.Local).AddTicks(2657));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 8, 13, 36, 5, 117, DateTimeKind.Local).AddTicks(7800));
        }
    }
}
