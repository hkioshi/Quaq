using System.CommandLine;
using Quaq.Interfaces;
using Quaq.Services.Desenvolvimento;

namespace Quaq.Commands;

public class IpCommand : IComando
{
    public Command Get()
    {
        var ipCmd = new Command("ip", "Descobre o ip");
        ipCmd.SetAction(_ => IpService.MostrarIpLocal());
        return ipCmd;
    }
}
