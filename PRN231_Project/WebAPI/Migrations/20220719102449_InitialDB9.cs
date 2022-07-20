using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class InitialDB9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Actor_ActorsActorId",
                table: "ActorMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Actor",
                table: "Actor");

            migrationBuilder.RenameTable(
                name: "Actor",
                newName: "Actors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Actors",
                table: "Actors",
                column: "ActorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Actors_ActorsActorId",
                table: "ActorMovie",
                column: "ActorsActorId",
                principalTable: "Actors",
                principalColumn: "ActorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Actors_ActorsActorId",
                table: "ActorMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Actors",
                table: "Actors");

            migrationBuilder.RenameTable(
                name: "Actors",
                newName: "Actor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Actor",
                table: "Actor",
                column: "ActorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Actor_ActorsActorId",
                table: "ActorMovie",
                column: "ActorsActorId",
                principalTable: "Actor",
                principalColumn: "ActorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
