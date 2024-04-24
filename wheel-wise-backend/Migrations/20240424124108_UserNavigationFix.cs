using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wheel_wise.Migrations
{
    /// <inheritdoc />
    public partial class UserNavigationFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "FavouriteAd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AdvertisementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteAd", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavouriteAd_Advertisements_AdvertisementId",
                        column: x => x.AdvertisementId,
                        principalTable: "Advertisements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavouriteAd_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 14, 41, 8, 224, DateTimeKind.Local).AddTicks(9732));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 14, 41, 8, 224, DateTimeKind.Local).AddTicks(9785));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 14, 41, 8, 224, DateTimeKind.Local).AddTicks(9787));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 14, 41, 8, 224, DateTimeKind.Local).AddTicks(9789));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 14, 41, 8, 224, DateTimeKind.Local).AddTicks(9791));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 14, 41, 8, 224, DateTimeKind.Local).AddTicks(9793));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 14, 41, 8, 224, DateTimeKind.Local).AddTicks(9795));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 14, 41, 8, 224, DateTimeKind.Local).AddTicks(9796));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 14, 41, 8, 224, DateTimeKind.Local).AddTicks(9798));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 14, 41, 8, 224, DateTimeKind.Local).AddTicks(9800));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 14, 41, 8, 224, DateTimeKind.Local).AddTicks(9801));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 14, 41, 8, 224, DateTimeKind.Local).AddTicks(9803));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 14, 41, 8, 224, DateTimeKind.Local).AddTicks(9805));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 14, 41, 8, 224, DateTimeKind.Local).AddTicks(9807));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 14, 41, 8, 224, DateTimeKind.Local).AddTicks(9808));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 14, 41, 8, 224, DateTimeKind.Local).AddTicks(9810));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 14, 41, 8, 224, DateTimeKind.Local).AddTicks(9812));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 14, 41, 8, 224, DateTimeKind.Local).AddTicks(9813));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 24, 14, 41, 8, 224, DateTimeKind.Local).AddTicks(9815));

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteAd_AdvertisementId",
                table: "FavouriteAd",
                column: "AdvertisementId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteAd_UserId",
                table: "FavouriteAd",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavouriteAd");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

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
    }
}
