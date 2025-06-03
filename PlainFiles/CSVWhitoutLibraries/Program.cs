using CSVWhitoutLibraries;

var people = new List<string[]>
{
    new[] { "Id", "Name", "Age"},
    new[] { "Id", "Alice", "30"},
    new[] { "Id", "Bob", "25"},
    new[] { "Id", "Pedro", "45"},
};

var manualCSV = new ManualCsvHelper();
manualCSV.WriteCSV("D:\\ITM\\3 SEMESTRE\\Estructura de Datos y Laboratorio\\people.csv", people);

var readPeople = manualCSV.ReadCSV("D:\\ITM\\3 SEMESTRE\\Estructura de Datos y Laboratorio\\people.csv");
foreach (var person in readPeople)
{
    Console.WriteLine(string.Join(", ", person));
}

