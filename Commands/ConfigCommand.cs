using System.CommandLine;
using System.Runtime.ConstrainedExecution;
using Quaq.Interfaces;
using Quaq.Repository;
using Quaq.Services.Sistema;

namespace Quaq.Commands;

public class ConfigCommand: IComando
{
    public Command Get()
    {
        var ConfigCmd = new Command("config", "configurar nome, email e senha")
        {
            CriarEmailCommand(),
            CriarNomeCommand(),
            CriarSenhaCommand()
        };
    
        return ConfigCmd;
    }

    private static Command CriarEmailCommand()
    {
        var op = new Option<string>("-d", "--def", "definir")
        {
            Description = "Definir uma email"
        };
        var cmd = new Command("email", "Definição ou Exibição do Email")
        {
            op
        };

        cmd.SetAction(a =>
        {  
            var email = a.GetValue(op);
            if(email is null)
                ConfigService.ExibirEmail();
            else
                ConfigService.DefinirEmail(email);
        });

        return cmd;
    }
    private static Command CriarNomeCommand()
    {
        var op = new Option<string>("-d", "--def", "definir")
        {
            Description = "Definir um nome"
        };
        var cmd = new Command("nome", "Definição ou Exibição do Nome")
        {
            op
        };

        cmd.SetAction(a =>
        {  
            var email = a.GetValue(op);
            if(email is null)
                ConfigService.ExibirNome();
            else
                ConfigService.DefinirNome(email);
        });

        return cmd;
    }
    private static Command CriarSenhaCommand()
    {
        var Defop = new Option<string>("-d", "--def", "definir")
        {
            Description = "Definir uma senha"
        };

        var Removeop = new Option<bool>("-r", "--remover", "remover")
        {
            Description = "Remove uma senha"
        };

        var cmd = new Command("senha", "Definição, Exibição, Remoção de Senha")
        {
            Defop,
            Removeop
        };

        cmd.SetAction(a =>
        {  
            
            var senha = a.GetValue(Defop);
            var Remove = a.GetValue(Removeop);

            if(Remove)
            {
                ConfigService.RemoverSenha();
            }

            if(senha is null)
                ConfigService.ExibirSenha();
            else
                ConfigService.DefinirSenha(senha);
        });

        return cmd;
    }

    
}
