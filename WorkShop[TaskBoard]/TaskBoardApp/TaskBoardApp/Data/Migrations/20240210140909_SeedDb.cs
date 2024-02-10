using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class SeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bd148ac8-b6a1-4705-9148-1e0cf3269df1", 0, "9a5dccfb-36d5-43f1-836e-d7e48854a96b", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAENmdfI+Z5EkepYgiLKTijrowF0NYOxMFMEZyWd281aKhhvgL3DCgHhZ1pUoI8o6IYQ==", null, false, "43dd06a5-9222-43a1-b388-6b3a96f1fe83", false, "test@softuni.bg" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "OpenBoard" },
                    { 2, "InProgressBoard" },
                    { 3, "DoneBoard" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 7, 25, 16, 9, 9, 303, DateTimeKind.Local).AddTicks(6318), "Implement better styling for all public pages ", "bd148ac8-b6a1-4705-9148-1e0cf3269df1", "Improve CSS style" },
                    { 2, 1, new DateTime(2023, 9, 10, 16, 9, 9, 303, DateTimeKind.Local).AddTicks(6367), "Create andorid client app for restfull api", "bd148ac8-b6a1-4705-9148-1e0cf3269df1", "Android Client App" },
                    { 3, 2, new DateTime(2024, 1, 10, 16, 9, 9, 303, DateTimeKind.Local).AddTicks(6376), "Create desktop client form app for TaskBoard Restful API", "bd148ac8-b6a1-4705-9148-1e0cf3269df1", "Desktop client app" },
                    { 4, 3, new DateTime(2023, 2, 10, 16, 9, 9, 303, DateTimeKind.Local).AddTicks(6385), "Implement [Create Task] page for adding a new tasks ", "bd148ac8-b6a1-4705-9148-1e0cf3269df1", "Create Task" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bd148ac8-b6a1-4705-9148-1e0cf3269df1");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
