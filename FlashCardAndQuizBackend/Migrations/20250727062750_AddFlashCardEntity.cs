using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlashCardAndQuizBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddFlashCardEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FlashCardId",
                table: "Lexical_Units",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Flash_Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LexicalUnitId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flash_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flash_Cards_Lexical_Units_LexicalUnitId",
                        column: x => x.LexicalUnitId,
                        principalTable: "Lexical_Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Lexical_Units_FlashCardId",
                table: "Lexical_Units",
                column: "FlashCardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Flash_Cards_LexicalUnitId",
                table: "Flash_Cards",
                column: "LexicalUnitId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lexical_Units_Flash_Cards_FlashCardId",
                table: "Lexical_Units",
                column: "FlashCardId",
                principalTable: "Flash_Cards",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lexical_Units_Flash_Cards_FlashCardId",
                table: "Lexical_Units");

            migrationBuilder.DropTable(
                name: "Flash_Cards");

            migrationBuilder.DropIndex(
                name: "IX_Lexical_Units_FlashCardId",
                table: "Lexical_Units");

            migrationBuilder.DropColumn(
                name: "FlashCardId",
                table: "Lexical_Units");
        }
    }
}
