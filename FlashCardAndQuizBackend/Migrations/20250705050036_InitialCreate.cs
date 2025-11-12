using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FlashCardAndQuizBackend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Difficulty_Levels",
                columns: table => new
                {
                    Level = table.Column<int>(type: "int", nullable: false),
                    Label = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Difficulty_Levels", x => x.Level);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Frequency_Levels",
                columns: table => new
                {
                    Level = table.Column<int>(type: "int", nullable: false),
                    Label = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frequency_Levels", x => x.Level);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Importance_Levels",
                columns: table => new
                {
                    Level = table.Column<int>(type: "int", nullable: false),
                    Label = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Importance_Levels", x => x.Level);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Lexical_Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lexical_Units", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Register_Levels",
                columns: table => new
                {
                    FormalityLevel = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Label = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Register_Levels", x => x.FormalityLevel);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Meanings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WordId = table.Column<int>(type: "int", nullable: false),
                    LexicalUnitId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Note = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DifficultyLevel = table.Column<int>(type: "int", nullable: false, defaultValue: 2),
                    FrequencyLevel = table.Column<int>(type: "int", nullable: false, defaultValue: 3),
                    ImportanceLevel = table.Column<int>(type: "int", nullable: false, defaultValue: 2),
                    RegisterLevel = table.Column<byte>(type: "tinyint unsigned", nullable: false, defaultValue: (byte)2)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meanings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meanings_Lexical_Units_LexicalUnitId",
                        column: x => x.LexicalUnitId,
                        principalTable: "Lexical_Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meanings_Lexical_Units_WordId",
                        column: x => x.WordId,
                        principalTable: "Lexical_Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sentence_Examples",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MeaningId = table.Column<int>(type: "int", nullable: false),
                    Sentence = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LexicalUnitId = table.Column<int>(type: "int", nullable: true),
                    MeaningId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sentence_Examples", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sentence_Examples_Lexical_Units_LexicalUnitId",
                        column: x => x.LexicalUnitId,
                        principalTable: "Lexical_Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sentence_Examples_Meanings_MeaningId",
                        column: x => x.MeaningId,
                        principalTable: "Meanings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sentence_Examples_Meanings_MeaningId1",
                        column: x => x.MeaningId1,
                        principalTable: "Meanings",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MeaningId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_Meanings_MeaningId",
                        column: x => x.MeaningId,
                        principalTable: "Meanings",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MeaningTag",
                columns: table => new
                {
                    MeaningId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeaningTag", x => new { x.MeaningId, x.TagId });
                    table.ForeignKey(
                        name: "FK_MeaningTag_Meanings_MeaningId",
                        column: x => x.MeaningId,
                        principalTable: "Meanings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeaningTag_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Difficulty_Levels",
                columns: new[] { "Level", "Label" },
                values: new object[,]
                {
                    { 0, "VeryEasy" },
                    { 1, "Easy" },
                    { 2, "Moderate" },
                    { 3, "Hard" },
                    { 4, "VeryHard" }
                });

            migrationBuilder.InsertData(
                table: "Frequency_Levels",
                columns: new[] { "Level", "Label" },
                values: new object[,]
                {
                    { 0, "Obsolete" },
                    { 1, "Rare" },
                    { 2, "Occasional" },
                    { 3, "Common" },
                    { 4, "VeryCommon" }
                });

            migrationBuilder.InsertData(
                table: "Importance_Levels",
                columns: new[] { "Level", "Label" },
                values: new object[,]
                {
                    { 0, "VeryLow" },
                    { 1, "Low" },
                    { 2, "Medium" },
                    { 3, "High" },
                    { 4, "VeryHigh" }
                });

            migrationBuilder.InsertData(
                table: "Register_Levels",
                columns: new[] { "FormalityLevel", "Label" },
                values: new object[,]
                {
                    { (byte)0, "Intimate" },
                    { (byte)1, "Casual" },
                    { (byte)2, "Consultative" },
                    { (byte)3, "Formal" },
                    { (byte)4, "Frozen" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lexical_Units_Text",
                table: "Lexical_Units",
                column: "Text",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Meanings_LexicalUnitId",
                table: "Meanings",
                column: "LexicalUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Meanings_WordId",
                table: "Meanings",
                column: "WordId");

            migrationBuilder.CreateIndex(
                name: "IX_MeaningTag_TagId",
                table: "MeaningTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Sentence_Examples_LexicalUnitId",
                table: "Sentence_Examples",
                column: "LexicalUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Sentence_Examples_MeaningId",
                table: "Sentence_Examples",
                column: "MeaningId");

            migrationBuilder.CreateIndex(
                name: "IX_Sentence_Examples_MeaningId1",
                table: "Sentence_Examples",
                column: "MeaningId1");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_MeaningId",
                table: "Tags",
                column: "MeaningId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Difficulty_Levels");

            migrationBuilder.DropTable(
                name: "Frequency_Levels");

            migrationBuilder.DropTable(
                name: "Importance_Levels");

            migrationBuilder.DropTable(
                name: "MeaningTag");

            migrationBuilder.DropTable(
                name: "Register_Levels");

            migrationBuilder.DropTable(
                name: "Sentence_Examples");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Meanings");

            migrationBuilder.DropTable(
                name: "Lexical_Units");
        }
    }
}
