using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsraaJournals.Data.Migrations
{
    public partial class addmunscrpta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Abstract",
                table: "Manuscript",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "JournalId",
                table: "Manuscript",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Keyword",
                table: "Manuscript",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfAuthor",
                table: "Manuscript",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfPage",
                table: "Manuscript",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "title",
                table: "Manuscript",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "RecarcheTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecarcheTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Manuscript_JournalId",
                table: "Manuscript",
                column: "JournalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Manuscript_Journals_JournalId",
                table: "Manuscript",
                column: "JournalId",
                principalTable: "Journals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Manuscript_Journals_JournalId",
                table: "Manuscript");

            migrationBuilder.DropTable(
                name: "RecarcheTypes");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Manuscript_JournalId",
                table: "Manuscript");

            migrationBuilder.DropColumn(
                name: "Abstract",
                table: "Manuscript");

            migrationBuilder.DropColumn(
                name: "JournalId",
                table: "Manuscript");

            migrationBuilder.DropColumn(
                name: "Keyword",
                table: "Manuscript");

            migrationBuilder.DropColumn(
                name: "NumberOfAuthor",
                table: "Manuscript");

            migrationBuilder.DropColumn(
                name: "NumberOfPage",
                table: "Manuscript");

            migrationBuilder.DropColumn(
                name: "title",
                table: "Manuscript");
        }
    }
}
