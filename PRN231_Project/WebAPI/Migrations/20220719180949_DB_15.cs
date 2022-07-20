using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class DB_15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CategoryMovie",
                columns: new[] { "ConnectionId", "CategoryId", "MovieId" },
                values: new object[] { 2, 2, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoryMovie",
                keyColumn: "ConnectionId",
                keyValue: 2);
        }
    }
}
