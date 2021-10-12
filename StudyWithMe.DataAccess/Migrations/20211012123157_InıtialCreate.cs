using Microsoft.EntityFrameworkCore.Migrations;

namespace StudyWithMe.DataAccess.Migrations
{
    public partial class InıtialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Followers",
                columns: table => new
                {
                    FollowingId = table.Column<int>(type: "int", nullable: false),
                    FollowedId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Followers", x => new { x.FollowedId, x.FollowingId });
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "GroupVideoDetails",
                columns: table => new
                {
                    GroupVideoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BroadcastingId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxUsersCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupVideoDetails", x => x.GroupVideoId);
                });

            migrationBuilder.CreateTable(
                name: "StudyVideos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BroadcastingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyVideos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupVideoGenres",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    GroupVideoDetailGroupVideoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupVideoGenres", x => new { x.GenreId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_GroupVideoGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupVideoGenres_GroupVideoDetails_GroupVideoDetailGroupVideoId",
                        column: x => x.GroupVideoDetailGroupVideoId,
                        principalTable: "GroupVideoDetails",
                        principalColumn: "GroupVideoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VideoLikedUsers",
                columns: table => new
                {
                    VideoId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    StudyVideoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoLikedUsers", x => new { x.VideoId, x.UserId });
                    table.ForeignKey(
                        name: "FK_VideoLikedUsers_StudyVideos_StudyVideoId",
                        column: x => x.StudyVideoId,
                        principalTable: "StudyVideos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupVideoGenres_GroupVideoDetailGroupVideoId",
                table: "GroupVideoGenres",
                column: "GroupVideoDetailGroupVideoId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoLikedUsers_StudyVideoId",
                table: "VideoLikedUsers",
                column: "StudyVideoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Followers");

            migrationBuilder.DropTable(
                name: "GroupVideoGenres");

            migrationBuilder.DropTable(
                name: "VideoLikedUsers");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "GroupVideoDetails");

            migrationBuilder.DropTable(
                name: "StudyVideos");
        }
    }
}
