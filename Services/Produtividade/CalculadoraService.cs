
using NCalc;

namespace Quaq.Services.Produtividade;
public class CalculadoraService
{
    public static void Calcular(string calculo)
    {
        Expression expr = new(calculo);

        var resultado = expr.Evaluate();

        Console.WriteLine(resultado); 
    }
}
