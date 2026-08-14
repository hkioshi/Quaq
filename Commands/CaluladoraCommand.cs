using System.CommandLine;
using Quaq.Interfaces;
using Quaq.Services.Produtividade;

namespace Quaq.Commands;

public class CaluladoraCommand : IComando
{
    public Command Get()
    {
       var calculoCmd = new Command("calculo", "Calculadora");

        var contaArg = new Argument<string[]>("conta")
        {
            Description = "Conta a ser calculada"
        };

        calculoCmd.Add(contaArg);

        calculoCmd.SetAction(parseResult =>
        {
            CalculadoraService.Calcular(parseResult.GetValue(contaArg)!);
            
        });

        return calculoCmd;
    }
}
