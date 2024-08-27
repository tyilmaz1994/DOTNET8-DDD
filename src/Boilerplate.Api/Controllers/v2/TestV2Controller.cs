using Asp.Versioning;
using Boilerplate.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.Api.Controllers.v2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/tests")]
    public class TestV2Controller : ControllerBase
    {
        [HttpGet]
        public ActionResult Get([FromQuery] TestViewModel testViewModel)
        {
            return Ok("2");
        }
    }
}
