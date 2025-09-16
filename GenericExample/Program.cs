using GenericExample;

var boxint = new BoxInt { Value = 42 };

var box = new Box<BoxInt>(new BoxInt { Value = 42 });

int x = 10;
int y = 20;

string s1 = "A";
string s2 = "B";

Utils.Swap<int>(ref x, ref y);
Utils.Swap<string>(ref s1, ref s2);

Console.WriteLine($"X: {x}, Y: {y}");
Console.WriteLine($"S1: {s1}, S2: {s2}");

var number = new List<string> { "1", "2", "3", "4", "5" };




