using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectISBE.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CourseHasAuthor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "Courses");
        }
    }
}
