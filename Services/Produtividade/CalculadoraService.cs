
using NCalc;
using Quaq.Services.Sistema;
using Spectre.Console;

namespace Quaq.Services.Produtividade;
public class CalculadoraService
{
    public static void Calcular()
    {
        var calculo = AnsiConsole.Prompt(
                new TextPrompt<string>("Calculo")
                    .DefaultValue(""));

        if(calculo == "")
        {
            UiService.ErroUi("Calculo vazio");
            return;
        }

        calculo.Replace(" ", "");
        try
        {
            Expression expr = new(string.Join("",calculo));

            object? resultado = expr.Evaluate();
            if(resultado is not null)
                UiService.LinhaUi($"resultado - {resultado}"); 
        }
        catch
        {
            UiService.ErroUi("Não é uma conta!");
        }

    }
}
