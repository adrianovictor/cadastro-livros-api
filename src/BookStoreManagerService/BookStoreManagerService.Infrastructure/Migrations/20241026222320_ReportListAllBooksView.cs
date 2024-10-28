using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreManagerService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ReportListAllBooksView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW [dbo].[RelatorioLivros] AS
                                        SELECT l.Codl,
                                            l.Titulo,
                                            l.Editora,
                                            l.Edicao,
                                            l.AnoPublicacao,
                                            l.DataCriacao,
                                            a.CodAu,
                                            a.Nome,
                                            ass.CodAs,
                                            ass.Descricao
                                            FROM [dbo].[Livro] l
                                                LEFT JOIN [dbo].Livro_Autor la ON l.Codl = la.Livro_Codl
                                                LEFT JOIN [dbo].[Autor] a ON la.Autor_CodAu = a.CodAu
                                                LEFT JOIN [dbo].[Livro_Assunto] las ON l.Codl = las.Livro_Codl
                                                LEFT JOIN [dbo].[Assunto] ass ON las.Assunto_CodAs = ass.CodAs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW [dbo].[RelatorioLivros]");
        }
    }
}
