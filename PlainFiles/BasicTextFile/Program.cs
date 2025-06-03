using BasicTextFile;
using System.ComponentModel.Design;

var textFile = new SimpleTextFile("D:\\ITM\\3 SEMESTRE\\Estructura de Datos y Laboratorio\\example.txt");
var lines = textFile.ReadLines();


using(var logger = new LogWriter("D:\\ITM\\3 SEMESTRE\\Estructura de Datos y Laboratorio\\log.txt"))
{
    /***********************************************************/
    logger.WriteLog("INFO", "Aplication started");
    /***********************************************************/

    var opc = "0";

    do
    {
        opc = Menu();

        switch (opc)
        {
            case "1":
                /***********************************************************/
                logger.WriteLog("INFO", "Showing content of the file.");
                /***********************************************************/

                if (lines.Length == 0)
                {
                    /***********************************************************/
                    logger.WriteLog("ERROR", "The file is empty.");
                    /***********************************************************/
                    Console.WriteLine("The file is empty.");
                    break;
                }
                Console.WriteLine("=============================");
                foreach (var line in lines)
                {
                    Console.WriteLine(line);
                }
                break;
            case "2":
                /***********************************************************/
                logger.WriteLog("INFO", "Adding a new line to the file.");
                /***********************************************************/

                Console.Write("Enter a new line to add: ");
                var newLine = Console.ReadLine();
                if (!string.IsNullOrEmpty(newLine))
                {
                    lines = lines.Append(newLine).ToArray();
                }
                break;
            case "3":
                /***********************************************************/
                logger.WriteLog("INFO", "Removing a line from the file.");
                /***********************************************************/

                Console.Write("Enter the line to remove: ");
                var lineToRemove = Console.ReadLine();
                if (!string.IsNullOrEmpty(lineToRemove))
                {
                    lines = lines.Where(line => line != lineToRemove).ToArray();
                }
                break;
            case "4":
                /***********************************************************/
                logger.WriteLog("INFO", "Saving changes to the file.");
                /***********************************************************/
                saveChanges();
                break;
            case "0":
                /***********************************************************/
                logger.WriteLog("INFO", "Exiting the application.");
                /***********************************************************/
                break;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }
    while (opc != "0");
    /***********************************************************/
    logger.WriteLog("INFO", "Application ended.");
    /***********************************************************/

    saveChanges();
}

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