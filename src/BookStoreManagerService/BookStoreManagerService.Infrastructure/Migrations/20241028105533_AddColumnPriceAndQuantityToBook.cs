using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreManagerService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnPriceAndQuantityToBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Preco",
                table: "Livro",
                type: "NUMERIC(14,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "Livro",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Livro");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Livro");
        }
    }
}
