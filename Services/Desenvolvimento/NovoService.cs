using System.Diagnostics;
using Quaq.Services.Sistema;

namespace Quaq.Services.Desenvolvimento;

public class NovoService
{
    private static void AbrirProjeto(string Arquivo) =>
        Process.Start("code", Arquivo);
    private static bool VerificarSeExiste(string Arquivo) =>
        Directory.Exists(Arquivo);
    
    private static string? EncontrarCaminho(string nome, string pasta)
    {
         var Arquivo = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            "repos",
            pasta,
            nome);

        if(VerificarSeExiste(Arquivo))
        {
           UiService.AvisoUi("Projeto Ja existe");
           AbrirProjeto(Arquivo);
           return null;
        }

        return Arquivo;
    } 
    public static void CriarNovo(string nome, string tipo, string pasta)
    {
        var Arquivo = EncontrarCaminho(nome, pasta) ;
        if (Arquivo is null) return;
        if(!DependiciaService.VerificarDependencia("dotnet")) return;


        Process processo = new Process();

        processo.StartInfo.FileName = "dotnet";
        processo.StartInfo.Arguments = $"new {tipo} -n \"{nome}\"";
        processo.StartInfo.WorkingDirectory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            "repos",
            pasta);

        processo.StartInfo.UseShellExecute = false;
        processo.StartInfo.RedirectStandardOutput = true;
        processo.StartInfo.RedirectStandardError = true;

        processo.Start();

        string saida = processo.StandardOutput.ReadToEnd();
        string erro = processo.StandardError.ReadToEnd();

        processo.WaitForExit();

        UiService.OkUi(saida);
        AbrirProjeto(Arquivo);


       if (!string.IsNullOrEmpty(erro))
            UiService.ErroUi(erro);
    }

    internal static void CriarNovoPy(string nome, string pasta)
    {
        var Arquivo = EncontrarCaminho(nome, pasta) ;
        if (Arquivo is null) return;

        Directory.CreateDirectory(Arquivo);
        File.Create(Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            "repos",
            pasta,
            nome,
            "main.py"));

        AbrirProjeto(Arquivo);
    }

    internal static void CriarNovoRust(string nome, string pasta)
    {
        var Arquivo = EncontrarCaminho(nome, pasta) ;
        if (Arquivo is null) return;
        if(!DependiciaService.VerificarDependencia("cargo")) return;

        Process processo = new Process();

        processo.StartInfo.FileName = "cargo";
        processo.StartInfo.Arguments = $"new \"{nome}\"";
        processo.StartInfo.WorkingDirectory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            "repos",
            pasta);

        processo.StartInfo.UseShellExecute = false;
        processo.StartInfo.RedirectStandardOutput = true;
        processo.StartInfo.RedirectStandardError = true;

        processo.Start();

        string saida = processo.StandardOutput.ReadToEnd();
        string erro = processo.StandardError.ReadToEnd();

        processo.WaitForExit();

        UiService.OkUi(saida);
        AbrirProjeto(Arquivo);


       if (!string.IsNullOrEmpty(erro))
            UiService.ErroUi(erro);
    }
}
