using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsraaJournals.Data.Migrations
{
    public partial class addinform : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrespoindingAuthor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Affillation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomePage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Linkprofile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Twitter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManuscriptId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Author_Manuscript_ManuscriptId",
                        column: x => x.ManuscriptId,
                        principalTable: "Manuscript",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExcludeReviwer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Affiliation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManuscriptId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcludeReviwer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExcludeReviwer_Manuscript_ManuscriptId",
                        column: x => x.ManuscriptId,
                        principalTable: "Manuscript",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SuggestReivewr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Affiliation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManuscriptId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuggestReivewr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuggestReivewr_Manuscript_ManuscriptId",
                        column: x => x.ManuscriptId,
                        principalTable: "Manuscript",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Author_ManuscriptId",
                table: "Author",
                column: "ManuscriptId");

            migrationBuilder.CreateIndex(
                name: "IX_ExcludeReviwer_ManuscriptId",
                table: "ExcludeReviwer",
                column: "ManuscriptId");

            migrationBuilder.CreateIndex(
                name: "IX_SuggestReivewr_ManuscriptId",
                table: "SuggestReivewr",
                column: "ManuscriptId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "ExcludeReviwer");

            migrationBuilder.DropTable(
                name: "SuggestReivewr");
        }
    }
}
