using BookStoreManagerService.Domain.Dto;
using BookStoreManagerService.Domain.Model;
using BookStoreManagerService.Domain.Repository.Queries;
using BookStoreManagerService.Infrastructure.Repositories.Common;
using Dapper;

namespace BookStoreManagerService.Infrastructure.Repositories.Queries;

public class BookQueryRepository(string connectionString) : QueryRepository<Book>(connectionString), IBookQueryRepository
{
    public async Task<IReadOnlyList<BookDto>> GetAllAsync()
    {
        var sql = @"SELECT l.Codl Id,
                           l.Titulo Title,
                           l.Editora Publisher,
                           l.Edicao Edition,
                           l.AnoPublicacao YearOfPublication,
                           l.DataCriacao CreatedAt,
                           a.CodAu AuthorId,
                           a.Nome Author,
                           ass.CodAs SubjectId,
                           ass.Descricao Subject
                    FROM [dbo].[Livro] l
                        LEFT JOIN [dbo].Livro_Autor la ON l.Codl = la.Livro_Codl
                        LEFT JOIN [dbo].[Autor] a ON la.Autor_CodAu = a.CodAu
                        LEFT JOIN [dbo].[Livro_Assunto] las ON l.Codl = las.Livro_Codl
                        LEFT JOIN [dbo].[Assunto] ass ON las.Assunto_CodAs = ass.CodAs";

        return (await CreateConnection().QueryAsync<BookDto>(sql)).ToList();
    }

    public async Task<BookDto?> GetByIdAsync(int id)
    {
        var sql = @"SELECT l.Codl Id,
                           l.Titulo Title,
                           l.Editora Publisher,
                           l.Edicao Edition,
                           l.AnoPublicacao YearOfPublication,
                           l.DataCriacao CreatedAt,
                           a.CodAu AuthorId,
                           a.Nome Author,
                           ass.CodAs SubjectId,
                           ass.Descricao Subject
                    FROM [dbo].[Livro] l
                        LEFT JOIN [dbo].Livro_Autor la ON l.Codl = la.Livro_Codl
                        LEFT JOIN [dbo].[Autor] a ON la.Autor_CodAu = a.CodAu
                        LEFT JOIN [dbo].[Livro_Assunto] las ON l.Codl = las.Livro_Codl
                        LEFT JOIN [dbo].[Assunto] ass ON las.Assunto_CodAs = ass.CodAs
                    WHERE l.Codl = @id";

        return await CreateConnection().QueryFirstOrDefaultAsync<BookDto>(sql, new { id });
    }

    public Task<BookDto?> GetByIdentificationNumberAsync(string identificationNumber)
    {
        throw new NotImplementedException();
    }

    public Task<BookDto?> GetByUniqueIdAsync(int uniqueId)
    {
        throw new NotImplementedException();
    }
}
