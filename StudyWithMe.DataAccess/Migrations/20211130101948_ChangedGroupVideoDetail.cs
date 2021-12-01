using Microsoft.EntityFrameworkCore.Migrations;

namespace StudyWithMe.DataAccess.Migrations
{
    public partial class ChangedGroupVideoDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BroadcastingId",
                table: "GroupVideoDetails");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserId",
                table: "GroupVideoDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "GroupVideoDetails");

            migrationBuilder.AddColumn<int>(
                name: "BroadcastingId",
                table: "GroupVideoDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
