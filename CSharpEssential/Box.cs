using System.Numerics;

namespace CSharpEssential;

internal class Box<EASS>
{
    public EASS Value
    {
        get; set;
    }
}


internal class Normal
{
    public string Value
    {
        get; set;
    }
}



public class Person : IEntity<int, Studnet>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public Studnet CreatedBy { get; set; }
    public Studnet updatedBy { get; set; }
}

public interface IEntity<T, V> 
    where T : INumber<T> 
    where V : IStudent
{
    T Id { get; set; }
    V CreatedBy { get; set; }
    V updatedBy { get; set; }
}


public interface IStudent
{
}

public class Studnet : IStudent
{

}

public class Teacher : IStudent
{

}









