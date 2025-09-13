using CSharpEssential;





//Student student = new Student();
//student.Name = "Alice";

//MathHelper mathHelper = new MathHelper();
int sum = MathHelper.Add(5, 3);
int sub = MathHelper.Subtract(5, 3);

//Console.WriteLine($"Sum: {sum}, Sub: {sub}");

string original = "Test";
original.ToUpperCase(true);


//StringHelper.ToUpperCase(original);
original.ToUpperCase(true);


//Console.WriteLine(original.ToUpperCase(false));
//Console.WriteLine(StringHelper.Reverse("Hello World"));


ToupleExample toupleExample = new ToupleExample();

string personName = "";


//var (personName, personAge, personAddress) = toupleExample.GetPersonInfo();
var personInfo = toupleExample.GetPersonInfo();

//Console.WriteLine($"Name: {personInfo.Item1}, Age: {personAge}, From: {personAddress}");


GenericExample genericExample = new GenericExample();

var input = genericExample.Echo<StudentInfo>(new StudentInfo { Id = 1, Name = "Zakir" });
genericExample.Echo2(10, "Test");


//Console.WriteLine(input);

var max = genericExample.GetMax<int>(10, 20);
var stringmax = genericExample.GetMax<string>("apple", "banna");

//Console.WriteLine($"Max: {max}, String Max: {stringmax}");


Box<StudentInfo> box = new Box<StudentInfo>();

box.Value.Name = "Zakir";
box.Value.Id    = 123;

















