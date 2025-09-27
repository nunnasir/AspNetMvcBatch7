namespace LINQExample;

internal class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public int Age { get; set; }
}


internal class PersonDto
{
    public string PersonName { get; set; }
    public string PersonCity { get; set; }
    public int Age { get; set; }
}

internal class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
}


internal class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
}

internal class OrderInfoDto
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; }
}

