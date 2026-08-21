using System.CommandLine;
using Quaq.Interfaces;
using Quaq.Services.Desenvolvimento;

namespace Quaq.Commands;

public class RodarCommand : IComando
{
    public Command Get()
    {
        var argOp = new Argument<string[]>("args")
        {
            Description = "Argumentos a serem passados para o programa",
            Arity = ArgumentArity.ZeroOrMore
        };
        var runCmd = new Command("rodar", "Roda qualquer programa com arquivo de projeto")
        {
            argOp
        };

        runCmd.SetAction(act => 
        {
            var args = act.GetValue(argOp) ?? [];
            RunService.Run(args);
        });
        
        return runCmd;
    }
}