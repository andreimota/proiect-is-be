using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectISBE.DAL.Migrations
{
    /// <inheritdoc />
    public partial class QuizHasTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Quizzes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Quizzes");
        }
    }
}
