using Microsoft.EntityFrameworkCore.Migrations;

namespace studyWithMe.WebUI.Migrations
{
    public partial class AddedIsFirstLoginonUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFirstLogin",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFirstLogin",
                table: "AspNetUsers");
        }
    }
}
