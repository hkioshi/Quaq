using System.CommandLine;
using Quaq.Interfaces;
using Quaq.Services.Produtividade;

namespace Quaq.Commands;
public class MotivacaoCommand : IComando
{
    public Command Get()
    {
        var AdviceCmd = new Command("motivacao", "Da uma frase motivacional");
        AdviceCmd.SetAction(_ => MotivacaoService.Motivar());
        return AdviceCmd;
    }
}
