using System;
using System.Linq.Expressions;
using Beyond_LINQ_Using_Expression_Trees_in_.NET.React.Helpers.System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;

namespace Beyond_LINQ_Using_Expression_Trees_in_.NET.React.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormController: Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            Expression<Func<int, bool>> forAdultsOnly = x => x > 18;
            return Ok(JsExpressionVisitor.ExpressionToString(forAdultsOnly));
        }
    }
}