using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftUniBazar.Data.Migrations
{
    public partial class EditedAdBuyer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdsBuyers_AspNetUsers_BuyerId1",
                table: "AdsBuyers");

            migrationBuilder.DropIndex(
                name: "IX_AdsBuyers_BuyerId1",
                table: "AdsBuyers");

            migrationBuilder.DropColumn(
                name: "BuyerId1",
                table: "AdsBuyers");

            migrationBuilder.AlterColumn<string>(
                name: "BuyerId",
                table: "AdsBuyers",
                type: "nvarchar(450)",
                nullable: false,
                comment: "Buyer identifier",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Buyer identifier");

            migrationBuilder.AddForeignKey(
                name: "FK_AdsBuyers_AspNetUsers_BuyerId",
                table: "AdsBuyers",
                column: "BuyerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdsBuyers_AspNetUsers_BuyerId",
                table: "AdsBuyers");

            migrationBuilder.AlterColumn<int>(
                name: "BuyerId",
                table: "AdsBuyers",
                type: "int",
                nullable: false,
                comment: "Buyer identifier",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "Buyer identifier");

            migrationBuilder.AddColumn<string>(
                name: "BuyerId1",
                table: "AdsBuyers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_AdsBuyers_BuyerId1",
                table: "AdsBuyers",
                column: "BuyerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AdsBuyers_AspNetUsers_BuyerId1",
                table: "AdsBuyers",
                column: "BuyerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
