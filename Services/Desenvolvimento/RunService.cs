using System.Diagnostics;

namespace Quaq.Services.Desenvolvimento;
public class RunService
{
    public static void Run()
    {
        string[] arquivos = Directory.GetFiles(Directory.GetCurrentDirectory());

        foreach (string arquivo in arquivos)
        {
            if(arquivo.Contains(".csproj"))
            {
                RunDotnet();
            }
        }

        
    }
    public static void RunDotnet()
    {
        
        var processo = Process.Start(new ProcessStartInfo
        {
            FileName = "dotnet",
            Arguments = "run",
            WorkingDirectory = Directory.GetCurrentDirectory(),
            UseShellExecute = false
        });

        processo?.WaitForExit();
    }
}
