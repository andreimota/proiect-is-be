using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectISBE.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ArticlesMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Articles",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Articles");
        }
    }
}
