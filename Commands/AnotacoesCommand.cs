using System.CommandLine;
using Quaq.Interfaces;
using Quaq.Services.Produtividade;

namespace Quaq.Commands;

public class AnotacoesCommand: IComando
{
    private static Command CriarDeletarCommand()
    {
        var cmd = new Command("deletar", "Menu de Cadernos de Anotações");
        cmd.SetAction(pr =>
        {
            AnotacaoService.DeletarAnotacao();
        });

        return cmd;
    }
    private static Command CriarMenuCommand()
    {
        var cmd = new Command("menu", "Menu de Cadernos de Anotações");
        cmd.SetAction(pr =>
        {
            AnotacaoService.ListarCadernos();
        });

        return cmd;
    }

    public Command Get() =>
        new Command("anotar", "Anotações")
        {
            CriarDeletarCommand(),
            CriarMenuCommand()
        };

    
}