using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wheel_wise.Migrations
{
    /// <inheritdoc />
    public partial class UserNavigationFix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavouriteAd");

            migrationBuilder.CreateTable(
                name: "AdvertisementUser",
                columns: table => new
                {
                    FavoriteAdvertisementsId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertisementUser", x => new { x.FavoriteAdvertisementsId, x.UserId });
                    table.ForeignKey(
                        name: "FK_AdvertisementUser_Advertisements_FavoriteAdvertisementsId",
                        column: x => x.FavoriteAdvertisementsId,
                        principalTable: "Advertisements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdvertisementUser_Users_UserId",
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
                value: new DateTime(2024, 4, 25, 9, 16, 1, 668, DateTimeKind.Local).AddTicks(6793));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 25, 9, 16, 1, 668, DateTimeKind.Local).AddTicks(6835));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 25, 9, 16, 1, 668, DateTimeKind.Local).AddTicks(6837));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 25, 9, 16, 1, 668, DateTimeKind.Local).AddTicks(6839));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 25, 9, 16, 1, 668, DateTimeKind.Local).AddTicks(6841));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 25, 9, 16, 1, 668, DateTimeKind.Local).AddTicks(6842));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 25, 9, 16, 1, 668, DateTimeKind.Local).AddTicks(6844));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 25, 9, 16, 1, 668, DateTimeKind.Local).AddTicks(6845));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 25, 9, 16, 1, 668, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 25, 9, 16, 1, 668, DateTimeKind.Local).AddTicks(6849));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 25, 9, 16, 1, 668, DateTimeKind.Local).AddTicks(6851));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 25, 9, 16, 1, 668, DateTimeKind.Local).AddTicks(6852));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 25, 9, 16, 1, 668, DateTimeKind.Local).AddTicks(6854));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 25, 9, 16, 1, 668, DateTimeKind.Local).AddTicks(6856));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 25, 9, 16, 1, 668, DateTimeKind.Local).AddTicks(6857));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 25, 9, 16, 1, 668, DateTimeKind.Local).AddTicks(6858));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 25, 9, 16, 1, 668, DateTimeKind.Local).AddTicks(6860));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 25, 9, 16, 1, 668, DateTimeKind.Local).AddTicks(6861));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 25, 9, 16, 1, 668, DateTimeKind.Local).AddTicks(6863));

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisementUser_UserId",
                table: "AdvertisementUser",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvertisementUser");

            migrationBuilder.CreateTable(
                name: "FavouriteAd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvertisementId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
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
    }
}
