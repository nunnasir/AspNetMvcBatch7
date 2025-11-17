namespace DIExample;

public class Car
{
    public IEngine _engine;

    public Car(IEngine engine)
    {
        _engine = engine;
    }

    //public void Drive(IEngine engine)
    //{
    //    //if (engine == null)
    //    //{
    //    //    throw new ArgumentNullException(nameof(engine), "Engine cannot be null");
    //    //}

    //    engine.Start();
    //    Console.WriteLine("Car is Running..");
    //}

}
