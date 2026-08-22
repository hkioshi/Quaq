using System.CommandLine;
using Quaq.Interfaces;
using Quaq.Services.Produtividade;

namespace Quaq.Commands;

public class CaluladoraCommand : IComando
{
    public Command Get()
    {
       var calculoCmd = new Command("calcular", "Calculadora");

        calculoCmd.SetAction(parseResult =>
        {
            CalculadoraService.Calcular();
            
        });

        return calculoCmd;
    }
}
