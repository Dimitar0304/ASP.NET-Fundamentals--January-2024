using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeminarHub.Data.Migrations
{
    public partial class AddingDbSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seminar_AspNetUsers_OrganizerId",
                table: "Seminar");

            migrationBuilder.DropForeignKey(
                name: "FK_Seminar_Category_CategoryId",
                table: "Seminar");

            migrationBuilder.DropForeignKey(
                name: "FK_SeminarParticipant_AspNetUsers_ParticipantId",
                table: "SeminarParticipant");

            migrationBuilder.DropForeignKey(
                name: "FK_SeminarParticipant_Seminar_SeminarId",
                table: "SeminarParticipant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SeminarParticipant",
                table: "SeminarParticipant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seminar",
                table: "Seminar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "SeminarParticipant",
                newName: "SeminarsParticipants");

            migrationBuilder.RenameTable(
                name: "Seminar",
                newName: "Seminars");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_SeminarParticipant_ParticipantId",
                table: "SeminarsParticipants",
                newName: "IX_SeminarsParticipants_ParticipantId");

            migrationBuilder.RenameIndex(
                name: "IX_Seminar_OrganizerId",
                table: "Seminars",
                newName: "IX_Seminars_OrganizerId");

            migrationBuilder.RenameIndex(
                name: "IX_Seminar_CategoryId",
                table: "Seminars",
                newName: "IX_Seminars_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeminarsParticipants",
                table: "SeminarsParticipants",
                columns: new[] { "SeminarId", "ParticipantId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seminars",
                table: "Seminars",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Seminars_AspNetUsers_OrganizerId",
                table: "Seminars",
                column: "OrganizerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seminars_Categories_CategoryId",
                table: "Seminars",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeminarsParticipants_AspNetUsers_ParticipantId",
                table: "SeminarsParticipants",
                column: "ParticipantId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeminarsParticipants_Seminars_SeminarId",
                table: "SeminarsParticipants",
                column: "SeminarId",
                principalTable: "Seminars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seminars_AspNetUsers_OrganizerId",
                table: "Seminars");

            migrationBuilder.DropForeignKey(
                name: "FK_Seminars_Categories_CategoryId",
                table: "Seminars");

            migrationBuilder.DropForeignKey(
                name: "FK_SeminarsParticipants_AspNetUsers_ParticipantId",
                table: "SeminarsParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_SeminarsParticipants_Seminars_SeminarId",
                table: "SeminarsParticipants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SeminarsParticipants",
                table: "SeminarsParticipants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seminars",
                table: "Seminars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "SeminarsParticipants",
                newName: "SeminarParticipant");

            migrationBuilder.RenameTable(
                name: "Seminars",
                newName: "Seminar");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_SeminarsParticipants_ParticipantId",
                table: "SeminarParticipant",
                newName: "IX_SeminarParticipant_ParticipantId");

            migrationBuilder.RenameIndex(
                name: "IX_Seminars_OrganizerId",
                table: "Seminar",
                newName: "IX_Seminar_OrganizerId");

            migrationBuilder.RenameIndex(
                name: "IX_Seminars_CategoryId",
                table: "Seminar",
                newName: "IX_Seminar_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeminarParticipant",
                table: "SeminarParticipant",
                columns: new[] { "SeminarId", "ParticipantId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seminar",
                table: "Seminar",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Seminar_AspNetUsers_OrganizerId",
                table: "Seminar",
                column: "OrganizerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seminar_Category_CategoryId",
                table: "Seminar",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeminarParticipant_AspNetUsers_ParticipantId",
                table: "SeminarParticipant",
                column: "ParticipantId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeminarParticipant_Seminar_SeminarId",
                table: "SeminarParticipant",
                column: "SeminarId",
                principalTable: "Seminar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
