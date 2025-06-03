using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTextFile;

class LogWriter : IDisposable
{
    private readonly StreamWriter _streamWriter;

    public LogWriter(string path)
    {
        _streamWriter = new StreamWriter(path, append: true)
        {
            AutoFlush = true
        };
    }

    public void WriteLog(string level, string message)
    {
        var dateTime = DateTime.Now.ToString("s");  // ISO 8601 format
        _streamWriter.WriteLine($"{dateTime} [{level}] {message}");
    }

    public void Dispose()
    {
        _streamWriter?.Dispose();
    }
}
