using System.Diagnostics;
namespace Quaq.Services.Internet;

public class NavegacaoService
{
    public static void Navegar()
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = "brave-browser",
            Arguments = "--incognito https://www.google.com",
            UseShellExecute = true
        });
    }

    public static void Navegar(string s)
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = "brave-browser",
            Arguments = $"https://{s}",
            UseShellExecute = true
        });
    }

    public static void NavegarAnnon()
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = "brave-browser",
            Arguments = "--incognito https://www.google.com",
            UseShellExecute = true
        });
    }

    public static void NavegarAnnon(string s)
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = "brave-browser",
            Arguments = $"--incognito https://{s}",
            UseShellExecute = true
        });
    }
}
