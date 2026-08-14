
using NCalc;
using Quaq.Services.Sistema;

namespace Quaq.Services.Produtividade;
public class CalculadoraService
{
    public static void Calcular(string[] calculo)
    {
        if(calculo.Length == 0 )
        {
            return;
        }
        Expression expr = new(string.Join("",calculo));

        object? resultado = expr.Evaluate();
        if(resultado is not null)
            UiService.LinhaUi("resultado",$"{resultado}"); 

    }
}
