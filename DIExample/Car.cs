namespace DIExample;

public class Car
{
    private IEngine _engine;

    public Car(IEngine engine)
    {
        _engine = engine;
    }

    public void Drive()
    {
        _engine.Start();
        Console.WriteLine("Car is Running..");
    }
}
