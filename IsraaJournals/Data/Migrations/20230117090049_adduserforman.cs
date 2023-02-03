using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsraaJournals.Data.Migrations
{
    public partial class adduserforman : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AutherId",
                table: "Manuscript",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Manuscript_AutherId",
                table: "Manuscript",
                column: "AutherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Manuscript_AspNetUsers_AutherId",
                table: "Manuscript",
                column: "AutherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Manuscript_AspNetUsers_AutherId",
                table: "Manuscript");

            migrationBuilder.DropIndex(
                name: "IX_Manuscript_AutherId",
                table: "Manuscript");

            migrationBuilder.DropColumn(
                name: "AutherId",
                table: "Manuscript");
        }
    }
}
