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
        return $"{"ID".PadRight(10)}: {Id}" +
            $"\n{"Nombres".PadRight(10)}: {FirstName} {LastName}" +
            $"\n{"Teléfono".PadRight(10)}: {Phone}" +
            $"\n{"Ciudad".PadRight(10)}: {City}" +
            $"\n{"Balance".PadRight(10)}: {Balance:C2}\n";
    }
}
