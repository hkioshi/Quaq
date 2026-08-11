using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quaq.Services.Sistema;

public class LogService
{
    public static void Logs()
    {
        var caminho = Path.Combine(
        AppContext.BaseDirectory,
        "devlog.txt");

        Console.WriteLine(File.ReadAllText(caminho));
    }
}
