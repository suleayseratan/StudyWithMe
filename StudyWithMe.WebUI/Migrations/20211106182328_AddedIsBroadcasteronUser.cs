using Microsoft.EntityFrameworkCore.Migrations;

namespace studyWithMe.WebUI.Migrations
{
    public partial class AddedIsBroadcasteronUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBroadcaster",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBroadcaster",
                table: "AspNetUsers");
        }
    }
}
