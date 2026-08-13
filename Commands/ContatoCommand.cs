using System.CommandLine;
using Quaq.Interfaces;
using Quaq.Services.Internet;
using Quaq.Services.Sistema;

namespace Quaq.Commands;

public class ContatoCommand : IComando
{
    private static Command CriarListaCommand()
    {
        var cmd = new Command("lista", "Abre o terminal de um projeto salvo");
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

    private static Command CriarDefEmailCommand()
    {
        var nomeArg = new Argument<string>("Nome")
        {
            Description = "Nome do contato."
        };
        var emailArg = new Argument<string>("Email")
        {
            Description = "Email do contato."
        };
        var cmd = new Command("email", "Define o email do contato.")
        {
            nomeArg,
            emailArg
        };
        cmd.SetAction(pr =>
        {
            var nome = pr.GetValue(nomeArg);
            var email = pr.GetValue(emailArg);

            if(nome is null)
            {
                UiService.ErroUi("Nome deve ser informado");
                return;
            }
            if(email is null)
            {
                UiService.ErroUi("Email deve ser informado");
                return;
            }
            ContatoService.DefinirEmail(nome, email);
        });
        return cmd;
    }
    private static Command CriarDefTelefoneCommand()
    {
        var nomeArg = new Argument<string>("Nome")
        {
            Description = "Nome do contato."
        };
        var telefoneArg = new Argument<string>("Telefone")
        {
            Description = "Telefone do contato."
        };
        var cmd = new Command("telefone", "Define o telefone do contato.")
        {
            nomeArg,
            telefoneArg
        };
        cmd.SetAction(pr =>
        {
            var nome = pr.GetValue(nomeArg);
            var telefone = pr.GetValue(telefoneArg);

            if(nome is null)
            {
                UiService.ErroUi("Nome deve ser informado");
                return;
            }
            if(telefone is null)
            {
                UiService.ErroUi("Telefone deve ser informado");
                return;
            }
            ContatoService.DefinirEmail(nome, telefone);
        });
        return cmd;
    }

    private static Command CriarDeletarCommand()
    {
        var nomeArg = new Argument<string>("Nome")
        {
            Description = "Nome do contato."
        };
        var cmd = new Command("deletar", "Deleta o contato do nome informado.")
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
            ContatoService.DeletarContato(nome);
        });
        return cmd;
    }

    public Command Get() =>
        new Command("contato", "Gerencia contatos")
        {
            CriarListaCommand(),
            CriarBuscaContatoCommand(),
            CriarDefEmailCommand(),
            CriarDefTelefoneCommand(),
            CriarDeletarCommand()
        };
        
      
}
