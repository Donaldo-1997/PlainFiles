using BasicTextFile;
using System.ComponentModel.Design;

var textFile = new SimpleTextFile("C:\\Users\\donal\\OneDrive\\Escritorio\\example.txt");

textFile.WriteLines(["Hello, World!", "This is a simple text file."]);
var lines = textFile.ReadLines();

var opc = "0";

do
{
    opc = Menu();

    switch (opc)
    {
        case "1":
            if(lines.Length == 0)
            {
                Console.WriteLine("The file is empty.");
                break;
            }
            Console.WriteLine("Content of the file:");
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
            break;
        case "2":
            Console.Write("Enter a new line to add: ");
            var newLine = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newLine))
            {
                var updatedLines = lines.Append(newLine).ToArray();
                textFile.WriteLines(updatedLines);
                lines = updatedLines;
                Console.WriteLine("Line added successfully.");
            }
            break;
        case "3":
            Console.Write("Enter the line to remove: ");
            var lineToRemove = Console.ReadLine();
            if (!string.IsNullOrEmpty(lineToRemove))
            {
                lines = lines.Where(line => line != lineToRemove).ToArray();

            }
            break;
        case "4":
            saveChanges();
            break;
        case "0":
            break;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}
while (opc != "0");


saveChanges();

void saveChanges()
{
    Console.WriteLine("Saving chenges...");
    textFile.WriteLines(lines);
    Console.WriteLine("Changes saved successfully.");
}

string Menu()
{
    Console.WriteLine("=============================");
    Console.WriteLine("1. Show content  ");
    Console.WriteLine("2. Add Line");
    Console.WriteLine("3. Remove Line");
    Console.WriteLine("4. Save changes");
    Console.WriteLine("0. Exit");
    Console.Write("Select an option: ");
    return Console.ReadLine() ?? "0";
}