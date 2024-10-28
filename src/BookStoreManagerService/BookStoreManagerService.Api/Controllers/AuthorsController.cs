using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreManagerService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        [HttpGet]
        public async Task<IResult> Get()
        {
            return await Task.FromResult(Results.Ok());
        }
    }
}
