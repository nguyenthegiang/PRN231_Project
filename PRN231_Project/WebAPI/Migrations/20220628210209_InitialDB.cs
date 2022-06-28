using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rated = table.Column<int>(type: "int", nullable: false),
                    PublishedYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Country", "Description", "Duration", "Image", "MovieName", "Path", "PublishedYear", "Rated" },
                values: new object[] { 1, null, null, null, null, "Iron Man", null, null, 0 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Country", "Description", "Duration", "Image", "MovieName", "Path", "PublishedYear", "Rated" },
                values: new object[] { 2, null, null, null, null, "Spider Man", null, null, 0 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Country", "Description", "Duration", "Image", "MovieName", "Path", "PublishedYear", "Rated" },
                values: new object[] { 3, null, null, null, null, "Ant Man", null, null, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
