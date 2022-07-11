using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class DB_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Actor",
                columns: new[] { "ActorId", "ActorName" },
                values: new object[,]
                {
                    { 1, "Robert Downey Jr" },
                    { 2, "Paul Rudd" },
                    { 3, "Scarlett Johansson" },
                    { 4, "Chadwick Boseman" },
                    { 5, "Chris Evans" },
                    { 6, "Anthony Mackie" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "CategoryName",
                value: "Action & Adventure");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 3, "Sci-Fi & Fantasy" },
                    { 4, "Comedy" },
                    { 5, "20th Century Fox" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Email",
                value: "admin@gmail.com");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "Email", "Password", "Username" },
                values: new object[] { "buingochuyen17462@gmail.com", "00ab9b0c4e58c5e0b039cc4f5213bfd41c2d4e00211b618bae67cc33a32e73d0", "Huyen" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "Email", "Password", "Username" },
                values: new object[] { "nguyenthe.giang.775@gmail.com", "054f29cb6d48ccea661d6108fdcdd0a2f1d40b0141ba25fc9c684a1da873499b", "Giang" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Password", "RoleId", "Username" },
                values: new object[] { 4, "thong21145@gmail.com", "7710e1b184cbc633d23324649f6f50c0650df3d2bbf939ed9e60763bd9610921", 1, "Thong" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "ActorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "ActorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "ActorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "ActorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "ActorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "ActorId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "CategoryName",
                value: "DC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Email",
                value: "adminse1501@gmail.com");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "Email", "Password", "Username" },
                values: new object[] { "a@gmail.com", "9834876dcfb05cb167a5c24953eba58c4ac89b1adf57f28f2f9d09af107ee8f0", "a" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "Email", "Password", "Username" },
                values: new object[] { "b@gmail.com", "3e744b9dc39389baf0c5a0660589b8402f3dbb49b89b3e75f2c9355852a3c677", "b" });
        }
    }
}
