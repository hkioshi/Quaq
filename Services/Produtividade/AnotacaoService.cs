using System.Security.Principal;
using Quaq.Repository;
using Quaq.Services.Sistema;

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
        UiService.LinhaUi("Cadernos");
        AnotacaoRepositorio repos = new("anotacoes.json");
        var lista = repos.BuscarTodosCadernos() ?? [];
        lista.ForEach(a => Console.WriteLine($" > {a}"));
    }
}
