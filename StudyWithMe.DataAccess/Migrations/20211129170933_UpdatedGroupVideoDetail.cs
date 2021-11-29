using Microsoft.EntityFrameworkCore.Migrations;

namespace StudyWithMe.DataAccess.Migrations
{
    public partial class UpdatedGroupVideoDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GroupVideoName",
                table: "GroupVideoDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JoinedUserCount",
                table: "GroupVideoDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte>(
                name: "VideoImage",
                table: "GroupVideoDetails",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupVideoName",
                table: "GroupVideoDetails");

            migrationBuilder.DropColumn(
                name: "JoinedUserCount",
                table: "GroupVideoDetails");

            migrationBuilder.DropColumn(
                name: "VideoImage",
                table: "GroupVideoDetails");
        }
    }
}
