using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlashCardAndQuizBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRegisterColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FormalityLevel",
                table: "Register_Levels",
                newName: "Level");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Level",
                table: "Register_Levels",
                newName: "FormalityLevel");
        }
    }
}
