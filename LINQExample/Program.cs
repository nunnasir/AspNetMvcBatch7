
using LINQExample;

var people = new List<Person>
{
    new Person { Id = 1, Name = "Alice", City = "Dhaka", Age = 30 },
    new Person { Id = 2, Name = "Bob", City = "Chattogram", Age = 25 },
    new Person { Id = 3, Name = "Charlie", City = "Dhaka", Age = 35 },
    new Person { Id = 4, Name = "David", City = "Sylhet", Age = 28 }
};


//foreach (var person in people)
//{
//    Console.WriteLine($"{person.Id} {person.Name} {person.City} {person.Age}");
//}


// Method syntax
var query1 = people.Where(p => p.City == "Dhaka");

/*
    select Id, Name from people where City = 'Dhaka' order by name desc
 */

// Query syntax
var query2 = from p in people
             where p.Id == 1
             select p;

//foreach (var person in query1)
//{
//    Console.WriteLine($"{person.Id} {person.Name} {person.City} {person.Age}");
//}


//foreach (var person in query2)
//{
//    Console.WriteLine($"{person.Id} {person.Name} {person.City} {person.Age}");
//}


var adults = people.Where(p => p.Age >= 30).ToList();

/*
    select Id, Name from people where City = 'Dhaka' order by name desc, age asc
 */

var adultsName = people
    .Where(p => p.Age >= 30 && p.City == "Dhaka")
    .OrderByDescending(p => p.Name)
    .Select(p => new { PersonName = p.Name, PersonCity =  p.City }).ToList();


var adultsNameWithDto = people
    .Where(p => p.Age >= 30 && p.City == "Dhaka")
    .OrderBy(p => p.Name).ThenByDescending(p => p.Age)
    .Select(p => new PersonDto {
        PersonName = p.Name,
        PersonCity = p.City,
        Age = p.Age
    }).ToList();

/*
    select Id, Name from people where age >= 30 groupby city, name order by name desc, age asc
 */

var byCityData = people.GroupBy(p => new { p.City, p.Name }).OrderBy(g => g.Key.Name)
    .Select(p => new { 
        Count =  p.Count(), 
        groupKey = p.Key.City
    });

foreach (var group in byCityData)
{
    //Console.WriteLine($"City: {group.groupKey}, Count: {group.Count}");
    //foreach (var person in group)
    //{
    //    Console.WriteLine($"\t{person.Name} - {person.Age}");
    //}
}



//foreach (var person in adultsNameWithDto)
//{
//    Console.WriteLine($"{person.PersonName} {person.PersonCity} {person.Age}");
//}


var customers = new[]
{
    new Customer { Id = 1, Name = "Alice" },
    new Customer { Id = 2, Name = "Bob" },
    new Customer { Id = 3, Name = "Charlie" }
};

var orders = new[]
{
    new Order { Id = 101, CustomerId = 1 },
    new Order { Id = 102, CustomerId = 1 },
    new Order { Id = 103, CustomerId = 2 },
    new Order { Id = 104, CustomerId = 4 }
};


/*
 
 */

// Inner Join
var data = from o in orders
           join c in customers on o.CustomerId equals c.Id
              select new OrderInfoDto
              {
                    OrderId = o.Id,
                    CustomerName = c.Name,
              };

var q = orders.Join(
    customers,               // inner collection
    o => o.CustomerId,       // outer key selector
    c => c.Id,               // inner key selector
    (o, c) => new { o.Id, Customer = c.Name } // result selector
).ToList();

var leftJoin = from c in customers
           join o in orders on c.Id equals o.CustomerId into orderInfo
           from o in orderInfo.DefaultIfEmpty()
               select new { c.Name, OrderId = o?.Id };

var leftWithMethod = customers
    .GroupJoin(
        orders,
        c => c.Id,            // outer key selector
        o => o.CustomerId,    // inner key selector
        (c, ordersGroup) => new { c, ordersGroup } // grouping
    )
    .SelectMany(
        x => x.ordersGroup.DefaultIfEmpty(), // Left join behavior
        (x, o) => new { x.c.Name, OrderId = o?.Id }
    )
    .ToList();


//foreach (var item in leftWithMethod)
//{
//    Console.WriteLine($"{item.Name} => {item.OrderId}");
//}



var distinctCity = people.Select(p => p.City).ToList();

foreach (var item in distinctCity)
{
    //Console.WriteLine($"{item}");
}

var totalAge = people.Sum(p => p.Age);

var avgAge = people.Average(p => p.Age);
//Console.WriteLine($"Total Age: {avgAge}");
//Console.WriteLine(people.Any(p => p.Age >= 18));

// Get: 1
// Data = 1
// 


//var firstPerson = people.Where(p => p.Id == 100).First();
var firstPerson2 = people.Where(p => p.Id == 100).FirstOrDefault();

//if (firstPerson is not null)
//{
//    Console.WriteLine($"{firstPerson.Name}");
//}
//else
//{
//    Console.WriteLine("Not found");
//}

//var lastPerson = people.Where(p => p.Id == 100).Last();
var lastPerson2 = people.Where(p => p.Id == 100).LastOrDefault();


var single = people.Where(p => p.Id == 100).SingleOrDefault();

//Console.WriteLine($"{single?.Name}");

// Pagination
// Page = 1
// Data = 10;
// Skip = Page * Data

var dataset = people.OrderBy(p => p.Id).Skip(2).Take(1).ToList();


foreach (var item in dataset)
{
    Console.WriteLine($"Id = {item.Id} => Name = {item.Name}");
}
















