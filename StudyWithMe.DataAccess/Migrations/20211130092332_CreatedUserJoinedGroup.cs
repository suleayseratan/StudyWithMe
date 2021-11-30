using Microsoft.EntityFrameworkCore.Migrations;

namespace StudyWithMe.DataAccess.Migrations
{
    public partial class CreatedUserJoinedGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersJoinedGroups",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GroupVideoDetailGroupVideoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersJoinedGroups", x => new { x.GroupId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UsersJoinedGroups_GroupVideoDetails_GroupVideoDetailGroupVideoId",
                        column: x => x.GroupVideoDetailGroupVideoId,
                        principalTable: "GroupVideoDetails",
                        principalColumn: "GroupVideoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersJoinedGroups_GroupVideoDetailGroupVideoId",
                table: "UsersJoinedGroups",
                column: "GroupVideoDetailGroupVideoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersJoinedGroups");
        }
    }
}
