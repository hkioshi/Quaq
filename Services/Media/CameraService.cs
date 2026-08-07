using System.Diagnostics;

namespace Quaq.Services.Media;

public class CameraService
{
    public static void AbrirCamera()
    {
        var psi = new ProcessStartInfo
        {
            FileName = "cheese",
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true
        };

        Process.Start(psi);
    }   
}
