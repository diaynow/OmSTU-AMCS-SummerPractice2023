namespace SquareEquationLib;

public class SquareEquation
{
    public static double[] Solve(double a, double b, double c)
    {
        double eps = Math.Pow(10, -6);

        if (a < eps && -eps < a) throw new System.ArgumentException();
        if (new[] { a, b, c }.Any(double.IsInfinity)) throw new System.ArgumentException();
        if (Double.IsNaN(a) || Double.IsNaN(b) || Double.IsNaN(c)) throw new System.ArgumentException();

        double D = b * b - 4 * a * c;

        if (D <= -eps)
        {
            double[] result = new double[0];
            return result;
        }
        else if (-eps < D & D < eps)
        {
            double x1 = (-b) / 2 * a;
            double[] result = { x1 };
            return result;
        }
        else
        {
            double x1 = -(b + (b >= 0 ? 1 : -1) * Math.Sqrt(D)) / 2;
            double x2 = c / x1;
            double[] result = { x1, x2 };
            return result;
        }
    }
}