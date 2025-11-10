namespace DIExample;

public class DieselEngine : IEngine
{
    public void Start()
    {
        Console.WriteLine("Diesel Engine Starting....");
    }
}


public class PetrolEngine : IEngine
{
    public void Start()
    {
        Console.WriteLine("Petrol Engine Starting....");
    }
}

public class ElectricEngine : IEngine
{
    public void Start()
    {
        Console.WriteLine("Petrol Engine Starting....");
    }
}