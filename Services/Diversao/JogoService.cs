
using System.Diagnostics;

namespace Quaq.Services.Diversao;

public class JogoService
{
    public static void AbrirAzahar()
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = "flatpak",
            Arguments = "run org.azahar_emu.Azahar",
            UseShellExecute = false
        });
    }
    public static void AbrirStardew()
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = "steam",
            Arguments = "steam://rungameid/413150",
            UseShellExecute = false
        });
    }

    public static void AbrirModrinth()
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = "flatpak",
            Arguments = "run com.modrinth.ModrinthApp",
            UseShellExecute = false
        });
    }
}
