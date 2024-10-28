using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreManagerService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateColumnNameYearOfPublication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "YearOfPublication",
                table: "Livro",
                newName: "AnoPublicacao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AnoPublicacao",
                table: "Livro",
                newName: "YearOfPublication");
        }
    }
}
