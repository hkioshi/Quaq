using System.CommandLine;
using Quaq.Interfaces;
using Quaq.Services.Media;

namespace Quaq.Commands;
public class FalaCommand : IComando
{
    public Command Get()
    {

        var textoArg = new Argument<string>("texto")
        {
            Description = "Texto a ser falado"
        };
        var falaCmd = new Command("fala", "Text to Speech")
        {
            textoArg
        };

        falaCmd.SetAction(pr =>
            FalaService.Falar(pr.GetValue(textoArg)!));

        return falaCmd;
    }
}
