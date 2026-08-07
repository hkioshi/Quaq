
using System.CommandLine;
using Quaq.Services.Diversao;
using Quaq.Commands.Interfaces;

namespace Quaq.Commands;

public class VelhaCommand : IComando
{
    public Command Get()
    {
        var VelhaCmd = new Command("velha", "Jogo da velha");
        VelhaCmd.SetAction(parseResult =>
        {
            JogoDaVelhaService.Start();
        });
        return VelhaCmd;
    }
}
