using Microsoft.AspNetCore.Mvc;

namespace SimpleOpenAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet("")]
        public ActionResult<string> GetBook()
        {
            return Ok("It's ok");
        }
    }
}
