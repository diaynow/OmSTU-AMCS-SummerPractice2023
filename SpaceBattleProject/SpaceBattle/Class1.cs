using System;


namespace SpaceBattle;

public class SpaceShip
{
    public double[] Coordinates = new double[2] { double.NaN, double.PositiveInfinity };
    public double[] Speed = new double[2] { double.PositiveInfinity, double.NaN };
    public void SetCoordinates(double[] coordinates)
    {
        this.Coordinates = coordinates;
    }
    public void SetSpeed(double[] speed)
    {
        this.Speed = speed;
    }
    public bool CheckCoordinates(double[] CoordinatesOrSpeed)
    {
        foreach (var coord in CoordinatesOrSpeed)
        {
            if (double.IsNaN(coord) || double.IsInfinity(coord))
            {
                return false;
            }
        }
        return true;
    }
    public double[] ChangeCoordinates()
    {
        if (CheckCoordinates(this.Coordinates) && CheckCoordinates(this.Speed))
        {
            this.Coordinates[0] += this.Speed[0];
            this.Coordinates[1] += this.Speed[1];
            return this.Coordinates;
        }
        else
        {
            throw new Exception();
        }
    }
}