using CSVWhitLibrary;

var list = new List<Person> { 
    new() { Id = 1, Name = "John Doe", Age = "30" },
    new() { Id = 2, Name = "Jane Smith", Age = "25" },
    new() { Id = 3, Name = "Sam Brown", Age = "40" },
    new() { Id = 4, Name = "Alice Johnson", Age = "28" }
};

var helper = new CSVHelperExample();
helper.Write("D:\\ITM\\3 SEMESTRE\\Estructura de Datos y Laboratorio\\people.csv", list);

var readList = helper.Read("D:\\ITM\\3 SEMESTRE\\Estructura de Datos y Laboratorio\\people.csv");

foreach (var person in readList)
{
    Console.WriteLine($"Id: {person.Id}, Name: {person.Name}, Age: {person.Age}");
} 