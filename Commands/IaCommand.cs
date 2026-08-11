
using System.CommandLine;
using Quaq.Interfaces;
using Quaq.Services.IA;

namespace Quaq.Commands;

public class IaCommand : IComando
{
    public Command Get()
    {
        var IaCmd = new Command("ia", "Chat de ia do quaq");
        var FalarOp = new Option<bool>("-f", "--falar", "falar");
        IaCmd.Add(FalarOp);
        IaCmd.SetAction(async parseResult =>
        {
            if(parseResult.GetValue(FalarOp))    
                await IaService.FalaConectar();
            else
                await IaService.Conectar(); 


        });

        return IaCmd;
    }
}
