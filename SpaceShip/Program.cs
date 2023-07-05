namespace SpaceShip1;

public class SpaceShip{ }

public class Pool
{
    private Queue<SpaceShip> Ships;
    public Pool(int count)
    {
        Ships = new Queue<SpaceShip>(count);
        for (int i = 0; i < Ships.Count; i++)
            Ships.Enqueue(new SpaceShip());
    }
    public SpaceShip TakeSlot()
    {
        if (Ships.Count() > 0)
            return Ships.Dequeue();
        else
            throw new Exception();
    }
    public void Release(SpaceShip ship)
    {
        Ships.Enqueue(ship);
    }
}
public class PoolSafety : IDisposable
{
    private Pool Pool;
    private SpaceShip Ship;
    public SpaceShip Object()
    {
        return Ship;
    }
    public PoolSafety(Pool pool)
    {
        this.Pool = pool;
        Ship = pool.TakeSlot();
    }
    public void Dispose()
    {
        Pool.Release(Ship);
    }
}
class Programm
{
    static void Main(string[] args)
    {
        Pool spaceShipPool = new Pool(5);
        using (PoolSafety guard = new PoolSafety(spaceShipPool))
        {
            SpaceShip spaceShip = guard.Object();
        }
    }
}
