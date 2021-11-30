using Microsoft.EntityFrameworkCore.Migrations;

namespace StudyWithMe.DataAccess.Migrations
{
    public partial class AddedJoinURLAndHostURLOnGroupVideoDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HostUrl",
                table: "GroupVideoDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JoinUrl",
                table: "GroupVideoDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HostUrl",
                table: "GroupVideoDetails");

            migrationBuilder.DropColumn(
                name: "JoinUrl",
                table: "GroupVideoDetails");
        }
    }
}
