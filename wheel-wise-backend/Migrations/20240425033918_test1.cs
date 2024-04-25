using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wheel_wise.Migrations
{
    /// <inheritdoc />
    public partial class test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_Users_UserId",
                table: "Advertisements");

            migrationBuilder.DropTable(
                name: "FavouriteAd");

            migrationBuilder.DropIndex(
                name: "IX_Advertisements_UserId",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Advertisements");

            migrationBuilder.CreateTable(
                name: "AdvertisementUser",
                columns: table => new
                {
                    AdvertisementsId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertisementUser", x => new { x.AdvertisementsId, x.UserId });
                    table.ForeignKey(
                        name: "FK_AdvertisementUser_Advertisements_AdvertisementsId",
                        column: x => x.AdvertisementsId,
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
                value: new DateTime(2024, 4, 25, 5, 39, 17, 206, DateTimeKind.Local).AddTicks(7158));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 25, 5, 39, 17, 206, DateTimeKind.Local).AddTicks(7204));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 25, 5, 39, 17, 206, DateTimeKind.Local).AddTicks(7210));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 25, 5, 39, 17, 206, DateTimeKind.Local).AddTicks(7213));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 25, 5, 39, 17, 206, DateTimeKind.Local).AddTicks(7215));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 25, 5, 39, 17, 206, DateTimeKind.Local).AddTicks(7218));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 25, 5, 39, 17, 206, DateTimeKind.Local).AddTicks(7221));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 25, 5, 39, 17, 206, DateTimeKind.Local).AddTicks(7223));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 25, 5, 39, 17, 206, DateTimeKind.Local).AddTicks(7225));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 25, 5, 39, 17, 206, DateTimeKind.Local).AddTicks(7227));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 25, 5, 39, 17, 206, DateTimeKind.Local).AddTicks(7229));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 25, 5, 39, 17, 206, DateTimeKind.Local).AddTicks(7231));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 25, 5, 39, 17, 206, DateTimeKind.Local).AddTicks(7233));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 25, 5, 39, 17, 206, DateTimeKind.Local).AddTicks(7237));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 25, 5, 39, 17, 206, DateTimeKind.Local).AddTicks(7239));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 25, 5, 39, 17, 206, DateTimeKind.Local).AddTicks(7241));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 25, 5, 39, 17, 206, DateTimeKind.Local).AddTicks(7243));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 25, 5, 39, 17, 206, DateTimeKind.Local).AddTicks(7245));

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2024, 4, 25, 5, 39, 17, 206, DateTimeKind.Local).AddTicks(7248));

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

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Advertisements",
                type: "int",
                nullable: true);

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
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 41, 8, 224, DateTimeKind.Local).AddTicks(9732), null });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 41, 8, 224, DateTimeKind.Local).AddTicks(9785), null });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 41, 8, 224, DateTimeKind.Local).AddTicks(9787), null });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 41, 8, 224, DateTimeKind.Local).AddTicks(9789), null });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 41, 8, 224, DateTimeKind.Local).AddTicks(9791), null });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 41, 8, 224, DateTimeKind.Local).AddTicks(9793), null });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 41, 8, 224, DateTimeKind.Local).AddTicks(9795), null });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 41, 8, 224, DateTimeKind.Local).AddTicks(9796), null });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 41, 8, 224, DateTimeKind.Local).AddTicks(9798), null });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 41, 8, 224, DateTimeKind.Local).AddTicks(9800), null });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 41, 8, 224, DateTimeKind.Local).AddTicks(9801), null });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 41, 8, 224, DateTimeKind.Local).AddTicks(9803), null });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 41, 8, 224, DateTimeKind.Local).AddTicks(9805), null });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 41, 8, 224, DateTimeKind.Local).AddTicks(9807), null });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 41, 8, 224, DateTimeKind.Local).AddTicks(9808), null });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 41, 8, 224, DateTimeKind.Local).AddTicks(9810), null });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 41, 8, 224, DateTimeKind.Local).AddTicks(9812), null });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 41, 8, 224, DateTimeKind.Local).AddTicks(9813), null });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 4, 24, 14, 41, 8, 224, DateTimeKind.Local).AddTicks(9815), null });

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_UserId",
                table: "Advertisements",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteAd_AdvertisementId",
                table: "FavouriteAd",
                column: "AdvertisementId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteAd_UserId",
                table: "FavouriteAd",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_Users_UserId",
                table: "Advertisements",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
