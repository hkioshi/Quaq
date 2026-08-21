using System.CommandLine;
using Quaq.Interfaces;
using Quaq.Services.Produtividade;
using Quaq.Services.Sistema;

namespace Quaq.Commands;

public class AnotacoesCommand: IComando
{
    private static Command CriarAnotarCommand()
    {
        var nomeArg = new Argument<string>("Caderno")
        {
            Description = "Nome do Caderno"
        };

        var cmd = new Command("anotar", "Abre o terminal de um projeto salvo")
        {
            nomeArg
        };

        cmd.SetAction(pr =>
        {
            var nome = pr.GetValue(nomeArg);
            if(nome is null)
            {
                UiService.ErroUi("Deve ter nome do caderno.");
                return;
            }
            AnotacaoService.IniciarAnotacao(nome);
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
        new Command("anotacao", "Anotações")
        {
            CriarAnotarCommand(),
            CriarMenuCommand()
        };

    
}