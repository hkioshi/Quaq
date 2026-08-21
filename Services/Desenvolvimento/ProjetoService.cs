using System.Diagnostics;
using Quaq.Repository;
using Quaq.Services.Sistema;
using Spectre.Console;
namespace Quaq.Services.Desenvolvimento;
public class ProjetoService
{
    ProjetosRepositorio repos = new("projetos.json");

    internal void AbrirProjeto(string v)
    {
        string? caminho = repos.ExibirCaminho(v);
        if(caminho is null)
        {
            Console.WriteLine($"Nenhum projeto chamado {v} foi encontrado");
            return;
        }
        Process.Start(new ProcessStartInfo
        {
            FileName = "xdg-open",
            Arguments = $"\"{caminho}\"",
            UseShellExecute = true
        });
    }

    public void AbrirTerminal(string nomeProjeto)
    {

        string? caminho = repos.ExibirCaminho(nomeProjeto);

        if (caminho is null)
        {
            Console.WriteLine($"Nenhum projeto chamado '{nomeProjeto}' foi encontrado.");
            return;
        }

        var psi = new ProcessStartInfo
        {
            FileName = "gnome-terminal",
            Arguments = $"--working-directory=\"{caminho}\"",
            UseShellExecute = true
        };

        Process.Start(psi);
    }

    internal void CodarProjeto(string v)
    {
        string? caminho = repos.ExibirCaminho(v);
        if(caminho is null)
        {
            Console.WriteLine($"Nenhum projeto chamado {v} foi encontrado");
            return;
        }

        Console.WriteLine(caminho);
        Process.Start("code", caminho);
    }

    internal void DeletarProjeto(string v) =>
        repos.DeletarProjeto(v);
    
    internal void Exibir()
    {
        var listaDeProjeto = repos.ExibirTodosProjetos();
        List<string> strings = [];
        foreach(var i in listaDeProjeto)
            strings.Add($"# {i.Key}");
        UiService.ListaUi("Projetos", strings.ToArray());

    }

    internal void FazerCommit(string v, string mensagem)
    {
        string? caminho = repos.ExibirCaminho(v);
        if (caminho is not null)
        {
         
            ProcessStartInfo psi = new()
            {
                FileName = "bash",
                Arguments = $"-c \"cd {caminho} && git add . && git commit -m '{mensagem}' && git push\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false
            };

            using Process p = Process.Start(psi)!;

            Console.WriteLine(p.StandardOutput.ReadToEnd());
            Console.WriteLine(p.StandardError.ReadToEnd());

            p.WaitForExit();
        }
    }

    internal void SalvarProjeto(string v)
    {
        repos.SalvarProjeto(v, Directory.GetCurrentDirectory());
        UiService.OkUi("Projeto Salvo");
    }

    public void Run(string nome, string[] args)
    {
        string? caminho = repos.ExibirCaminho(nome);
        if (caminho is not null)
            RunService.Run(caminho, args);
        
    }

    internal void ProjMenu()
    {
        var listaDeProjeto = repos.ExibirTodosProjetos();
        var opcao = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[bold]Selecione uma Projeto:[/]")
                .AddChoices(listaDeProjeto.Select(x => x.Key))
        );
        var acao = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title($"[bold]O que gostaria de fazer com [/][blue]{opcao}[/]")
                .AddChoices(
                    "Abrir no gerenciador de arquivos",
                    "Abrir no VsCode",
                    "Deletar projeto",
                    "Abrir no terminal",
                    "Fazer commit do projeto"
                )
        );
        switch (acao)
        {
            case "Abrir no gerenciador de arquivos":
                AbrirProjeto(opcao);
                break;
            case "Abrir no VsCode":
                CodarProjeto(opcao);
                break;
            case "Deletar projeto":
                DeletarProjeto(opcao);
                break;
            case "Abrir no terminal":
                AbrirTerminal(opcao);
                break;
            case "Fazer commit do projeto":
                var mensagem = AnsiConsole.Prompt(
                new TextPrompt<string>("Mensagem do commit")
                    .DefaultValue("Novo Commit"));
                FazerCommit(opcao, mensagem);
                break;
        }
        
    }
}
