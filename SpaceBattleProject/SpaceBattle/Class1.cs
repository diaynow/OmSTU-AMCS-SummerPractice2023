using System;


namespace SpaceBattle;

public class SpaceShip
{
    public double[] Coordinates = new double[2] { double.NaN, double.PositiveInfinity };
    public double[] Speed = new double[2] { double.PositiveInfinity, double.NaN };
    public int Fuel;
    public int ConsumptionFuel;
    public int Corner;
    public int CornerSpeed;
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
    public void SetFuel(int fuel)
    {
        this.Fuel = fuel;
    }
    public void SetConsumptionFuel(int consumptionFuel)
    {
        this.ConsumptionFuel = consumptionFuel;
    }
    public void SetCorner(int corner){
        this.Corner=corner;
    }
    public void SetCornerSpeed(int cornerSpeed)
    {
        this.CornerSpeed = cornerSpeed;
    }
    public int ChangeFuel(){
        if (this.Fuel-this.ConsumptionFuel>0){
            this.Fuel=this.Fuel-this.ConsumptionFuel;
        }
        else{
            throw new Exception();
        }
        return this.Fuel;
    }
    public int ChangeCorner(){
        if(this.Corner>360 || this.CornerSpeed>360){
            throw new Exception();
        }
        else{
            this.Corner=this.Corner+this.CornerSpeed;
        }
        return this.Corner;
    }
}