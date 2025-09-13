namespace CSharpEssential;

internal class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public double Grade { get; set; }
    

    public string GetInfo()
    {
        return $"Name: {Name}, Age: {Age}, Grade: {Grade}";
    }

    public StudentInfo GetInfoDetails()
    {
        return new StudentInfo { Id = 1, Name = this.Name };
    }
}


internal class StudentInfo
{
    public int Id { get; set; }
    public string Name { get; set; }
}

