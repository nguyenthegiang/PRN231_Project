using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class DB_11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryMovie_Categories_CategoriesCategoryId",
                table: "CategoryMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryMovie_Movies_MoviesMovieId",
                table: "CategoryMovie");

            migrationBuilder.DropTable(
                name: "ActorMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryMovie",
                table: "CategoryMovie");

            migrationBuilder.RenameColumn(
                name: "MoviesMovieId",
                table: "CategoryMovie",
                newName: "MovieId");

            migrationBuilder.RenameColumn(
                name: "CategoriesCategoryId",
                table: "CategoryMovie",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryMovie_MoviesMovieId",
                table: "CategoryMovie",
                newName: "IX_CategoryMovie_MovieId");

            migrationBuilder.AddColumn<int>(
                name: "ConnectionId",
                table: "CategoryMovie",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryMovie",
                table: "CategoryMovie",
                column: "ConnectionId");

            migrationBuilder.CreateTable(
                name: "ActorMovies",
                columns: table => new
                {
                    ConnectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActorId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorMovies", x => x.ConnectionId);
                    table.ForeignKey(
                        name: "FK_ActorMovies_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "ActorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorMovies_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActorMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryMovie_CategoryId",
                table: "CategoryMovie",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorMovies_ActorId",
                table: "ActorMovies",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorMovies_CategoryId",
                table: "ActorMovies",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorMovies_MovieId",
                table: "ActorMovies",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryMovie_Categories_CategoryId",
                table: "CategoryMovie",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryMovie_Movies_MovieId",
                table: "CategoryMovie",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryMovie_Categories_CategoryId",
                table: "CategoryMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryMovie_Movies_MovieId",
                table: "CategoryMovie");

            migrationBuilder.DropTable(
                name: "ActorMovies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryMovie",
                table: "CategoryMovie");

            migrationBuilder.DropIndex(
                name: "IX_CategoryMovie_CategoryId",
                table: "CategoryMovie");

            migrationBuilder.DropColumn(
                name: "ConnectionId",
                table: "CategoryMovie");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "CategoryMovie",
                newName: "MoviesMovieId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "CategoryMovie",
                newName: "CategoriesCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryMovie_MovieId",
                table: "CategoryMovie",
                newName: "IX_CategoryMovie_MoviesMovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryMovie",
                table: "CategoryMovie",
                columns: new[] { "CategoriesCategoryId", "MoviesMovieId" });

            migrationBuilder.CreateTable(
                name: "ActorMovie",
                columns: table => new
                {
                    ActorsActorId = table.Column<int>(type: "int", nullable: false),
                    MoviesMovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorMovie", x => new { x.ActorsActorId, x.MoviesMovieId });
                    table.ForeignKey(
                        name: "FK_ActorMovie_Actors_ActorsActorId",
                        column: x => x.ActorsActorId,
                        principalTable: "Actors",
                        principalColumn: "ActorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorMovie_Movies_MoviesMovieId",
                        column: x => x.MoviesMovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorMovie_MoviesMovieId",
                table: "ActorMovie",
                column: "MoviesMovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryMovie_Categories_CategoriesCategoryId",
                table: "CategoryMovie",
                column: "CategoriesCategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryMovie_Movies_MoviesMovieId",
                table: "CategoryMovie",
                column: "MoviesMovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
