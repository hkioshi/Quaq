using System.CommandLine;
using Quaq.Interfaces;
using Quaq.Services.Diversao;
using Quaq.Services.Produtividade;

namespace Quaq.Commands;

public class ConcelhoCommand : IComando
{
    public Command Get()
    {
        var AdviceCmd = new Command("conselho", "Da um conselho");
        AdviceCmd.SetAction(async _ => await MotivacaoService.GetAdvice());
        return AdviceCmd;
    }
}
