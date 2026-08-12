using System.CommandLine;
using Quaq.Interfaces;
using Quaq.Services.Diversao;
using Quaq.Services.Produtividade;

namespace Quaq.Commands;

public class AdviceCommand : IComando
{
    public Command Get()
    {
        var AdviceCmd = new Command("conselho", "Da um conselho");
        var MotivacaoOp = new Option<bool>("-m", "--motivacao");

        AdviceCmd.Add(MotivacaoOp);
        AdviceCmd.SetAction(async parseResult =>
        {
            if(parseResult.GetValue(MotivacaoOp))
                MotivacaoService.Motivar();
            else
                await MotivacaoService.GetAdvice();

        });

        return AdviceCmd;
    }
}
