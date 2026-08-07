using System.CommandLine;
using Quaq.Services.Diversao;
using Quaq.Commands.Interfaces;

namespace Quaq.Commands;

public class DadosCommand : IComando
{
    public Command Get()
    {
        var dadosCmd = new Command("dados", "Rolagem de dados");

        var facesArg = new Argument<int>("faces")
        {
            Description = "Número de faces do dado"
        };

        dadosCmd.Add(facesArg);

        dadosCmd.SetAction(pr => DadosService.RolarDado(pr.GetValue(facesArg)));

        return dadosCmd;
    }
}
