using Quaq.Repository;
using Quaq.Services.Sistema;
using Spectre.Console;

namespace Quaq.Services.Produtividade;

public class AnotacaoService
{

    internal static void DeletarAnotacao()
    {
        AnotacaoRepositorio repos = new("anotacoes.json");

        var cadernos = repos.BuscarTodosCadernos();
            var opcao = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[bold]Selecione um Caderno:[/]")
                .AddChoices(cadernos));
        
        
            repos.Remover(opcao);
            return;
        
        
        
    }
    internal static void IniciarAnotacao(string nomeCaderno)
    {
        AnotacaoRepositorio repos = new("anotacoes.json");
        List<string> caderno = repos.BuscarCaderno(nomeCaderno) ?? [];
        List<string> ann = [];

        Console.CancelKeyPress += (sender, e) =>
        {
            if (ann.Count > 0)
            {
                Console.WriteLine("\nAnotações salvas.");
                repos.SalvarAnotacoes(nomeCaderno, ann);
            }
        };

        while(true)
        {
            Console.Clear();
            UiService.LinhaUi("Anotação",$"Caderno {nomeCaderno}");
            caderno.ForEach(a => Console.WriteLine($"# {a}"));
            ann.ForEach(a => Console.WriteLine($"# {a}"));
            Console.Write("> ");
            
            var texto = Console.ReadLine();
            if(texto is not null)
            {
                ann.Add(texto);
            }
        }
    }

    internal static void ListarCadernos()
    {
        AnotacaoRepositorio repos = new("anotacoes.json");

        var cadernos = repos.BuscarTodosCadernos();
        cadernos.Add("[green]Novo Caderno[/]");
            var opcao = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[bold]Selecione um Caderno:[/]")
                .AddChoices(cadernos));
        
        if(!opcao.Equals("[green]Novo Caderno[/]"))
        {
            IniciarAnotacao(opcao);
            return;
        }
            
        var caderno = AnsiConsole.Prompt(
                new TextPrompt<string>("Nome do caderno")
                    .DefaultValue("Caderno"));
        IniciarAnotacao(caderno);
    }
}
