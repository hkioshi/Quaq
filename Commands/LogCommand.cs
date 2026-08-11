using System.CommandLine;
using Quaq.Interfaces;
using Quaq.Services.Sistema;

namespace Quaq.Commands;

public class LogCommand : IComando
{
    public Command Get()
    {
        var LogCmd = new Command("logs", "Exibe os logs ate a versao atual");

        LogCmd.SetAction(_ => LogService.Logs());

        return LogCmd;
    }
}
