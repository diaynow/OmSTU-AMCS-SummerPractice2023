using Xunit;
using SquareEquationLib;

namespace SquareEquation_Test
{
    public class SquareEquation_Test
    {

        [Theory]
        [InlineData(double.NaN,1,1)]
        [InlineData(1,double.NaN,1)]
        [InlineData(1,1,double.NaN)]

        [InlineData(double.PositiveInfinity,1,1)]
        [InlineData(1,double.PositiveInfinity,1)]
        [InlineData(1,1,double.PositiveInfinity)]

        [InlineData(double.NegativeInfinity,1,1)]
        [InlineData(1,double.NegativeInfinity,1)]
        [InlineData(1,1,double.NegativeInfinity)]
        public void testValidArgument(double a,double b, double c)
        {
            Assert.Throws<ArgumentException>(() => SquareEquation.Solve(a, b, c));
        }
    }
}