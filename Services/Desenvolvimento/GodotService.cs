using System.Diagnostics;
using Quaq.Services.Sistema;

namespace Quaq.Services.Desenvolvimento;
public class GodotService 
{

    public static void AbrirGodot()
    {
        var psi = new ProcessStartInfo
        {
            FileName = "godot",
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true
        };
        UiService.AvisoUi("Abrindo o Godot...");
        Process.Start(psi);

    }
    
}
