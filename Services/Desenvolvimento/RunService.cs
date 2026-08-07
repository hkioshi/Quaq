using System.Diagnostics;

namespace Quaq.Services.Desenvolvimento;
public class RunService
{
    public static void Run()
    {
        string[] arquivos = Directory.GetFiles(Directory.GetCurrentDirectory());

        foreach (string arquivo in arquivos)
        {
            Console.WriteLine(arquivo);
            if(arquivo.Contains(".csproj"))
            {
                RunDotnet();
            }
        }
        Console.WriteLine("Projeto Salvo");

        
    }
    public static void RunDotnet()
    {
        

        Process.Start(new ProcessStartInfo
        {
            FileName = "dotnet",
            Arguments = "run",
            WorkingDirectory = Directory.GetCurrentDirectory(),
            UseShellExecute = false
        });
    }
}
