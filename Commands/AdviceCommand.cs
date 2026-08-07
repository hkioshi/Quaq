using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Linq;
using System.Threading.Tasks;
using Quaq.Commands.Interfaces;
using Quaq.Services.Diversao;
using Quaq.Services.Produtividade;

namespace Quaq.Commands;

public class AdviceCommand : IComando
{
    public Command Get()
    {
        var AdviceCmd = new Command("adv", "Da um conselho");
        var MotivacaoOp = new Option<bool>("-m", "--motivacao");

        AdviceCmd.Add(MotivacaoOp);
        AdviceCmd.SetAction(async parseResult =>
        {
            if(parseResult.GetValue(MotivacaoOp))
                MotivacaoService.Motivar();
            else
                await AdviceService.GetAdvice();

        });

        return AdviceCmd;
    }
}
