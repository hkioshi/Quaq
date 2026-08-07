using System.CommandLine;
using Quaq.Services.Internet;
using Quaq.Commands.Interfaces;

namespace Quaq.Commands;

public class EmailCommand : IComando
{
    public Command Get()
    {
        
        var emailCmd = new Command("email", "Enviador de e-mail");

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

        emailCmd.Add(contatoOp);
        emailCmd.Add(emailArg);
        emailCmd.Add(tituloArg);
        emailCmd.Add(corpoArg);

        emailCmd.SetAction(pr =>
        {
            var contato = pr.GetValue(contatoOp);
            var email = pr.GetValue(emailArg);
            var titulo = pr.GetValue(tituloArg);
            var corpo = pr.GetValue(corpoArg);

            if (contato is null && email is null)
            {
                Console.WriteLine("Destinatário não definido.");
                return;
            }

            if(titulo is null || corpo is null)
            {
                Console.WriteLine("Conteudo do email invalido");
                return;
            }

            if (contato is not null )
            {
                EmailService.EnviarEmailComContato(contato, titulo, corpo!);
                return;
            }
            
            if (email is not null)
            {
                EmailService.EnviarEmail(email!, titulo!, corpo!);
                return;
            }

        });

        return emailCmd;

    }
}
