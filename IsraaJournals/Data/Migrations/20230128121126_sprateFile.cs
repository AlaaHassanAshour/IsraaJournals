using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsraaJournals.Data.Migrations
{
    public partial class sprateFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "file",
                table: "Manuscript");

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    file = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManuscriptId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_Manuscript_ManuscriptId",
                        column: x => x.ManuscriptId,
                        principalTable: "Manuscript",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_File_ManuscriptId",
                table: "File",
                column: "ManuscriptId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.AddColumn<string>(
                name: "file",
                table: "Manuscript",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
