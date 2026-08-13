using System.CommandLine;
using Quaq.Services.Internet;
using Quaq.Interfaces;
using Quaq.Services.Sistema;

namespace Quaq.Commands;

public class EmailCommand : IComando
{
    public Command Get()
    {
        

        var contatoOp = new Option<string>("-c", "--contato", "contato")
        {
            Description = "Usa um contato já registrado"
        };

        var emailArg = new Option<string>("-e", "--email" , "email")
        {
            Description = "E-mail do destinatário",
        };

        var tituloArg = new Argument<string>("titulo")
        {
            Description = "Título do e-mail"
        };

        var corpoArg = new Argument<string>("corpo")
        {
            Description = "Corpo do e-mail"
        };
        var emailCmd = new Command("email", "Enviador de e-mail")
        {
            contatoOp,
            emailArg,
            tituloArg,
            corpoArg
        };

        emailCmd.SetAction(pr =>
        {
            var contato = pr.GetValue(contatoOp);
            var email = pr.GetValue(emailArg);
            var titulo = pr.GetValue(tituloArg);
            var corpo = pr.GetValue(corpoArg);

            if (string.IsNullOrWhiteSpace(contato) &&
                string.IsNullOrWhiteSpace(email))
            {
                UiService.ErroUi("Destinatário não definido.");
                return;
            }

            if (!string.IsNullOrWhiteSpace(contato) &&
                !string.IsNullOrWhiteSpace(email))
            {
                UiService.ErroUi("Use contato ou e-mail, não os dois.");
                return;
            }

            if (string.IsNullOrWhiteSpace(titulo) ||
                string.IsNullOrWhiteSpace(corpo))
            {
                UiService.ErroUi("Conteúdo do e-mail inválido.");
                return;
            }

            if (!string.IsNullOrWhiteSpace(contato))
            {
                EmailService.EnviarEmailComContato(contato, titulo, corpo);
                return;
            }

            EmailService.EnviarEmail(email!, titulo, corpo);
        });

        return emailCmd;

    }
}
