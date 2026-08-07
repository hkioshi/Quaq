using System.Diagnostics;

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
        Process.Start(psi);

    }
    
}
