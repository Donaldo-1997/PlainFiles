using CSVWhitLibrary;
using System.Globalization;

//var list = new List<Person> {
//    new()     {
//        Id = "1",
//        FirstName = "John",
//        LastName = "Doe",
//        Phone = "123-456-7890",
//        City = "New York",
//        Balance = 1000
//    },
//    new()     {
//        Id = "2",
//        FirstName = "Jane",
//        LastName = "Smith",
//        Phone = "987-654-3210",
//        City = "Los Angeles",
//        Balance = 2000
//    },
//    new()     {
//        Id = "3",
//        FirstName = "Alice",
//        LastName = "Johnson",
//        Phone = "555-123-4567",
//        City = "Chicago",
//        Balance = 1500
//    },
//};
var path = "D:\\ITM\\3 SEMESTRE\\Estructura de Datos y Laboratorio\\Pruebas";
var logger = new LogWriter($"{path}\\log.txt");
var helper = new CSVHelperExample();

var usersTxt = File.ReadAllLines($"{path}\\user.txt");
string loggedUser = string.Empty;

var readList = helper.Read($"{path}\\people.csv").ToList();
if(readList.Count() == 0)
{
    helper.Write($"{path}\\people.csv", []);
    readList = helper.Read($"{path}\\people.csv").ToList();
}

using (logger)
{
    /***********************************************************/
    logger.WriteLog("INFO", "Application started");
    /***********************************************************/

    var opc = "0";

    if (Login())
    {
        logger.WriteLog("INFO", $"{loggedUser}: logged in successfully");
        SeparatorString("=");
        Console.WriteLine($"Bienvenido {loggedUser} :)");

        do
        {
            opc = Menu();

            switch (opc)
            {
                case "1":
                    logger.WriteLog("INFO", $"{loggedUser}: requested to show content");
                    ShowContent();
                    break;
                case "2":
                    logger.WriteLog("INFO", $"{loggedUser}: requested to add a person");
                    AddPerson();
                    break;
                case "3":
                    logger.WriteLog("INFO", $"{loggedUser}: requested to edit a person");
                    EditPerson();
                    break;
                case "4":
                    logger.WriteLog("INFO", $"{loggedUser}: requested to delete a person");
                    DeletePerson();
                    break;
                case "5":
                    logger.WriteLog("INFO", $"{loggedUser}: requested to show balance report");
                    ShowBalanceReport();
                    break;
                case "6":
                    logger.WriteLog("INFO", $"{loggedUser}: requested to save changes");
                    SaveChanges();
                    break;
                case "0":
                    SeparatorString("=");
                    logger.WriteLog("INFO", $"{loggedUser}: requested to exit the application");
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    SeparatorString("=");
                    Console.WriteLine("Opción inválida. Intente nuevamente.");
                    continue;
            }
        } while (opc != "0");
        SaveChanges();
    }
}



string Menu()
{
    SeparatorString("=");
    Console.WriteLine("\n1. Mostrar contenido");
    Console.WriteLine("2. Añadir persona");
    Console.WriteLine("3. Editar persona");
    Console.WriteLine("4. Eliminar persona");
    Console.WriteLine("5. Mostrar reporte de balances");
    Console.WriteLine("6. Guardar cambios");
    Console.WriteLine("0. Salir");
    Console.Write("Selecciona una opción: ");

    return Console.ReadLine() ?? "0";
}

void SaveChanges()
{
    helper.Write($"{path}\\people.csv", readList);
    SeparatorString("="); // Repite un string, las veces que quiera
    Console.WriteLine("Cambios guardados satisfactoriamente.");
    logger.WriteLog("INFO", $"{loggedUser}: Saved changes to the CSV file");
}

void ShowContent()
{
    if (readList == null || !readList.Any())
    {
        SeparatorString("=");
        Console.WriteLine("No hay datos para mostrar");
    }

    SeparatorString("=");
    foreach (var person in readList)
    {
        Console.WriteLine(person);
    }
}

void AddPerson()
{
    SeparatorString("=");

    Console.Write("Ingrese ID (Valor númerico): ");
    var id = ValidateId(Console.ReadLine());
    Console.Write("Ingrese nombre: ");
    var firstName = ValidateName(Console.ReadLine());
    Console.Write("Ingrese apellidos: ");
    var lastName = ValidateName(Console.ReadLine());
    Console.Write("Ingrese telefono: ");
    var phone = ValidatePhone(Console.ReadLine());
    Console.Write("Ingrese ciudad: ");
    var city = Console.ReadLine();
    Console.Write("Ingrese balance: ");
    var balance = ValidateBalance(Console.ReadLine());

    var newPerson = new Person
    {
        Id = id,
        FirstName = firstName,
        LastName = lastName,
        Phone = phone,
        City = city,
        Balance = balance
    };

    readList.Add(newPerson);
    SeparatorString("=");

    Console.WriteLine("Persona agregada exitosamente :)");
    logger.WriteLog("INFO", $"{loggedUser}: Added a new person with ID '{id}'");
}

void EditPerson()
{
    SeparatorString("=");

    Console.Write("Ingrese el ID de la persona a editar: ");
    var id = Console.ReadLine();
    var personToEdit = readList.FirstOrDefault(p => p.Id == id);
    if (personToEdit == null)
    {
        SeparatorString("=");
        Console.WriteLine("Persona no encontrada.");
        return;
    }
    Console.Write("Ingrese nombre: ");
    var firstName = Console.ReadLine();
    Console.Write("Ingrese apellidos: ");
    var lastName = Console.ReadLine();
    Console.Write("Ingrese telefono: ");
    var phone = Console.ReadLine();
    Console.Write("Ingrese ciudad: ");
    var city = Console.ReadLine();
    Console.Write("Ingrese balance: ");
    var stringBalance = Console.ReadLine();
    var balance = stringBalance == "" ? personToEdit.Balance : ValidateBalance(stringBalance);

    personToEdit.FirstName = firstName != "" ? firstName : personToEdit.FirstName;
    personToEdit.LastName = lastName != "" ? lastName : personToEdit.LastName;
    personToEdit.Phone = phone != "" ? phone : personToEdit.Phone;
    personToEdit.City = city != "" ? city : personToEdit.City;
    personToEdit.Balance = balance;

    SeparatorString("=");
    Console.WriteLine("Persona editada exitosamente :)");
    logger.WriteLog("INFO", $"{loggedUser}: Edited person with ID '{id}'");
}

string ValidateId(string idInput)
{
    while (string.IsNullOrEmpty(idInput))
    {
        SeparatorString("=");
        Console.Write("Este campo no puede estar vacio: ");
        idInput = Console.ReadLine();
    }

    while (!idInput.All(char.IsDigit))
    {
        SeparatorString("=");
        Console.Write("ID inválido \nIngrese un valor númerico: ");
        idInput = Console.ReadLine();
    }

    var found = readList.FirstOrDefault(p => p.Id == idInput);
    while (found != null)
    {
        SeparatorString("=");
        Console.Write($"El ID '{idInput}' ya existe. \nPor favor ingrese un ID diferente: ");
        idInput = Console.ReadLine();
        found = readList.FirstOrDefault(p => p.Id == idInput);
    }

    return idInput;
}
string ValidateName(string nameInput)
{
    while (string.IsNullOrEmpty(nameInput))
    {
        SeparatorString("=");
        Console.Write("Este campo no puede estar vacio. \nPor favor ingrese un valor: ");
        nameInput = Console.ReadLine();
    }
    return nameInput;
}

string ValidatePhone(string phoneInput)
{
    while (string.IsNullOrEmpty(phoneInput) 
        || !phoneInput.All(char.IsDigit) 
        || phoneInput.Length < 10 
        || phoneInput.Length > 10)
    {
        SeparatorString("=");
        Console.Write("Teléfono inválido.\nPor favor intente nuevamente: ");
        phoneInput = Console.ReadLine();
    }
    return phoneInput;
}
decimal ValidateBalance(string balanceInput) 
{
    var balance = -1m;

    while (!decimal.TryParse(balanceInput, out balance) || balance < 0)
    {
        SeparatorString("=");
        Console.Write("Balance inválido. \nPor favor intente nuevamente: ");
        balanceInput = Console.ReadLine();
    }

    return balance;
}

void DeletePerson()
{
    Console.Write("Ingrese el ID de la persona a eliminar: ");
    var id = Console.ReadLine();
    var personToDelete = readList.FirstOrDefault(p => p.Id == id);
    if (personToDelete == null)
    {
        SeparatorString("="); // Repite un string, las veces que quiera
        Console.WriteLine("¡Persona no encontrada! :(");
        return;
    }
    var person = $"{personToDelete.FirstName} {personToDelete.LastName}";
    Console.WriteLine($"\n¿Está seguro de eliminar a '{person}'? Si (s)/ No (n):");
    var answer = Console.ReadLine();
    
    if(answer.ToLower() == "s")
    {
        readList.RemoveAll(p => p.Id == id);
        SeparatorString("="); // Repite un string, las veces que quiera
        Console.WriteLine($"'{person}' eliminada exitosamente.");
        logger.WriteLog("INFO", $"{loggedUser}: Deleted person with ID '{id}'");
    } else
    {
        SeparatorString("="); // Repite un string, las veces que quiera
        Console.WriteLine($"Operación cancelada.");
        logger.WriteLog("INFO", $"{loggedUser}: Canceled deletion of person with ID '{id}'");
    }

}

void ShowBalanceReport()
{
    string[] cities = [];

    foreach (var person in readList)
    {
        if(!cities.Contains(person.City.ToUpper()))
        {
            cities = cities.Append(person.City.ToUpper()).ToArray();
        }
    }

    SeparatorString("="); // Repite un string, las veces que quiera
    foreach (var city in cities)
    {
        Console.WriteLine($"\nCiudad: {city}\n");
        Console.WriteLine("{0,-5} {1,-10} {2,-10} {3,15}", "ID", "Nombres", "Apellidos", "Saldo");
        Console.WriteLine("{0,-5} {1,-10} {2,-10} {3,15}", "--", "-------", "---------", "-----");

        var totalBalance = 0m;
        foreach (var person in readList.Where(p => p.City.ToUpper() == city))
        {
            Console.WriteLine("{0,-5} {1,-10} {2,-10} {3,15:N1}",
                person.Id, person.FirstName, person.LastName, person.Balance);
            totalBalance += person.Balance;
        }
        Console.WriteLine("{0,43}","----------");
        Console.WriteLine("{0,-20} {1,23}", $"Total: {city}", $"{totalBalance.ToString("N1", CultureInfo.InvariantCulture)}\n");
    }
}

bool Login()
{
    var attempts = 3;
    var login = false;

    while (!login && attempts > 0)
    {
        attempts--;
        SeparatorString("=");
        Console.Write("Ingrese su usuario: ");
        var username = Console.ReadLine();
        Console.Write("Ingrese su contraseña: ");
        var password = Console.ReadLine();

        foreach (var user in usersTxt)
        {
            var parts = user.Split(',');
            var userName = parts[0];
            var passWord = parts[1];
            if (userName.Equals(username) && passWord == password)
            {
                loggedUser = userName;
                login = true;
                break;
            }
        }

        if(!login)
        {
            SeparatorString("=");
            Console.WriteLine("Usuario o contraseña invalida!");
            Console.WriteLine($"Le quedan {attempts} intentos.");
        }
    }

    return login;
}

void SeparatorString(string separator)
{
    Console.WriteLine(string.Concat(Enumerable.Repeat(separator, 100)));
}