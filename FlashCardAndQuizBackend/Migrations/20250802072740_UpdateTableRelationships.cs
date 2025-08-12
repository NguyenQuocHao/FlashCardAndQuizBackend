using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlashCardAndQuizBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meanings_Lexical_Units_WordId",
                table: "Meanings");

            migrationBuilder.DropForeignKey(
                name: "FK_Sentence_Examples_Lexical_Units_LexicalUnitId",
                table: "Sentence_Examples");

            migrationBuilder.DropForeignKey(
                name: "FK_Sentence_Examples_Meanings_MeaningId",
                table: "Sentence_Examples");

            migrationBuilder.DropForeignKey(
                name: "FK_Sentence_Examples_Meanings_MeaningId1",
                table: "Sentence_Examples");

            migrationBuilder.DropIndex(
                name: "IX_Sentence_Examples_LexicalUnitId",
                table: "Sentence_Examples");

            migrationBuilder.DropIndex(
                name: "IX_Sentence_Examples_MeaningId",
                table: "Sentence_Examples");

            migrationBuilder.DropIndex(
                name: "IX_Sentence_Examples_MeaningId1",
                table: "Sentence_Examples");

            migrationBuilder.DropIndex(
                name: "IX_Meanings_WordId",
                table: "Meanings");

            migrationBuilder.DropColumn(
                name: "LexicalUnitId",
                table: "Sentence_Examples");

            migrationBuilder.DropColumn(
                name: "MeaningId",
                table: "Sentence_Examples");

            migrationBuilder.DropColumn(
                name: "MeaningId1",
                table: "Sentence_Examples");

            migrationBuilder.DropColumn(
                name: "WordId",
                table: "Meanings");

            migrationBuilder.CreateTable(
                name: "Meanings_SentenceExamples",
                columns: table => new
                {
                    MeaningsId = table.Column<int>(type: "int", nullable: false),
                    SentenceExamplesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meanings_SentenceExamples", x => new { x.MeaningsId, x.SentenceExamplesId });
                    table.ForeignKey(
                        name: "FK_Meanings_SentenceExamples_Meanings_MeaningsId",
                        column: x => x.MeaningsId,
                        principalTable: "Meanings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meanings_SentenceExamples_Sentence_Examples_SentenceExamples~",
                        column: x => x.SentenceExamplesId,
                        principalTable: "Sentence_Examples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Meanings_SentenceExamples_SentenceExamplesId",
                table: "Meanings_SentenceExamples",
                column: "SentenceExamplesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meanings_SentenceExamples");

            migrationBuilder.AddColumn<int>(
                name: "LexicalUnitId",
                table: "Sentence_Examples",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MeaningId",
                table: "Sentence_Examples",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MeaningId1",
                table: "Sentence_Examples",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WordId",
                table: "Meanings",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "IX_Meanings_WordId",
                table: "Meanings",
                column: "WordId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meanings_Lexical_Units_WordId",
                table: "Meanings",
                column: "WordId",
                principalTable: "Lexical_Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sentence_Examples_Lexical_Units_LexicalUnitId",
                table: "Sentence_Examples",
                column: "LexicalUnitId",
                principalTable: "Lexical_Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sentence_Examples_Meanings_MeaningId",
                table: "Sentence_Examples",
                column: "MeaningId",
                principalTable: "Meanings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sentence_Examples_Meanings_MeaningId1",
                table: "Sentence_Examples",
                column: "MeaningId1",
                principalTable: "Meanings",
                principalColumn: "Id");
        }
    }
}
