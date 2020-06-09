using System;
using System.Linq;
using System.Linq.Expressions;

namespace Beyond_LINQ_Using_Expression_Trees_in_.NET.Tests
{
    public static class NaiveOr
    {
        public static void NaiveOr1()
        {
            Expression<Func<int, bool>> e1 = x => x > 5;
            Expression<Func<int, bool>> e2 = x => x / 2 == 5;

            Expression combined = Expression.OrElse(e1, e2);
            Expression.Lambda<Func<int, bool>>(combined);
        }

        public static void NaiveOr2()
        {
            Expression<Func<int, bool>> e1 = x => x > 5;
            Expression<Func<int, bool>> e2 = x => x / 2 == 5;

            Expression combined = Expression.OrElse(e1.Body, e2.Body);
            var lambda = Expression.Lambda<Func<int, bool>>(combined);
        }

        
        public static Expression<Func<T, bool>> Or<T> (Expression<Func<T, bool>> expr1,
            Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke (expr2,
                expr1.Parameters.Cast<Expression>());

            return Expression.Lambda<Func<T, bool>>(
                Expression.OrElse (expr1.Body, invokedExpr), expr1.Parameters);
        }
    }
}