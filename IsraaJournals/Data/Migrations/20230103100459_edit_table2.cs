using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsraaJournals.Data.Migrations
{
    public partial class edit_table2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Volumes_VolumeId1",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_VolumeId1",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "VolumeId1",
                table: "Articles");

            migrationBuilder.AlterColumn<int>(
                name: "VolumeId",
                table: "Articles",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_VolumeId",
                table: "Articles",
                column: "VolumeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Volumes_VolumeId",
                table: "Articles",
                column: "VolumeId",
                principalTable: "Volumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Volumes_VolumeId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_VolumeId",
                table: "Articles");

            migrationBuilder.AlterColumn<string>(
                name: "VolumeId",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
