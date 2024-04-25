using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wheel_wise.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvertisementUser_Advertisements_AdvertisementsId",
                table: "AdvertisementUser");

            migrationBuilder.DropForeignKey(
                name: "FK_AdvertisementUser_Users_UserId",
                table: "AdvertisementUser");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AdvertisementUser",
                newName: "User1Id");

            migrationBuilder.RenameColumn(
                name: "AdvertisementsId",
                table: "AdvertisementUser",
                newName: "FavoriteAdvertisementsId");

            migrationBuilder.RenameIndex(
                name: "IX_AdvertisementUser_UserId",
                table: "AdvertisementUser",
                newName: "IX_AdvertisementUser_User1Id");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Advertisements",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 4, 25, 6, 11, 23, 416, DateTimeKind.Local).AddTicks(6632), null });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 4, 25, 6, 11, 23, 416, DateTimeKind.Local).AddTicks(6675), null });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 4, 25, 6, 11, 23, 416, DateTimeKind.Local).AddTicks(6678), null });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 4, 25, 6, 11, 23, 416, DateTimeKind.Local).AddTicks(6679), null });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 4, 25, 6, 11, 23, 416, DateTimeKind.Local).AddTicks(6681), null });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 4, 25, 6, 11, 23, 416, DateTimeKind.Local).AddTicks(6684), null });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 4, 25, 6, 11, 23, 416, DateTimeKind.Local).AddTicks(6686), null });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 4, 25, 6, 11, 23, 416, DateTimeKind.Local).AddTicks(6687), null });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 4, 25, 6, 11, 23, 416, DateTimeKind.Local).AddTicks(6689), null });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 4, 25, 6, 11, 23, 416, DateTimeKind.Local).AddTicks(6691), null });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 4, 25, 6, 11, 23, 416, DateTimeKind.Local).AddTicks(6692), null });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 4, 25, 6, 11, 23, 416, DateTimeKind.Local).AddTicks(6694), null });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 4, 25, 6, 11, 23, 416, DateTimeKind.Local).AddTicks(6696), null });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 4, 25, 6, 11, 23, 416, DateTimeKind.Local).AddTicks(6697), null });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 4, 25, 6, 11, 23, 416, DateTimeKind.Local).AddTicks(6699), null });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 4, 25, 6, 11, 23, 416, DateTimeKind.Local).AddTicks(6700), null });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 4, 25, 6, 11, 23, 416, DateTimeKind.Local).AddTicks(6702), null });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 4, 25, 6, 11, 23, 416, DateTimeKind.Local).AddTicks(6704), null });

            migrationBuilder.UpdateData(
                table: "Advertisements",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2024, 4, 25, 6, 11, 23, 416, DateTimeKind.Local).AddTicks(6705), null });

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_UserId",
                table: "Advertisements",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_Users_UserId",
                table: "Advertisements",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertisementUser_Advertisements_FavoriteAdvertisementsId",
                table: "AdvertisementUser",
                column: "FavoriteAdvertisementsId",
                principalTable: "Advertisements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertisementUser_Users_User1Id",
                table: "AdvertisementUser",
                column: "User1Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_Users_UserId",
                table: "Advertisements");

            migrationBuilder.DropForeignKey(
                name: "FK_AdvertisementUser_Advertisements_FavoriteAdvertisementsId",
                table: "AdvertisementUser");

            migrationBuilder.DropForeignKey(
                name: "FK_AdvertisementUser_Users_User1Id",
                table: "AdvertisementUser");

            migrationBuilder.DropIndex(
                name: "IX_Advertisements_UserId",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Advertisements");

            migrationBuilder.RenameColumn(
                name: "User1Id",
                table: "AdvertisementUser",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "FavoriteAdvertisementsId",
                table: "AdvertisementUser",
                newName: "AdvertisementsId");

            migrationBuilder.RenameIndex(
                name: "IX_AdvertisementUser_User1Id",
                table: "AdvertisementUser",
                newName: "IX_AdvertisementUser_UserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertisementUser_Advertisements_AdvertisementsId",
                table: "AdvertisementUser",
                column: "AdvertisementsId",
                principalTable: "Advertisements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertisementUser_Users_UserId",
                table: "AdvertisementUser",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
