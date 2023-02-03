using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsraaJournals.Data.Migrations
{
    public partial class edit_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Volumes_Articles_ArticleId",
                table: "Volumes");

            migrationBuilder.DropIndex(
                name: "IX_Volumes_ArticleId",
                table: "Volumes");

            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "Volumes");

            migrationBuilder.AddColumn<string>(
                name: "VolumeId",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "VolumeId1",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_VolumeId1",
                table: "Articles",
                column: "VolumeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Volumes_VolumeId1",
                table: "Articles",
                column: "VolumeId1",
                principalTable: "Volumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Volumes_VolumeId1",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_VolumeId1",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "VolumeId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "VolumeId1",
                table: "Articles");

            migrationBuilder.AddColumn<int>(
                name: "ArticleId",
                table: "Volumes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Volumes_ArticleId",
                table: "Volumes",
                column: "ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Volumes_Articles_ArticleId",
                table: "Volumes",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
