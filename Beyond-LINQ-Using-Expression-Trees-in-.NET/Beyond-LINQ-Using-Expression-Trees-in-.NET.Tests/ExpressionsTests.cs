using System;
using System.Linq;
using System.Linq.Expressions;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using Beyond_LINQ_Using_Expression_Trees_in_.NET.React.Models;
using Xunit;

namespace Beyond_LINQ_Using_Expression_Trees_in_.NET.Tests
{
    public class ExpressionsTests
    {
        #region Compile

        public const int CompileMean = 50000;

        [Fact]
        public void Compile_IsSlow()
        {
            var summary = BenchmarkRunner.Run<ExpressionCompilerBenchmark>();

            AssertMean(summary, nameof(ExpressionCompilerBenchmark.Compile), CompileMean);
        }
        
        private static void AssertMean(Summary summary, string benchmarkName, int mean)
        {
            var report = GetReportByName(summary, benchmarkName);
            Assert.True(report.ResultStatistics.Mean > mean,
                $"Mean: {report.ResultStatistics.Mean}");
        }

        private static BenchmarkReport GetReportByName(Summary summary, string benchmarkName) =>
            summary
                .Reports
                .First(x => x.BenchmarkCase.Descriptor.DisplayInfo ==
                            nameof(ExpressionCompilerBenchmark) + "." + benchmarkName);
        
        #endregion
        
        [Fact]
        public void NaiveOr1_Fails()
        {
            // System.InvalidOperationException
            // The binary operator OrElse is not defined for the types 
            Assert.Throws<InvalidOperationException>(NaiveOr.NaiveOr1);
        }

        [Fact]
        public void NaiveOr2_Fails()
        {
            // System.ArgumentException : Incorrect number
            // of parameters supplied for lambda declaration
            Assert.Throws<ArgumentException>(NaiveOr.NaiveOr2);
        }

        static readonly Expression<Func<int, bool>> Less1 = x => x < 1;
        static readonly Expression<Func<int, bool>> Greater3 = x => x > 3;

        public static Expression<Func<int, bool>> Less1OrGreater3Manual { get; } = x => x < 1 || x > 3;

        private Expression<Func<int, bool>> BuildAndAssertOrElseExpression(
            Func<Expression<Func<int, bool>>, 
            Expression<Func<int, bool>>, Expression<Func<int, bool>>> 
            combiner)
        {
            var less1OrGreater3 = combiner(Less1, Greater3);
            var compiled = less1OrGreater3.Compile();

            Assert.False(compiled(2));
            Assert.True(compiled(0));
            Assert.True(compiled(4));

            return less1OrGreater3;
        }

        [Fact]
        public void NaiveOr3_Works_ExpressionTreeIsNotTheSame()
        {
            var less1OrGreater3 = 
                BuildAndAssertOrElseExpression(NaiveOr.Or);
            
            Assert.NotEqual(Less1OrGreater3Manual.ToString(), 
                less1OrGreater3.ToString());
        }

        [Fact]
        public void PredicateBuilder_Works_ExpressionTreeIsTheSame()
        {
            var less1OrGreater3 = 
                BuildAndAssertOrElseExpression(PredicateBuilder.Or);
            
            Assert.Equal(Less1OrGreater3Manual.ToString(), 
                less1OrGreater3.ToString());
        }

        [Fact]
        public void Spec_From()
        {
            var niceProductsSpec = Category.NiceRating.From<Product>(x => x.Category);
        }
    }
}