using System.CommandLine;
using Quaq.Interfaces;
using Quaq.Services.Desenvolvimento;

namespace Quaq.Commands;

public class RunCommand : IComando
{
    public Command Get()
    {
        var runCmd = new Command("run", "Roda qualquer programa com arquivo de projeto");
        runCmd.SetAction(act =>
        {
            RunService.Run();
        });
        return runCmd;
    }
}