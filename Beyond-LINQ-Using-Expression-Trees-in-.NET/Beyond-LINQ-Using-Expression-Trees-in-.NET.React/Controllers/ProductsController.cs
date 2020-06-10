using System.Linq;
using Beyond_LINQ_Using_Expression_Trees_in_.NET.React.Models;
using Force.Ddd;
using Force.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Beyond_LINQ_Using_Expression_Trees_in_.NET.React.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController: Controller
    {
        [HttpGet]
        public IActionResult Get([FromServices] DbContext dbContext,
            [FromQuery] ProductFilter productFilter,
            [FromQuery] string orderBy)
        {
            var spec = SpecBuilder<Product>.Build(productFilter);

            var q = new[]
                {
                    new Product()
                    {
                        Id = 1,
                        Name = "MacBook 16",
                        Price = 100
                    },
                    new Product()
                    {
                        Id = 2,
                        Name = "MacBook 15",
                        Price = 200
                    },
                    new Product()
                    {
                        Id = 3,
                        Name = "Dell",
                        Price = 300
                    },
                }
                .AsQueryable()
                .Where(spec);

            if (orderBy != null)
            {
                q = q.OrderBy(orderBy);
            }

            var products = q.ToList();
            return Ok(products);
        }
    }
}