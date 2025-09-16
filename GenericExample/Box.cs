namespace GenericExample;

internal class Box<T> where T : IBoxInt
{
    public T Value { get; set; }

    public Box(T value)
    {
        this.Value = value;
    }
}

internal class BoxInt : IBoxInt
{
    public int Value { get; set; }

    public BoxInt()
    {
        
    }

    public BoxInt(int value)
    {
        this.Value = value;
    }
}


internal interface IBoxInt { }
