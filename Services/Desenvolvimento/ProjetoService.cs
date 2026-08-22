using System.Diagnostics;
using Quaq.Repository;
using Quaq.Services.Sistema;
using Spectre.Console;
namespace Quaq.Services.Desenvolvimento;
public class ProjetoService
{
    ProjetosRepositorio repos = new("projetos.json");

    internal void AbrirProjeto()
    {
        string v = BuscarNome();
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

    public void AbrirTerminal()
    {
        string nomeProjeto = BuscarNome();

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
    internal void CodarProjeto()
    {
        string v = BuscarNome();
        string? caminho = repos.ExibirCaminho(v);
        if(caminho is null)
        {
            Console.WriteLine($"Nenhum projeto chamado {v} foi encontrado");
            return;
        }
        Process.Start("code", caminho);
    }


    private string BuscarNome()
    {
        var listaDeProjeto = repos.ExibirTodosProjetos();
        var opcao = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[bold]Selecione uma Projeto:[/]")
                .AddChoices(listaDeProjeto.Select(x => x.Key)));
        return opcao;
    }


    internal void DeletarProjeto()
    {
        string v = BuscarNome();
        repos.DeletarProjeto(v);

    }    
    internal void Exibir()
    {
        var listaDeProjeto = repos.ExibirTodosProjetos();
        List<string> strings = [];
        foreach(var i in listaDeProjeto)
            strings.Add($"# {i.Key}");
        UiService.ListaUi("Projetos", strings.ToArray());

    }

    internal void FazerCommit(string mensagem)
    {
        string v = BuscarNome();
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

}
