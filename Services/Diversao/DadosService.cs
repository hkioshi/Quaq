using Quaq.Services.Sistema;
using Spectre.Console;
namespace Quaq.Services.Diversao;
public class DadosService
{
    public static void DadoMenu()
    {
            var opcao = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[bold]Selecione um dado:[/]")
                .AddChoices(
                    "d4",
                    "d6",
                    "d8", 
                    "d10",
                    "d12",
                    "d20" 
                ));

            int qtd = AnsiConsole.Ask<int>("Quantos dados?: ");
            switch (opcao)
            {
                case "d4":
                    RolarDado(4, qtd);
                    break;
                case "d6":
                    RolarDado(6, qtd);
                    break;
                case "d8":
                    RolarDado(8, qtd);
                    break;
                case "d10":
                    RolarDado(10, qtd);
                    break;
                case "d12":
                    RolarDado(12, qtd);
                    break;
                case "d20":
                    RolarDado(20, qtd);
                    break;
            }
            
            
    }

    public static void RolarDado(int lados, int qtd)
    {   List<int> results = [];
        for(int i = 0; i < qtd; i++)
        {
            results.Add(
                new Random()
                .Next(1,lados+1));

        }
        UiService.ListaUi("Resultados",
        [
           string.Join(" | " , results) ,
           $"Total: {results.Sum()}"
        ]);
    }
        
    public static void RolarDado(int lados) =>
        UiService.LinhaUi(
            "Dados",
            $" Resultado: {new Random()
                .Next(1,lados+1)}");
}
