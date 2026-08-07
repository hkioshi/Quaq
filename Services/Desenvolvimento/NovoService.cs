using System.Diagnostics;

namespace Quaq.Services.Desenvolvimento;

public class NovoService
{
    internal static void CriarNovoPessoalApi(string pessoal)
    {
        var Arquivo = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            "repos",
            "Projetos_Pessoais",
            pessoal);

        if(VerificarSeExiste(Arquivo))
        {
           Console.WriteLine("Projeto Ja existe");
           AbrirProjeto(Arquivo);
           return;
        }

        Process processo = new Process();

        processo.StartInfo.FileName = "dotnet";
        processo.StartInfo.Arguments = $"new webapi -n \"{pessoal}\"";
        processo.StartInfo.WorkingDirectory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            "repos",
            "Projetos_Pessoais");
        processo.StartInfo.UseShellExecute = false;
        processo.StartInfo.RedirectStandardOutput = true;
        processo.StartInfo.RedirectStandardError = true;

        processo.Start();

        string saida = processo.StandardOutput.ReadToEnd();
        string erro = processo.StandardError.ReadToEnd();

        processo.WaitForExit();

        Console.WriteLine(saida);
        AbrirProjeto(Arquivo);

        if (!string.IsNullOrEmpty(erro))
        {
            Console.WriteLine("Erro:");
            Console.WriteLine(erro);
        }
        
    }

    private static void AbrirProjeto(string Arquivo)
    {
        Process.Start("code", Arquivo);
    }

    private static bool VerificarSeExiste(string Arquivo)
    {
        return Directory.Exists(Arquivo);
    }

    internal static void CriarNovoPessoalTerminal(string pessoal)
    {
         var Arquivo = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            "repos",
            "Projetos_Pessoais",
            pessoal);

        if(VerificarSeExiste(Arquivo))
        {
           Console.WriteLine("Projeto Ja existe");
           AbrirProjeto(Arquivo);
           return;
        }

        Process processo = new Process();

        processo.StartInfo.FileName = "dotnet";
        processo.StartInfo.Arguments = $"new console -n \"{pessoal}\"";
        processo.StartInfo.WorkingDirectory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            "repos",
            "Projetos_Pessoais");

        processo.StartInfo.UseShellExecute = false;
        processo.StartInfo.RedirectStandardOutput = true;
        processo.StartInfo.RedirectStandardError = true;

        processo.Start();

        string saida = processo.StandardOutput.ReadToEnd();
        string erro = processo.StandardError.ReadToEnd();

        processo.WaitForExit();

        Console.WriteLine(saida);
        AbrirProjeto(Arquivo);


        if (!string.IsNullOrEmpty(erro))
        {
            Console.WriteLine("Erro:");
            Console.WriteLine(erro);
        }
    }

    internal static void CriarNovoTesteApi(string teste)
    {
         var Arquivo = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            "repos",
            "Projetos_Testes",
            teste);

        if(VerificarSeExiste(Arquivo))
        {
           Console.WriteLine("Projeto Ja existe");
           AbrirProjeto(Arquivo);
           return;
        }

        Process processo = new Process();

        processo.StartInfo.FileName = "dotnet";
        processo.StartInfo.Arguments = $"new webapi -n \"{teste}\"";
        processo.StartInfo.WorkingDirectory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            "repos",
            "Projetos_Testes");
        processo.StartInfo.UseShellExecute = false;
        processo.StartInfo.RedirectStandardOutput = true;
        processo.StartInfo.RedirectStandardError = true;

        processo.Start();

        string saida = processo.StandardOutput.ReadToEnd();
        string erro = processo.StandardError.ReadToEnd();

        processo.WaitForExit();

        Console.WriteLine(saida);
        AbrirProjeto(Arquivo);

        if (!string.IsNullOrEmpty(erro))
        {
            Console.WriteLine("Erro:");
            Console.WriteLine(erro);
        }
    }

    internal static void CriarNovoTesteTerminal(string teste)
    {
         var Arquivo = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            "repos",
            "Projetos_Testes",
            teste);

        if(VerificarSeExiste(Arquivo))
        {
           Console.WriteLine("Projeto Ja existe");
           AbrirProjeto(Arquivo);
           return;
        }

    

        Process processo = new Process();

        processo.StartInfo.FileName = "dotnet";
        processo.StartInfo.Arguments = $"new console -n \"{teste}\"";
        processo.StartInfo.WorkingDirectory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            "repos",
            "Projetos_Testes");
        processo.StartInfo.UseShellExecute = false;
        processo.StartInfo.RedirectStandardOutput = true;
        processo.StartInfo.RedirectStandardError = true;

        processo.Start();

        string saida = processo.StandardOutput.ReadToEnd();
        string erro = processo.StandardError.ReadToEnd();

        processo.WaitForExit();

        Console.WriteLine(saida);
        AbrirProjeto(Arquivo);

        if (!string.IsNullOrEmpty(erro))
        {
            Console.WriteLine("Erro:");
            Console.WriteLine(erro);
        }
    }
}
