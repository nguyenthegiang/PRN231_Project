using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class DB_14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ActorMovies",
                columns: new[] { "ConnectionId", "ActorId", "MovieId" },
                values: new object[,]
                {
                    { 5, 9, 1 },
                    { 15, 8, 7 },
                    { 13, 8, 6 },
                    { 12, 5, 6 },
                    { 11, 8, 5 },
                    { 1, 1, 1 },
                    { 2, 3, 1 },
                    { 3, 3, 1 },
                    { 4, 8, 1 },
                    { 19, 8, 9 },
                    { 6, 1, 2 },
                    { 8, 2, 3 },
                    { 9, 4, 4 },
                    { 10, 9, 5 }
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "ActorId", "ActorName" },
                values: new object[,]
                {
                    { 10, "Tom Holland" },
                    { 13, "Benedict Cumberbatch" },
                    { 12, "Elizabeth Olsen" },
                    { 11, "Brie Larson" },
                    { 14, "Mark Ruffalo" }
                });

            migrationBuilder.InsertData(
                table: "CategoryMovie",
                columns: new[] { "ConnectionId", "CategoryId", "MovieId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "ActorMovies",
                columns: new[] { "ConnectionId", "ActorId", "MovieId" },
                values: new object[,]
                {
                    { 7, 10, 2 },
                    { 14, 11, 7 },
                    { 16, 12, 8 },
                    { 20, 12, 10 },
                    { 17, 13, 8 },
                    { 18, 14, 9 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ActorMovies",
                keyColumn: "ConnectionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ActorMovies",
                keyColumn: "ConnectionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ActorMovies",
                keyColumn: "ConnectionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ActorMovies",
                keyColumn: "ConnectionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ActorMovies",
                keyColumn: "ConnectionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ActorMovies",
                keyColumn: "ConnectionId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ActorMovies",
                keyColumn: "ConnectionId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ActorMovies",
                keyColumn: "ConnectionId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ActorMovies",
                keyColumn: "ConnectionId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ActorMovies",
                keyColumn: "ConnectionId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ActorMovies",
                keyColumn: "ConnectionId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ActorMovies",
                keyColumn: "ConnectionId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ActorMovies",
                keyColumn: "ConnectionId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ActorMovies",
                keyColumn: "ConnectionId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ActorMovies",
                keyColumn: "ConnectionId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ActorMovies",
                keyColumn: "ConnectionId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ActorMovies",
                keyColumn: "ConnectionId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ActorMovies",
                keyColumn: "ConnectionId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ActorMovies",
                keyColumn: "ConnectionId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ActorMovies",
                keyColumn: "ConnectionId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "CategoryMovie",
                keyColumn: "ConnectionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "ActorId",
                keyValue: 14);
        }
    }
}
