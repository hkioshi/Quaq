using System.Diagnostics;
using Quaq.Services.Sistema;

namespace Quaq.Services.Media;

public class CameraService
{
    public static void AbrirCamera()
    {
        UiService.LinhaUi("Câmera","Abrindo câmera...");
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
