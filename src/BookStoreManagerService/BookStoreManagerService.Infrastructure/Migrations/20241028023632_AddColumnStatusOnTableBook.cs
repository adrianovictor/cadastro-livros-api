using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreManagerService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnStatusOnTableBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Situacao",
                table: "Livro",
                type: "int",
                nullable: false,
                defaultValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Situacao",
                table: "Livro");
        }
    }
}
