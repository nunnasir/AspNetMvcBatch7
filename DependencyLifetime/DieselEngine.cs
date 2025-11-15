namespace DependencyLifetime;

public class DieselEngine : IEngine
{
    public string Start()
    {
        return "Diesel Engine Starting....";
    }
}

public class PetrolEngine : IEngine
{
    public string Start()
    {
        return "Petrol Engine Starting....";
    }
}

public class ElectricEngine : IEngine
{
    public string Start()
    {
        return "Electric Engine Starting....";
    }
}
