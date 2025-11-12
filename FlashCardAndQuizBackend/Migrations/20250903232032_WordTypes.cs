using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FlashCardAndQuizBackend.Migrations
{
    /// <inheritdoc />
    public partial class WordTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Word_Types",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Word_Types", x => x.Code);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Word_Types",
                columns: new[] { "Code", "Type" },
                values: new object[,]
                {
                    { 0, "Noun" },
                    { 1, "Verb" },
                    { 2, "Adjective" },
                    { 3, "Adverb" },
                    { 4, "Pronoun" },
                    { 5, "Preposition" },
                    { 6, "Conjunction" },
                    { 7, "Interjection" },
                    { 8, "WordGroup" },
                    { 9, "IdiomAndProverb" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Word_Types");
        }
    }
}
