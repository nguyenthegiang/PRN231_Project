using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class DB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Country", "Description", "Duration", "ImagePath", "MovieName", "PublishedYear", "Rated", "VideoPath" },
                values: new object[,]
                {
                    { 4, "America", "So cool", 120, "Image/BlackPanther.jpg", "Black Panther", 2001, 12, "Video/BlackPanther.mp4" },
                    { 5, "America", "So cool", 120, "Image/BlackWidow.jpg", "Black Widow", 2001, 12, "Video/BlackWidow.mp4" },
                    { 6, "America", "So cool", 120, "Image/CaptainAmerica.jpg", "Captain America", 2001, 12, "Video/CaptainAmerica.mp4" },
                    { 7, "America", "So cool", 120, "Image/CaptainMarvel.jpg", "Captain Marvel", 2001, 12, "Video/CaptainMarvel.mp4" },
                    { 8, "America", "So cool", 120, "Image/DoctorStrange.jpg", "Doctor Strange", 2001, 12, "Video/DoctorStrange.mp4" },
                    { 9, "America", "So cool", 120, "Image/Hulk.jpg", "Hulk", 2001, 12, "Video/Hulk.mp4" },
                    { 10, "America", "So cool", 120, "Image/ScarletWitch.jpg", "Scarlet Witch", 2001, 12, "Video/ScarletWitch.mp4" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 10);
        }
    }
}
