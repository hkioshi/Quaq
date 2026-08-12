using System.CommandLine;
using Quaq.Interfaces;
using Quaq.Services.Internet;
using Quaq.Services.Sistema;

namespace Quaq.Commands;

public class ContatoCommand : IComando
{
    public Command Get()
    {
        var ContatoCmd = new Command("contato", "Gerencia contatos");

        var nomeArg = new Argument<string?>("nome")
        {
            Description = "Nome do contato",
            DefaultValueFactory = _ => null
        };

        var emailOp = new Option<string>("--email", "-e")
        {
            Description = "Define o e-mail do contato"
        };

        var telefoneOp = new Option<string>("--telefone", "-t")
        {
            Description = "Define o telefone do contato"
        };

        var deletarOp = new Option<bool>("--deletar", "-d")
        {
            Description = "Remove um contato"
        };

        ContatoCmd.Add(nomeArg);
        ContatoCmd.Add(emailOp);
        ContatoCmd.Add(telefoneOp);
        ContatoCmd.Add(deletarOp);

        ContatoCmd.SetAction(parseResult =>
        {
            var contato = new ContatoService();

            var nome = parseResult.GetValue(nomeArg);
            var telefone = parseResult.GetValue(telefoneOp);
            var email = parseResult.GetValue(emailOp);
            var deletar = parseResult.GetValue(deletarOp);

            if (nome is null && telefone is null && email is null && !deletar)
            {
                contato.Exibir();
                return;
            }

            if (nome is null)
            {
                UiService.ErroUi("É necessário informar o nome.");
                return;
            }

            if (deletar)
            {
                contato.DeletarContato(nome);
                return;
            }

            if (telefone is not null)
            {
                contato.DefinirTelefone(nome, telefone);
                return;
            }

            if (email is not null)
            {
                contato.DefinirEmail(nome, email);
                return;
            }

            contato.Exibir(nome);
        });
        return ContatoCmd;
    }
}
