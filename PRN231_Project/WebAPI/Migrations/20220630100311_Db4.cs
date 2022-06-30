using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class Db4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 11);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Country", "Description", "Duration", "ImagePath", "MovieName", "PublishedYear", "Rated", "VideoPath" },
                values: new object[] { 11, "America", "So cool", 120, "Image/ScarletWitch.jpg", "Thong dz va nhung nguoi ban", 2001, 12, "Video/ScarletWitch.mp4" });
        }
    }
}
