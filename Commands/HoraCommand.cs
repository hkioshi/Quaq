using System.CommandLine;
using Quaq.Interfaces;
using Quaq.Services.Internet;

namespace Quaq.Commands;

public class HoraCommand : IComando
{
    public Command Get()
    {

        var origemArg = new Argument<string>("origem");
        var destinoArg = new Argument<string>("destino");
        var horaArg = new Argument<string>("hora");
        var horaCommand = new Command("hora", "Converte uma hora entre fusos horários")
        {
            origemArg,
            destinoArg,
            horaArg
        };

       
        horaCommand.SetAction(parseResult =>
        {
            ConversorDeHorarioService.ConverterHora(
                parseResult.GetValue(origemArg)!,
                parseResult.GetValue(destinoArg)!,
                parseResult.GetValue(horaArg)!
            );
        });
        return horaCommand;
    }
}
