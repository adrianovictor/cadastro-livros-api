using BookStoreManagerService.Api.Extensions;
using BookStoreManagerService.Api.Models.Book;
using BookStoreManagerService.Application.Commands.Books;
using BookStoreManagerService.Application.Queries.Books;
using BookStoreManagerService.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreManagerService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        #region Private Variables
        private readonly IMediator _mediator;
        #endregion

        #region Constructor
        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region POST
        [HttpPost]
        public async Task<IResult> Post([FromBody] CreateBookRequest request)
        {
            return (await _mediator.Send(
                new CreateBookCommand(
                    request.Titulo, 
                    request.Editora, 
                    request.Edicao, 
                    request.AnoPublicacao, 
                    request.Autor,
                    request.Price,
                    request.Quantity
                 ))).ToResult();
        }
        #endregion

        #region PUT
        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, [FromBody] UpdateBookRequest request)
        {
            return (await _mediator.Send(
                new UpdateBookCommand(
                    id,
                    request.Title, 
                    request.Publisher, 
                    request.Edition, 
                    request.YearofPublication, 
                    request.Author,
                    request.Subject,
                    request.Price,
                    request.Quantity
                 ))).ToResult();
        }        
        #endregion

        #region GET
        [HttpGet]
        public async Task<List<BookResponse>> Get([FromQuery] QueryBooks query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet("{id}")]
        public async Task<BookResponse> GetById(int id )
        {
            var query = new QueryUniqueBook { Id = id! };

            return await _mediator.Send(query);
        }
        #endregion

        #region DELETE
        [HttpDelete("{id:int}")]
        public async Task<IResult> Delete(int id)
        {
            return (await _mediator.Send(new DeleteBookCommand([id]))).ToResult();
        }
        #endregion
    }
}
