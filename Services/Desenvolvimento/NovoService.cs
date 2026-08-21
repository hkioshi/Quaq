using System.Diagnostics;
using Quaq.Repository;
using Quaq.Services.Sistema;
using Spectre.Console;

namespace Quaq.Services.Desenvolvimento;

public class NovoService
{
    private static readonly Dictionary<string, string[]> Linguagens = new()
    {
        { "c#", ["api", "console"] },
        { "python", ["console"] },
        { "rust", ["console"] }
    };

    public static void CriarNovoConsole(string nome, string tipo, string pasta)
    {
        switch (tipo)
        {
            case "c#":
                if (!DependiciaService.VerificarDependencia("dotnet"))
                    return;

                ExecutarProcesso(
                    "dotnet",
                    $"new console -n \"{nome}\"",
                    pasta
                );
                break;

            case "python":
                if (!DependiciaService.VerificarDependencia("python3"))
                    return;

                CriarProjetoPython(nome, pasta);
                break;

            case "rust":
                if (!DependiciaService.VerificarDependencia("cargo"))
                    return;

                ExecutarProcesso(
                    "cargo",
                    $"new \"{nome}\"",
                    pasta
                );
                break;
        }

        AbrirProjeto(Path.Combine(pasta, nome));
    }

    public static void CriarNovaApi(string nome, string tipo, string pasta)
    {
        switch (tipo)
        {
            case "c#":
                if (!DependiciaService.VerificarDependencia("dotnet"))
                    return;

                ExecutarProcesso(
                    "dotnet",
                    $"new webapi -n \"{nome}\"",
                    pasta
                );

                AbrirProjeto(Path.Combine(pasta, nome));
                break;
        }
    }

    private static void CriarProjetoPython(string nome, string pasta)
    {
        string diretorio = Path.Combine(pasta, nome);

        Directory.CreateDirectory(diretorio);

        File.WriteAllText(
            Path.Combine(diretorio, "main.py"),
            ""
        );
    }

    private static void ExecutarProcesso(
        string comando,
        string argumentos,
        string diretorio)
    {
        using var processo = new Process();

        processo.StartInfo = new ProcessStartInfo
        {
            FileName = comando,
            Arguments = argumentos,
            WorkingDirectory = diretorio,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true
        };

        processo.Start();

        string saida = processo.StandardOutput.ReadToEnd();
        string erro = processo.StandardError.ReadToEnd();

        processo.WaitForExit();

        if (processo.ExitCode == 0)
        {
            if (!string.IsNullOrWhiteSpace(saida))
                UiService.OkUi(saida);
        }
        else
        {
            UiService.ErroUi(erro);
        }
    }

    private static void AbrirProjeto(string diretorio)
    {
        if (!Directory.Exists(diretorio))
            return;

        var psi = new ProcessStartInfo
        {
            FileName = "code",
            UseShellExecute = false
        };

        psi.ArgumentList.Add(diretorio);

        try
        {
            Process.Start(psi);
        }
        catch (Exception ex)
        {
            UiService.ErroUi(
                $"Não foi possível abrir o projeto no VS Code: {ex.Message}"
            );
        }
    }

    internal static void NovoMenu()
    {
        DiretorioRepository repos = new();

        var pastas = repos.ListarRepositorios();

        pastas.Add("Nova Pasta");

        var opcao = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[bold]Selecione uma Pasta:[/]")
                .AddChoices(pastas)
        );

        string pasta;

        if (opcao == "Nova Pasta")
        {
            var nomeDiretorio = AnsiConsole.Prompt(
                new TextPrompt<string>("Nome do novo diretório:")
                    .DefaultValue("Meus_Projetos")
            );

            pasta = repos.NovaPasta(nomeDiretorio);
        }
        else
        {
            pasta = repos.AcharPasta(opcao);
        }

        var linguagem = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[bold]Selecione uma linguagem:[/]")
                .AddChoices(Linguagens.Keys)
        );

        var tipo = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[bold]Selecione o tipo de projeto:[/]")
                .AddChoices(Linguagens[linguagem])
        );

        var nomeProjeto = AnsiConsole.Prompt(
            new TextPrompt<string>("Nome do novo projeto:")
                .DefaultValue("ProjetoNovo")
        );

        switch (tipo)
        {
            case "api":
                CriarNovaApi(
                    nomeProjeto,
                    linguagem,
                    pasta
                );
                break;

            case "console":
                CriarNovoConsole(
                    nomeProjeto,
                    linguagem,
                    pasta
                );
                break;
        }
    }
}