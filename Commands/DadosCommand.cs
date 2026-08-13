using System.CommandLine;
using Quaq.Services.Diversao;
using Quaq.Interfaces;

namespace Quaq.Commands;

public class DadosCommand : IComando
{
    public Command Get()
    {

        var facesArg = new Argument<int>("faces")
        {
            Description = "Número de faces do dado"
        };
        var dadosCmd = new Command("dado", "Rolagem de dados")
        {
            facesArg
        };

        dadosCmd.SetAction(pr => DadosService.RolarDado(pr.GetValue(facesArg)));

        return dadosCmd;
    }
}
