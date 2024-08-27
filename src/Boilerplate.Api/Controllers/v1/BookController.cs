using Asp.Versioning;
using Boilerplate.Api.Contracts.Request;
using Boilerplate.Api.Contracts.Response;
using Boilerplate.Application.BookAggregate.Service;
using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/books")]
    public class BookController(IBookService bookService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = new GetBookResponseModel
            {
                Books = await bookService.GetList()
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookRequestModel request)
        {
            await bookService.Insert(request.ToViewModel());
            return Ok(request);
        }
    }
}
