using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVWhitLibrary;

class Person
{
    public string Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string City { get; set; } = null!;
    public decimal Balance { get; set; }

    public override string ToString()
    {
        return $"ID:{Id,20}" +
            $"\nNombres: {FirstName,20} {LastName}" +
            $"\nTeléfono: {Phone,20}" +
            $"\nCiudad: {City,20}" +
            $"\nBalance: {Balance,20:C2}\n";
    }
}
