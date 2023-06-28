using Xunit;
using SquareEquationLib;

namespace SquareEquationTest
{
    public class SquareEquationLibUnit
    {
        [Theory]
        [InlineDate (0.1,1,1)]
        [InlineDate (1,double.NaN,1)]
        [InlineDate (1,1,double.PositiveInfinity)]
        public void ThrowError(double a,double b,double c)
        {
            Assert.Throws<ArgumentException>(() => SquareEquation.Solve(a, b, c));
        }
    }
}