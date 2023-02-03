using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsraaJournals.Data.Migrations
{
    public partial class addManuscript : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manuscript",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    file = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manuscript", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manuscript_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Manuscript_ArticleId",
                table: "Manuscript",
                column: "ArticleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Manuscript");
        }
    }
}
