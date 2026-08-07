using System.Diagnostics;
namespace Quaq.Services.Media;
public class FalaService
{
    public static void Falar(string texto)
    {
        Process.Start(new ProcessStartInfo
            {
                FileName = "espeak-ng",
                Arguments = $"-v pt-br \"{texto}\"",
                UseShellExecute = false
            });
    }
}
