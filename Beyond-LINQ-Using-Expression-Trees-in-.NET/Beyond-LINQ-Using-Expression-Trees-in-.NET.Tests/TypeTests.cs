using Force.Reflection;
using Xunit;

namespace Beyond_LINQ_Using_Expression_Trees_in_.NET.Tests
{
    public class TypeTests
    {
        [Fact]
        public void CreateAndGetName()
        {
            var baz = Type<Baz>.CreateInstance("Max");
            var namePropertyGetter = Type<Baz>.PropertyGetter<string>("Name");
            var name = namePropertyGetter.Compile()(baz);
            Assert.Equal("Max", name);
        }
    }
}