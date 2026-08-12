
using System.Diagnostics;
using Quaq.Services.Sistema;

namespace Quaq.Services.Diversao;

public class JogoService
{
    public static void Abrir(string file, string args)
    {
         var processo = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = file,
                Arguments = args,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            }
        };
        UiService.AvisoUi("Abrindo...");
        processo.Start();

        _ = processo.StandardOutput.ReadToEndAsync();
        _ = processo.StandardError.ReadToEndAsync();
    }
}
