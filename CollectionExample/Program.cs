
List<string> names = new List<string> { "Alice", "Bob", "Charlie" };


Console.WriteLine(Sum(new List<int> { 1, 2, 3, 4, 5 }));

static int Sum(IEnumerable<int> src)
{
    return src.Sum();
}
