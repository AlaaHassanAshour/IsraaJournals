using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsraaJournals.Data.Migrations
{
    public partial class addres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecarcheTypeId",
                table: "Manuscript",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "Manuscript",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Manuscript_RecarcheTypeId",
                table: "Manuscript",
                column: "RecarcheTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Manuscript_SectionId",
                table: "Manuscript",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Manuscript_RecarcheTypes_RecarcheTypeId",
                table: "Manuscript",
                column: "RecarcheTypeId",
                principalTable: "RecarcheTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Manuscript_Sections_SectionId",
                table: "Manuscript",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Manuscript_RecarcheTypes_RecarcheTypeId",
                table: "Manuscript");

            migrationBuilder.DropForeignKey(
                name: "FK_Manuscript_Sections_SectionId",
                table: "Manuscript");

            migrationBuilder.DropIndex(
                name: "IX_Manuscript_RecarcheTypeId",
                table: "Manuscript");

            migrationBuilder.DropIndex(
                name: "IX_Manuscript_SectionId",
                table: "Manuscript");

            migrationBuilder.DropColumn(
                name: "RecarcheTypeId",
                table: "Manuscript");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "Manuscript");
        }
    }
}
