using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class FacebookUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FacebookUID",
                table: "Users",
                type: "nvarchar(64)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFacebookUser",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacebookUID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsFacebookUser",
                table: "Users");
        }
    }
}
