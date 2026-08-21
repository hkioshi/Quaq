using Quaq.Repository;
using Quaq.Services.Sistema;
using Spectre.Console;

namespace Quaq.Services.Produtividade;

public class AnotacaoService
{

    
    internal static void IniciarAnotacao(string nomeCaderno)
    {
        AnotacaoRepositorio repos = new("anotacoes.json");
        List<string> caderno = repos.BuscarCaderno(nomeCaderno) ?? [];
        List<string> ann = [];

        Console.CancelKeyPress += (sender, e) =>
        {
            if (ann.Count > 0)
            {
                repos.SalvarAnotacoes(nomeCaderno, ann);
                Console.WriteLine("\nAnotações salvas.");
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
            var opcao = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[bold]Selecione um Caderno:[/]")
                .AddChoices(cadernos));
            
        IniciarAnotacao(opcao);
        
    }
}
