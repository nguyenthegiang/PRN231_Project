using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class DB_7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1,
                columns: new[] { "Description", "Duration", "PublishedYear", "Rated" },
                values: new object[] { "Iron Man is a superhero appearing in American comic books published by Marvel Comics. The character was co-created by writer and editor Stan Lee, developed by scripter Larry Lieber, and designed by artists Don Heck and Jack Kirby. The character made his first appearance in Tales of Suspense #39 (cover dated March 1963), and received his own title in Iron Man #1 (May 1968). Also in 1963, the character founded the Avengers alongside Thor, Ant-Man, Wasp and the Hulk.", 126, 2008, 10 });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 2,
                columns: new[] { "Description", "Duration", "MovieName", "PublishedYear", "Rated" },
                values: new object[] { "Spider-Man: No Home is a 2021 American superhero film based on the Marvel Comics character Peter Parker, co-produced by Columbia Pictures and Marvel Studios and distributed by Sony Pictures Releasing", 148, "Spider Man: No way home", 2021, 13 });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 3,
                columns: new[] { "Description", "Duration", "PublishedYear", "Rated" },
                values: new object[] { "Ant-Man is a 2015 American superhero film based on the Marvel Comics characters of the same name: Scott Lang and Hank Pym. Produced by Marvel Studios and distributed by Walt Disney Studios Motion Pictures, it is the 12th installment in the Marvel Cinematic Universe film series.", 118, 2015, 9 });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 4,
                columns: new[] { "Description", "Duration", "PublishedYear" },
                values: new object[] { "Black Panther: Black Panther is an American film based on the Marvel Comics superhero character of the same name, produced by Marvel Studios and distributed by Walt Disney Studios Motion Pictures.", 135, 2018 });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 5,
                columns: new[] { "Description", "Duration", "PublishedYear", "Rated" },
                values: new object[] { "Black Widow is an American superhero film based on the Marvel Comics character of the same name, produced by Marvel Studios and distributed by Walt Disney Studios Motion Pictures. Black Widow is the 24th film in the Marvel Cinematic Universe.", 133, 2021, 15 });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 6,
                columns: new[] { "Description", "Duration", "PublishedYear", "Rated" },
                values: new object[] { "Captain America: The First Avenger is a 2011 American superhero film based on the Marvel Comics character Captain America. Produced by Marvel Studios and released by Paramount Pictures, it is the fifth film in the Marvel Cinematic Universe.", 124, 2011, 14 });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 7,
                columns: new[] { "Description", "Duration", "PublishedYear", "Rated" },
                values: new object[] { "Captain Marvel is a 2019 American superhero film based on the Marvel Comics character Carol Danvers. Produced by Marvel Studios and distributed by Walt Disney Studios Motion Pictures, the work is the 21st film in the Marvel Cinematic Universe.", 124, 2019, 14 });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 8,
                columns: new[] { "Description", "Duration", "MovieName", "PublishedYear", "Rated" },
                values: new object[] { "The Ultimate Wizard in the Chaos Multiverse is an American superhero film due out in 2022, based on the Marvel Comics character Doctor Strange.", 126, "Doctor Strange in the Multiverse of Madness", 2022, 16 });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 9,
                columns: new[] { "Description", "MovieName", "PublishedYear", "Rated" },
                values: new object[] { "Hulk (also known as The Hulk) is a 2003 American superhero film based on the Marvel Comics character of the same name, directed by Ang Lee and written by James Schamus, Michael France, and John Turman from a story by Schamus. It stars Eric Bana as Bruce Banner/Hulk, alongside Jennifer Connelly, Sam Elliott, Josh Lucas, and Nick Nolte. The film explores Bruce Banner's origins. After a lab accident involving gamma radiation, he transforms into a giant, green-skinned creature known as the Hulk whenever stressed or emotionally provoked. The United States military pursues him, and he clashes with his biological father, who has dark plans for his son.", "The Hulk", 2003, 15 });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 10,
                columns: new[] { "Description", "Duration", "MovieName", "PublishedYear", "Rated" },
                values: new object[] { "WandaVision is an American television miniseries written by Jac Schaeffer for the Disney+ streaming service, based on the Marvel Comics characters Wanda Maximoff / Scarlet Witch and Vision.", 129, "WandaVision", 2021, 18 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1,
                columns: new[] { "Description", "Duration", "PublishedYear", "Rated" },
                values: new object[] { "Very cool", 120, 2001, 12 });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 2,
                columns: new[] { "Description", "Duration", "MovieName", "PublishedYear", "Rated" },
                values: new object[] { "Very good", 120, "Spider Man", 2001, 12 });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 3,
                columns: new[] { "Description", "Duration", "PublishedYear", "Rated" },
                values: new object[] { "So cool", 120, 2001, 12 });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 4,
                columns: new[] { "Description", "Duration", "PublishedYear" },
                values: new object[] { "So cool", 120, 2001 });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 5,
                columns: new[] { "Description", "Duration", "PublishedYear", "Rated" },
                values: new object[] { "So cool", 120, 2001, 12 });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 6,
                columns: new[] { "Description", "Duration", "PublishedYear", "Rated" },
                values: new object[] { "So cool", 120, 2001, 12 });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 7,
                columns: new[] { "Description", "Duration", "PublishedYear", "Rated" },
                values: new object[] { "So cool", 120, 2001, 12 });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 8,
                columns: new[] { "Description", "Duration", "MovieName", "PublishedYear", "Rated" },
                values: new object[] { "So cool", 120, "Doctor Strange", 2001, 12 });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 9,
                columns: new[] { "Description", "MovieName", "PublishedYear", "Rated" },
                values: new object[] { "So cool", "Hulk", 2001, 12 });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 10,
                columns: new[] { "Description", "Duration", "MovieName", "PublishedYear", "Rated" },
                values: new object[] { "So cool", 120, "Scarlet Witch", 2001, 12 });
        }
    }
}
