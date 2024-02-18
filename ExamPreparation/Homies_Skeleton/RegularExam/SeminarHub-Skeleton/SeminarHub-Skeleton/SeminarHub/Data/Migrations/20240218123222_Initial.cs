using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeminarHub.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Category identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Category Name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                },
                comment: "Category data entity");

            migrationBuilder.CreateTable(
                name: "Seminar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Seminar identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Topic = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Seminar Topic"),
                    Lecturer = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "Seminar Lecturer"),
                    Details = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Seminar Details"),
                    OrganizerId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Seminar Organiser identifier"),
                    DateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Seminar Date and Time"),
                    Duration = table.Column<int>(type: "int", nullable: false, comment: "Seminar duration"),
                    CategoryId = table.Column<int>(type: "int", nullable: false, comment: "Seminar category identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seminar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seminar_AspNetUsers_OrganizerId",
                        column: x => x.OrganizerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seminar_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Seminar data entity");

            migrationBuilder.CreateTable(
                name: "SeminarParticipant",
                columns: table => new
                {
                    SeminarId = table.Column<int>(type: "int", nullable: false, comment: "Seminar identifier"),
                    ParticipantId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Participant identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeminarParticipant", x => new { x.SeminarId, x.ParticipantId });
                    table.ForeignKey(
                        name: "FK_SeminarParticipant_AspNetUsers_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeminarParticipant_Seminar_SeminarId",
                        column: x => x.SeminarId,
                        principalTable: "Seminar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Seminar Participant data entity ");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Technology & Innovation" },
                    { 2, "Business & Entrepreneurship" },
                    { 3, "Science & Research" },
                    { 4, "Arts & Culture" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seminar_CategoryId",
                table: "Seminar",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Seminar_OrganizerId",
                table: "Seminar",
                column: "OrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_SeminarParticipant_ParticipantId",
                table: "SeminarParticipant",
                column: "ParticipantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeminarParticipant");

            migrationBuilder.DropTable(
                name: "Seminar");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
