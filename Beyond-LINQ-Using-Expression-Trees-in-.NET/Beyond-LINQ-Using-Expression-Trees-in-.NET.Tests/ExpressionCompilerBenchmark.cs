using System;
using System.Linq.Expressions;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Jobs;

namespace Beyond_LINQ_Using_Expression_Trees_in_.NET.Tests
{
    //[SimpleJob(RunStrategy.Monitoring, launchCount: 10, warmupCount: 3, targetCount: 100)]
    public class ExpressionCompilerBenchmark
    {
        Expression<Func<string, bool>> _expression = x => x.ToString().Length > 5;
            
        [Benchmark]
        public void Compile()
        {
            _expression.Compile();
        }
    }
}