using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class DB_16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CategoryMovie",
                columns: new[] { "ConnectionId", "CategoryId", "MovieId" },
                values: new object[,]
                {
                    { 3, 3, 1 },
                    { 24, 2, 6 },
                    { 25, 3, 6 },
                    { 26, 8, 6 },
                    { 27, 1, 7 },
                    { 28, 2, 7 },
                    { 29, 3, 7 },
                    { 30, 4, 7 },
                    { 23, 1, 6 },
                    { 31, 1, 8 },
                    { 33, 3, 8 },
                    { 34, 8, 8 },
                    { 35, 9, 8 },
                    { 36, 1, 9 },
                    { 37, 6, 9 },
                    { 38, 4, 9 },
                    { 39, 1, 10 },
                    { 32, 2, 8 },
                    { 40, 2, 10 },
                    { 22, 8, 5 },
                    { 20, 3, 5 },
                    { 4, 9, 1 },
                    { 5, 1, 2 },
                    { 6, 2, 2 },
                    { 7, 3, 2 },
                    { 8, 6, 2 },
                    { 9, 7, 2 },
                    { 10, 1, 3 },
                    { 21, 6, 5 },
                    { 11, 2, 3 },
                    { 13, 7, 3 },
                    { 14, 1, 4 },
                    { 15, 2, 4 },
                    { 16, 3, 4 },
                    { 17, 8, 4 },
                    { 18, 1, 5 },
                    { 19, 2, 5 },
                    { 12, 3, 3 },
                    { 41, 3, 10 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoryMovie",
                keyColumn: "ConnectionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CategoryMovie",
                keyColumn: "ConnectionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CategoryMovie",
                keyColumn: "ConnectionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CategoryMovie",
                keyColumn: "ConnectionId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CategoryMovie",
                keyColumn: "ConnectionId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CategoryMovie",
                keyColumn: "ConnectionId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CategoryMovie",
                keyColumn: "ConnectionId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CategoryMovie",
                keyColumn: "ConnectionId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CategoryMovie",
                keyColumn: "ConnectionId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CategoryMovie",
                keyColumn: "ConnectionId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CategoryMovie",
                keyColumn: "ConnectionId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "CategoryMovie",
                keyColumn: "ConnectionId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "CategoryMovie",
                keyColumn: "ConnectionId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "CategoryMovie",
                keyColumn: "ConnectionId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "CategoryMovie",
                keyColumn: "ConnectionId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "CategoryMovie",
                keyColumn: "ConnectionId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "CategoryMovie",
                keyColumn: "ConnectionId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "CategoryMovie",
                keyColumn: "ConnectionId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "CategoryMovie",
                keyColumn: "ConnectionId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "CategoryMovie",
                keyColumn: "ConnectionId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "CategoryMovie",
                keyColumn: "ConnectionId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "CategoryMovie",
                keyColumn: "ConnectionId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "CategoryMovie",
                keyColumn: "ConnectionId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "CategoryMovie",
                keyColumn: "ConnectionId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "CategoryMovie",
                keyColumn: "ConnectionId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "CategoryMovie",
                keyColumn: "ConnectionId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "CategoryMovie",
                keyColumn: "ConnectionId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "CategoryMovie",
                keyColumn: "ConnectionId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "CategoryMovie",
                keyColumn: "ConnectionId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "CategoryMovie",
                keyColumn: "ConnectionId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "CategoryMovie",
                keyColumn: "ConnectionId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "CategoryMovie",
                keyColumn: "ConnectionId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "CategoryMovie",
                keyColumn: "ConnectionId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "CategoryMovie",
                keyColumn: "ConnectionId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "CategoryMovie",
                keyColumn: "ConnectionId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "CategoryMovie",
                keyColumn: "ConnectionId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "CategoryMovie",
                keyColumn: "ConnectionId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "CategoryMovie",
                keyColumn: "ConnectionId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "CategoryMovie",
                keyColumn: "ConnectionId",
                keyValue: 41);
        }
    }
}
