using System.Diagnostics;
using Quaq.Services.Sistema;

namespace Quaq.Services.Desenvolvimento;
public class RunService
{
    public static void Run(string[] args) =>
        BuscarLp(
            Directory.GetFiles(Directory.GetCurrentDirectory()),
            args);
    
    public static void Run(string arquivo, string[] args) =>
        BuscarLp(
            Directory.GetFiles(arquivo),
            args);
    private static void BuscarLp(string[] arquivos,string[] args)
    {
        foreach (string arquivo in arquivos)
        {
            if(arquivo.Contains(".csproj"))
            {
                 RunDotnet(args);
                    return;
            }
            if(arquivo.Contains("main.py"))
            {
                RunPy(args);
                    return;
            }
            if(arquivo.Contains("Cargo.toml"))
            {
                RunRust(args);
                    return;
            } 
            if(arquivo.Contains("package.json"))
            {
                RunReact(args);
                    return;
            } 
            
        }
        UiService.AvisoUi("Nenhum arquivo de projeto encontrado");

    }
    private static void RunReact(string[] args)
    {
        if(!DependiciaService.VerificarDependencia("npm")) return;
        string comando = args.Length == 0 ? "run dev" : $"run dev -- {string.Join(" ", args)}";

        var processo = Process.Start(new ProcessStartInfo
        {
            FileName = "npm",
            Arguments = comando,
            WorkingDirectory = Directory.GetCurrentDirectory(),
            UseShellExecute = false
        });
        processo?.WaitForExit();
    }

    private static void RunRust(string[] args)
    {
        if(!DependiciaService.VerificarDependencia("cargo")) return;
        string comando = args.Length == 0 ? "run" : $"run -- {string.Join(" ", args)}";

        var processo = Process.Start(new ProcessStartInfo
        {
            FileName = "cargo",
            Arguments = comando,
            WorkingDirectory = Directory.GetCurrentDirectory(),
            UseShellExecute = false
        });
        processo?.WaitForExit();
    }

    private static void RunPy(string[] args)
    {
        if(!DependiciaService.VerificarDependencia("python3")) return;
        string comando = args.Length == 0 ? "main.py" : $"main.py {string.Join(" ", args)}";

        var processo = Process.Start(new ProcessStartInfo
        {
            FileName = "python3",
            Arguments = comando,
            WorkingDirectory = Directory.GetCurrentDirectory(),
            UseShellExecute = false
        });
        processo?.WaitForExit();
    }

    public static void RunDotnet(string[] args)
    {
        if(!DependiciaService.VerificarDependencia("dotnet")) return;

        string comando = args.Length == 0 ? "run" : $"run -- {string.Join(" ", args)}";

        var processo = Process.Start(new ProcessStartInfo
        {
            FileName = "dotnet",
            Arguments = comando,
            WorkingDirectory = Directory.GetCurrentDirectory(),
            UseShellExecute = false
        });

        processo?.WaitForExit();
    }
}
