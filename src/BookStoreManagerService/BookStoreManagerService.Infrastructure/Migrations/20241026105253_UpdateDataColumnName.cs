using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreManagerService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDataColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Livro",
                newName: "DataAtualizacao");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Livro",
                newName: "DataCriacao");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Autor",
                newName: "DataAtualizacao");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Autor",
                newName: "DataCriacao");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Assunto",
                newName: "DataAtualizacao");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Assunto",
                newName: "DataCriacao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataCriacao",
                table: "Livro",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "DataAtualizacao",
                table: "Livro",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "DataCriacao",
                table: "Autor",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "DataAtualizacao",
                table: "Autor",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "DataCriacao",
                table: "Assunto",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "DataAtualizacao",
                table: "Assunto",
                newName: "UpdatedAt");
        }
    }
}
