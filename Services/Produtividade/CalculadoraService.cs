
using NCalc;
using Quaq.Services.Sistema;

namespace Quaq.Services.Produtividade;
public class CalculadoraService
{
    public static void Calcular(string calculo)
    {
        Expression expr = new(calculo);

        object? resultado = expr.Evaluate();
        if(resultado is not null)
            UiService.LinhaUi("resultado",$"{resultado}"); 

    }
}
