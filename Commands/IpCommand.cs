using System.CommandLine;
using Quaq.Commands.Interfaces;
using Quaq.Services.Desenvolvimento;

namespace Quaq.Commands;

public class IpCommand : IComando
{
    public Command Get()
    {
        var ipCmd = new Command("ip", "Descobre o ip");


        ipCmd.SetAction(parseResult =>
        {
            IpService.MostrarIpLocal();
        });

        return ipCmd;
    }
}
