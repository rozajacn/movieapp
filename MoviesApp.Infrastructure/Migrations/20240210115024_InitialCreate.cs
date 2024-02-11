using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesApp.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Writers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieActors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    ActorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieActors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieActors_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieActors_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    RatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieRatings_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Biography", "DateOfBirth", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Tim Robbins was born in West Covina, California, to Mary Robbins (née Bledsoe), an actress, and Gilbert Lee Robbins, a musician, folk singer, actor, and former manager of The Gaslight Cafe. Robbins studied drama at UCLA, where he graduated with honors in 1981.", new DateTime(1958, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tim", "Robbins" },
                    { 2, "With an authoritative voice and calm demeanor, this ever-popular American actor has grown into one of the most respected figures in modern US cinema. Morgan was born on June 1, 1937 in Memphis, Tennessee, to Mayme Edna (Revere), a teacher, and Morgan Porterfield Freeman, a barber.", new DateTime(1937, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Morgan", "Freeman" },
                    { 3, "Marlon Brando is widely considered the greatest movie actor of all time, rivaled only by the more theatrically oriented Laurence Olivier in terms of esteem.", new DateTime(1924, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marlon", "Brando" },
                    { 4, "Alfredo James 'Al' Pacino established himself as a film actor during one of cinema's most vibrant decades, the 1970s, and has become an enduring and iconic figure in the world of American movies.", new DateTime(1940, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Al", "Pacino" },
                    { 5, "Christian Charles Philip Bale was born in Pembrokeshire, Wales, UK on January 30, 1974, to English parents Jennifer 'Jenny' (James) and David Bale.", new DateTime(1974, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Christian", "Bale" },
                    { 6, "When hunky, twenty-year-old heart-throb Heath Ledger first came to the attention of the public in 1999, it was all too easy to tag him as a 'pretty boy' and an actor of little depth.", new DateTime(1979, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Heath", "Ledger" },
                    { 7, "Liam Neeson was born on June 7, 1952 in Ballymena, Northern Ireland, to Katherine (Brown), a cook, and Bernard Neeson, a school caretaker.", new DateTime(1952, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liam", "Neeson" },
                    { 8, "Ben Kingsley was born Krishna Bhanji on December 31, 1943 in Scarborough, Yorkshire, England. His father, Rahimtulla Harji Bhanji, was a Kenyan-born medical doctor, of Gujarati Indian descent, and his mother, Anna Lyna Mary (Goodman), was an English actress.", new DateTime(1943, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ben", "Kingsley" },
                    { 9, "Elijah Wood is an American actor best known for portraying Frodo Baggins in Peter Jackson's blockbuster Lord of the Rings film trilogy.", new DateTime(1981, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elijah", "Wood" },
                    { 10, "Widely regarded as one of greatest stage and screen actors both in his native Great Britain and internationally, twice nominated for the Oscar and recipient of every major theatrical award in the UK and US, Ian Murray McKellen was born on May 25, 1939 in Burnley, Lancashire, England, to Margery Lois (Sutcliffe) and Denis Murray McKellen, a civil engineer and lay preacher.", new DateTime(1939, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ian", "McKellen" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Genre", "Rating", "ReleaseYear", "Title", "Writers" },
                values: new object[,]
                {
                    { 1, "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.", "Frank Darabont", "Drama", 9.3000000000000007, 1994, "The Shawshank Redemption", "Stephen King (short story \"Rita Hayworth and Shawshank Redemption\"), Frank Darabont (screenplay)" },
                    { 2, "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.", "Francis Ford Coppola", "Crime, Drama", 9.1999999999999993, 1972, "The Godfather", "Mario Puzo (screenplay by), Francis Ford Coppola (screenplay by)" },
                    { 3, "When the menace known as The Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.", "Christopher Nolan", "Action, Crime, Drama", 9.0, 2008, "The Dark Knight", "Jonathan Nolan (screenplay), Christopher Nolan (screenplay)" },
                    { 4, "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.", "Steven Spielberg", "Biography, Drama, History", 8.9000000000000004, 1993, "Schindler's List", "Thomas Keneally (book), Steven Zaillian (screenplay)" },
                    { 5, "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.", "Peter Jackson", "Action, Adventure, Drama", 8.9000000000000004, 2003, "The Lord of the Rings: The Return of the King", "J.R.R. Tolkien (novel), Fran Walsh (screenplay)" }
                });

            migrationBuilder.InsertData(
                table: "MovieActors",
                columns: new[] { "Id", "ActorId", "MovieId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 2 },
                    { 4, 4, 2 },
                    { 5, 5, 3 },
                    { 6, 6, 3 },
                    { 7, 7, 4 },
                    { 8, 8, 4 },
                    { 9, 9, 5 },
                    { 10, 10, 5 }
                });

            migrationBuilder.InsertData(
                table: "MovieRatings",
                columns: new[] { "Id", "MovieId", "RatedAt", "Rating" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1932, 6, 29, 12, 50, 24, 213, DateTimeKind.Local).AddTicks(5890), 7.2999999999999998 },
                    { 2, 1, new DateTime(2033, 2, 23, 12, 50, 24, 213, DateTimeKind.Local).AddTicks(5940), 9.0 },
                    { 3, 1, new DateTime(1964, 9, 1, 12, 50, 24, 213, DateTimeKind.Local).AddTicks(5950), 8.9000000000000004 },
                    { 4, 1, new DateTime(2123, 7, 25, 12, 50, 24, 213, DateTimeKind.Local).AddTicks(5950), 9.3000000000000007 },
                    { 5, 2, new DateTime(2022, 5, 3, 12, 50, 24, 213, DateTimeKind.Local).AddTicks(5960), 9.5 },
                    { 6, 2, new DateTime(2037, 5, 17, 12, 50, 24, 213, DateTimeKind.Local).AddTicks(5960), 7.2999999999999998 },
                    { 7, 2, new DateTime(1979, 2, 6, 12, 50, 24, 213, DateTimeKind.Local).AddTicks(5960), 9.0 },
                    { 8, 2, new DateTime(2039, 11, 16, 12, 50, 24, 213, DateTimeKind.Local).AddTicks(5970), 8.9000000000000004 },
                    { 9, 3, new DateTime(1934, 7, 5, 12, 50, 24, 213, DateTimeKind.Local).AddTicks(5970), 9.3000000000000007 },
                    { 10, 3, new DateTime(2028, 3, 5, 12, 50, 24, 213, DateTimeKind.Local).AddTicks(5980), 9.5 },
                    { 11, 3, new DateTime(2002, 12, 8, 12, 50, 24, 213, DateTimeKind.Local).AddTicks(5980), 7.2999999999999998 },
                    { 12, 3, new DateTime(2081, 9, 12, 12, 50, 24, 213, DateTimeKind.Local).AddTicks(5990), 9.0 },
                    { 13, 3, new DateTime(2071, 6, 13, 12, 50, 24, 213, DateTimeKind.Local).AddTicks(5990), 8.9000000000000004 },
                    { 14, 3, new DateTime(2074, 10, 22, 12, 50, 24, 213, DateTimeKind.Local).AddTicks(5990), 9.3000000000000007 },
                    { 15, 4, new DateTime(2073, 1, 20, 12, 50, 24, 213, DateTimeKind.Local).AddTicks(6000), 9.5 },
                    { 16, 4, new DateTime(2062, 10, 9, 12, 50, 24, 213, DateTimeKind.Local).AddTicks(6000), 7.2999999999999998 },
                    { 17, 4, new DateTime(1997, 3, 18, 12, 50, 24, 213, DateTimeKind.Local).AddTicks(6010), 9.0 },
                    { 18, 4, new DateTime(2039, 1, 8, 12, 50, 24, 213, DateTimeKind.Local).AddTicks(6010), 8.9000000000000004 },
                    { 19, 4, new DateTime(2122, 12, 4, 12, 50, 24, 213, DateTimeKind.Local).AddTicks(6020), 9.3000000000000007 },
                    { 20, 4, new DateTime(2057, 2, 20, 12, 50, 24, 213, DateTimeKind.Local).AddTicks(6020), 9.5 },
                    { 21, 5, new DateTime(1975, 12, 29, 12, 50, 24, 213, DateTimeKind.Local).AddTicks(6030), 7.2999999999999998 },
                    { 22, 5, new DateTime(1929, 6, 30, 12, 50, 24, 213, DateTimeKind.Local).AddTicks(6030), 9.0 },
                    { 23, 5, new DateTime(1986, 1, 8, 12, 50, 24, 213, DateTimeKind.Local).AddTicks(6030), 8.9000000000000004 },
                    { 24, 5, new DateTime(2012, 6, 11, 12, 50, 24, 213, DateTimeKind.Local).AddTicks(6040), 9.3000000000000007 },
                    { 25, 5, new DateTime(2056, 3, 20, 12, 50, 24, 213, DateTimeKind.Local).AddTicks(6040), 9.5 },
                    { 26, 5, new DateTime(2107, 5, 8, 12, 50, 24, 213, DateTimeKind.Local).AddTicks(6050), 7.2999999999999998 },
                    { 27, 5, new DateTime(2041, 4, 18, 12, 50, 24, 213, DateTimeKind.Local).AddTicks(6050), 9.0 },
                    { 28, 5, new DateTime(2100, 3, 19, 12, 50, 24, 213, DateTimeKind.Local).AddTicks(6050), 8.9000000000000004 },
                    { 29, 5, new DateTime(2048, 5, 2, 12, 50, 24, 213, DateTimeKind.Local).AddTicks(6060), 9.3000000000000007 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieActors_ActorId",
                table: "MovieActors",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieActors_MovieId",
                table: "MovieActors",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieRatings_MovieId",
                table: "MovieRatings",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieActors");

            migrationBuilder.DropTable(
                name: "MovieRatings");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
