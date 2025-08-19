using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlashCardAndQuizBackend.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Meanings_MeaningId",
                table: "Tags");

            migrationBuilder.DropTable(
                name: "MeaningTag");

            migrationBuilder.DropIndex(
                name: "IX_Tags_MeaningId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "MeaningId",
                table: "Tags");

            migrationBuilder.CreateTable(
                name: "Meanings_Tags",
                columns: table => new
                {
                    MeaningsId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meanings_Tags", x => new { x.MeaningsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_Meanings_Tags_Meanings_MeaningsId",
                        column: x => x.MeaningsId,
                        principalTable: "Meanings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meanings_Tags_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Meanings_Tags_TagsId",
                table: "Meanings_Tags",
                column: "TagsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meanings_Tags");

            migrationBuilder.AddColumn<int>(
                name: "MeaningId",
                table: "Tags",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Tags_MeaningId",
                table: "Tags",
                column: "MeaningId");

            migrationBuilder.CreateIndex(
                name: "IX_MeaningTag_TagId",
                table: "MeaningTag",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Meanings_MeaningId",
                table: "Tags",
                column: "MeaningId",
                principalTable: "Meanings",
                principalColumn: "Id");
        }
    }
}
