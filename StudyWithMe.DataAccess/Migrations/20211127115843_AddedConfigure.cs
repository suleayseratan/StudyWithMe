using Microsoft.EntityFrameworkCore.Migrations;

namespace StudyWithMe.DataAccess.Migrations
{
    public partial class AddedConfigure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupVideoGenres_GroupVideoDetails_GroupVideoDetailGroupVideoId",
                table: "GroupVideoGenres");

            migrationBuilder.DropIndex(
                name: "IX_GroupVideoGenres_GroupVideoDetailGroupVideoId",
                table: "GroupVideoGenres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupVideoDetails",
                table: "GroupVideoDetails");

            migrationBuilder.DropColumn(
                name: "GroupVideoDetailGroupVideoId",
                table: "GroupVideoGenres");

            migrationBuilder.AddPrimaryKey(
                name: "GroupVideoId",
                table: "GroupVideoDetails",
                column: "GroupVideoId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupVideoGenres_GroupId",
                table: "GroupVideoGenres",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupVideoGenres_GroupVideoDetails_GroupId",
                table: "GroupVideoGenres",
                column: "GroupId",
                principalTable: "GroupVideoDetails",
                principalColumn: "GroupVideoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupVideoGenres_GroupVideoDetails_GroupId",
                table: "GroupVideoGenres");

            migrationBuilder.DropIndex(
                name: "IX_GroupVideoGenres_GroupId",
                table: "GroupVideoGenres");

            migrationBuilder.DropPrimaryKey(
                name: "GroupVideoId",
                table: "GroupVideoDetails");

            migrationBuilder.AddColumn<int>(
                name: "GroupVideoDetailGroupVideoId",
                table: "GroupVideoGenres",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupVideoDetails",
                table: "GroupVideoDetails",
                column: "GroupVideoId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupVideoGenres_GroupVideoDetailGroupVideoId",
                table: "GroupVideoGenres",
                column: "GroupVideoDetailGroupVideoId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupVideoGenres_GroupVideoDetails_GroupVideoDetailGroupVideoId",
                table: "GroupVideoGenres",
                column: "GroupVideoDetailGroupVideoId",
                principalTable: "GroupVideoDetails",
                principalColumn: "GroupVideoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
