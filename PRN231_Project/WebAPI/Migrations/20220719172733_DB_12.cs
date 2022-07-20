using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class DB_12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovies_Categories_CategoryId",
                table: "ActorMovies");

            migrationBuilder.DropIndex(
                name: "IX_ActorMovies_CategoryId",
                table: "ActorMovies");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ActorMovies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ActorMovies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActorMovies_CategoryId",
                table: "ActorMovies",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovies_Categories_CategoryId",
                table: "ActorMovies",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
