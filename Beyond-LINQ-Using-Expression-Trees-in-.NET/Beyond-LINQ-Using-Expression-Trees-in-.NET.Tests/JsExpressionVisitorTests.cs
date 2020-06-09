using System;
using System.Linq.Expressions;
using Beyond_LINQ_Using_Expression_Trees_in_.NET.React.Helpers;
using Beyond_LINQ_Using_Expression_Trees_in_.NET.React.Helpers.System.Linq.Expressions;
using Xunit;

namespace Beyond_LINQ_Using_Expression_Trees_in_.NET.Tests
{
    public class JsExpressionVisitorTests
    {
        [Fact]
        public void A()
        {
            Expression<Func<int, bool>> expr = x => x + 5 < 10;
            var str = JsExpressionVisitor.ExpressionToString(expr);
            Assert.Equal("x => ((x + 5) < 10)", str);
        }
    }
}