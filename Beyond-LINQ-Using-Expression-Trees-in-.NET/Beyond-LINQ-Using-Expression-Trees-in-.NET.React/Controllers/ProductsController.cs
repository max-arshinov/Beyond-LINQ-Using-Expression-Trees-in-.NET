using Beyond_LINQ_Using_Expression_Trees_in_.NET.React.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Beyond_LINQ_Using_Expression_Trees_in_.NET.React.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController: Controller
    {
        [HttpGet]
        public IActionResult Get([FromServices] DbContext dbContext, [FromQuery] ProductFilter productFilter)
        {
            return Ok(new object[]{});
        }
    }
}