using System.CommandLine;
using Quaq.Services.Diversao;
using Quaq.Interfaces;

namespace Quaq.Commands;

public class DadosCommand : IComando
{
    public Command CriarMenuCommand()
    {
        var dadosCmd = new Command("menu", "Rolagem de dados");
        
        dadosCmd.SetAction(pr => 
        {
            DadosService.DadoMenu();
        });

        return dadosCmd;
    }
    public Command CriarRolarCommand()
    {
        var facesArg = new Argument<int>("faces")
        {
            Description = "Número de faces do dado"
        };
        var dadosCmd = new Command("rolar", "Rolagem de dados")
        {
            facesArg
        };

        dadosCmd.SetAction(pr => DadosService.RolarDado(pr.GetValue(facesArg)));

        return dadosCmd;
    }

    public Command Get() =>
        new Command("dado", "Rolagem de dados")
        {
            CriarRolarCommand(),
            CriarMenuCommand()
        };
    
}
