using System.Diagnostics;
using Quaq.Services.Sistema;
namespace Quaq.Services.Internet;

public class NavegacaoService
{
    private static void nav(string file, string args)
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
    public static void Navegar() =>
        nav("brave-browser","https://www.google.com");
    
    public static void Navegar(string s)=>
        nav("brave-browser",$"https://{s}");
    
    public static void NavegarAnnon()=>
        nav("brave-browser","--incognito https://www.google.com");

    public static void NavegarAnnon(string s)=>
        nav("brave-browser",$"--incognito https://{s}");
}
