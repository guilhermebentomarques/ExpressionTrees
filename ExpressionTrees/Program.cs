using System;
using System.Linq.Expressions;

namespace ExpressionTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            Expression<Func<int, int, int>> func = (int a, int b) => a + b;
            int result_1 = func.Compile()(3, 2);
            Console.WriteLine(result_1);

            ParameterExpression paramA = Expression.Parameter(typeof(int), "a");
            ParameterExpression paramB = Expression.Parameter(typeof(int), "a");
            ParameterExpression paramC = Expression.Parameter(typeof(int), "a");

            BinaryExpression sum = Expression.Add(paramA, paramB);

            Expression<Func<int, int, int>> lambda = Expression.Lambda<Func<int, int, int>>(sum, new ParameterExpression[] { paramA, paramB });

            int result_2 = lambda.Compile()(3, 2);
            Console.WriteLine(result_2);
        }
    }
}
