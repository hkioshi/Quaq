using System.CommandLine;
using Quaq.Interfaces;
using Quaq.Services.Internet;
using Quaq.Services.Sistema;

namespace Quaq.Commands;

public class ContatoCommand : IComando
{
    private static Command CriarListaCommand()
    {
        var cmd = new Command("lista", "Abre uma lista dos contatos");
        cmd.SetAction(pr =>
        {
            ContatoService.ExibirTodosContatos();
        });
        return cmd;
    }

    private static Command CriarBuscaContatoCommand()
    {
        var nomeArg = new Argument<string>("Nome")
        {
            Description = "Nome do contato."
        };
        var cmd = new Command("nome", "Busca o contato do nome informado.")
        {
            nomeArg
        };
        cmd.SetAction(pr =>
        {
            var nome = pr.GetValue(nomeArg);
            if(nome is null)
            {
                UiService.ErroUi("Nome deve ser informado");
                return;
            }
            ContatoService.ExibirContato(nome);
        });
        return cmd;
    }

    private static Command CriarDefinirCommand()
    {
         var nomeArg = new Argument<string>("Nome")
        {
            Description = "Nome do contato."
        };

        var cmd = new Command("def", "Define contato.")
        {
            nomeArg
        };
        cmd.SetAction(pr => ContatoService.Definir(pr.GetValue(nomeArg)!));
        return cmd;
    }
    private static Command CriarDeletarCommand()
    {
        var cmd = new Command("deletar", "Deleta contato.");
        cmd.SetAction(pr => ContatoService.DeletarContato());
        return cmd;
    }

    public Command Get() =>
        new Command("contato", "Gerencia contatos")
        {
            CriarListaCommand(),
            CriarBuscaContatoCommand(),
            CriarDefinirCommand(),
            CriarDeletarCommand()
        };
        
      
}
