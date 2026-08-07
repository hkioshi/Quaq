
using System.CommandLine;
using Quaq.Commands.Interfaces;
using Quaq.Services.Diversao;

namespace Quaq.Commands;

public class JogosCommand: IComando
{
    public Command Get()
    {
        var JogosCmd = new Command("jogos", "abre jogos")
        {
            CriarAzaharCommand(),
            CriarSVCommand()
        };

        return JogosCmd;
    }

      private static Command CriarAzaharCommand()
    {
        var cmd = new Command("azahar", "Abre o Azahar");

        cmd.SetAction(_ =>
        {
            JogoService.AbrirAzahar();
        });

        return cmd;
    }
    private static Command CriarSVCommand()
    {
        var cmd = new Command("sv", "Abre o Stardew Valley");

        cmd.SetAction(_ =>
        {
            JogoService.AbrirStardew();
        });

        return cmd;
    }

}