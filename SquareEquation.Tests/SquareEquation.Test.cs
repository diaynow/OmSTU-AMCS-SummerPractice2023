using Xunit;
using SquareEquationLib;

namespace SquareEquation_Test
{
    public class SquareEquation_Test
    {

    [Theory]
    [InlineData(0,1,1)]
    [InlineData(1,double.NaN,1)]
    [InlineData(1,1,double.PositiveInfinity)]
    [InlineData(double.NegativeInfinity,1,1)]
    public void ErrorThrow(double a,double b, double c)
    {
        Assert.Throws<ArgumentException>(() => SquareEquation.Solve(a, b, c));
    }
    [Theory]
    [InlineData(1,1,1,new double[0])]
    [InlineData(2,4,2,new double[1]{-1})]
    [InlineData(1,4,2,new double[2]{-3,-1})]
    public void NoErrorThrow(double a,double b,double c,double[] expected){
        var result=SquareEquation.Solve(a,b,c);
        Array.Sort(result);
        Array.Sort(expected);
        Array.Equals(result,expected);
    }



}
}