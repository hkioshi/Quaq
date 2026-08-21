using System.CommandLine;
using Quaq.Interfaces;
using Quaq.Services.Produtividade;

namespace Quaq.Commands;
public class FraseCommand : IComando
{
     public Command CriarConcelhoCommand()
    {
        var AdviceCmd = new Command("conselho", "Da um conselho");
        AdviceCmd.SetAction(async _ => await MotivacaoService.GetAdvice());
        return AdviceCmd;
    }
    public Command CriarMotivacaoCommand()
    {
        var AdviceCmd = new Command("motivacao", "Da uma frase motivacional");
        AdviceCmd.SetAction(_ => MotivacaoService.Motivar());
        return AdviceCmd;
    }
    public Command Get()=>
        new Command("frase", "Da uma frase.")
        {
            CriarMotivacaoCommand(),
            CriarConcelhoCommand()
        };


    
}
