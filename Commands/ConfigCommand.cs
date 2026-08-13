using System.CommandLine;
using Quaq.Interfaces;
using Quaq.Services.Sistema;

namespace Quaq.Commands;

public class ConfigCommand : IComando
{
    public Command Get() =>
        new Command("config", "Configurar nome, email e senha")
        {
            CriarEmailCommand(),
            CriarDefEmailCommand(),

            CriarNomeCommand(),
            CriarDefNomeCommand(),

            CriarSenhaCommand(),
            CriarDefSenhaCommand()
        };

    private static Command CriarEmailCommand()
    {
        var cmd = new Command(
            "email",
            "Exibir o email configurado"
        );

        cmd.SetAction(_ =>
        {
            ConfigService.ExibirEmail();
        });

        return cmd;
    }

    private static Command CriarDefEmailCommand()
    {
        var arg = new Argument<string>("email")
        {
            Description = "Email que será configurado"
        };

        var cmd = new Command(
            "defemail",
            "Definir o email"
        )
        {
            arg
        };

        cmd.SetAction(parseResult =>
        {
            var email = parseResult.GetValue(arg)!;

            ConfigService.DefinirEmail(email);
        });

        return cmd;
    }

    private static Command CriarNomeCommand()
    {
        var cmd = new Command(
            "nome",
            "Exibir o nome configurado"
        );

        cmd.SetAction(_ =>
        {
            ConfigService.ExibirNome();
        });

        return cmd;
    }

    private static Command CriarDefNomeCommand()
    {
        var arg = new Argument<string>("nome")
        {
            Description = "Nome que será configurado"
        };

        var cmd = new Command(
            "defnome",
            "Definir o nome"
        )
        {
            arg
        };

        cmd.SetAction(parseResult =>
        {
            var nome = parseResult.GetValue(arg)!;

            ConfigService.DefinirNome(nome);
        });

        return cmd;
    }

    private static Command CriarSenhaCommand()
    {
        var cmd = new Command(
            "senha",
            "Exibir a senha configurada"
        );

        cmd.SetAction(_ =>
        {
            ConfigService.ExibirSenha();
        });

        return cmd;
    }

    private static Command CriarDefSenhaCommand()
    {
        var arg = new Argument<string>("senha")
        {
            Description = "Senha que será configurada"
        };

        var cmd = new Command(
            "defsenha",
            "Definir a senha"
        )
        {
            arg
        };

        cmd.SetAction(parseResult =>
        {
            var senha = parseResult.GetValue(arg)!;

            ConfigService.DefinirSenha(senha);
        });

        return cmd;
    }
}