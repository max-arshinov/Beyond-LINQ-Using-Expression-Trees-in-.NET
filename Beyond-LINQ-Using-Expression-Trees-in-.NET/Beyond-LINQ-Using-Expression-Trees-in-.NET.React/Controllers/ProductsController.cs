using System.Linq;
using AutoMapper;
using Beyond_LINQ_Using_Expression_Trees_in_.NET.React.Data;
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
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductsController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get([FromServices] DbContext dbContext,
            [FromQuery] ProductFilter productFilter,
            [FromQuery] string orderBy)
        {
            var spec = SpecBuilder<ProductListDto>.Build(productFilter);

            // _dbContext.Products.Select(x =>
            //     new ProductListDto{
            //         Id = x.Id,
            //         Name = x.Name,
            //         CategoryName = x.Category.Name
            //     });
            
            var q = _mapper
                .ProjectTo<ProductListDto>(_dbContext.Products)
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