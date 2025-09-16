
public class Program
{
    public delegate int MathOperation(int x, int y);
    public delegate int MathOperation2(int x, int y, int z);
    public delegate void LogData(string message);

    public static void Main()
    {
        //static int Add(int x, int y) => x + y;
        //static int Substract(int x, int y) => x - y;

        //MathOperation addOperation = Add;
        //MathOperation SubsOperation = Substract;

        MathOperation2 addOperation = (x, y, z) => x + y + z;
        MathOperation substractOperation = (x, y) => x - y;

        static void Info(string message) => Console.WriteLine($"Info: {message}");
        static void Warning(string message) => Console.WriteLine($"Warning: {message}");

        LogData logData = Info;
        logData += Warning;
        
        //logData("Delegates in C# are powerful!");


        //Console.WriteLine($"5 + 3 = {addOperation(5, 3, 2)}");
        //Console.WriteLine($"5 - 3 = {substractOperation(5, 2)}");

        // Func<> Example
        Func<int, int, int> multiply = (x, y) => x * y;
        Func<int, int, string> Addition = (x, y) =>
        {
            int result = x + y;
            return $"The sum of {x} and {y} is {result}";
        };

        //Console.WriteLine(multiply(4, 5));

        Action message = () => Console.WriteLine("Hello");
        Action<string> message2 = name =>
        {
            Console.WriteLine("Hello " + name);
        };

        //message2("Ostad");

        Predicate<int> isEven = x => x % 2 == 0;
        Console.WriteLine(isEven(5));

        List<int> numbers = new() { 1, 2, 3, 4, 5, 6 };
        var evenNumber = numbers.Where(x => x % 2 == 0).ToList();

    }
}