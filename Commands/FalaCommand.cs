using System.CommandLine;
using Quaq.Services.Media;
using Quaq.Commands.Interfaces;

namespace Quaq.Commands;
public class FalaCommand : IComando
{
    public Command Get()
    {
        var falaCmd = new Command("fala", "Text to Speech");

        var textoArg = new Argument<string>("texto")
        {
            Description = "Texto a ser falado"
        };

        falaCmd.Add(textoArg);

        falaCmd.SetAction(pr =>
            FalaService.Falar(pr.GetValue(textoArg)!));

        return falaCmd;
    }
}
