using System.CommandLine;
using Quaq.Services.Desenvolvimento;
using Quaq.Commands.Interfaces;

namespace Quaq.Commands;

public class ProjetosCommand : IComando
{
    public Command Get()
    {
        var projetosCmd = new Command("proj", "Gerenciador de projetos")
        {
            CriarListCommand(),
            CriarOpenCommand(),
            CriarCodeCommand(),
            CriarSaveCommand(),
            CriarDeleteCommand(),
            CriarTerminalCommand()
        };

        return projetosCmd;
    }

    private static Command CriarListCommand()
    {
        var cmd = new Command("ls", "Lista todos os projetos");

        cmd.SetAction(_ =>
        {
            new ProjetoService().Exibir();
        });

        return cmd;
    }

    private static Command CriarOpenCommand()
    {
        var nomeArg = new Argument<string>("nome")
        {
            Description = "Nome do projeto"
        };

        var cmd = new Command("abrir", "Abre a pasta do projeto")
        {
            nomeArg
        };

        cmd.SetAction(pr =>
        {
            new ProjetoService().AbrirProjeto(pr.GetValue(nomeArg)!);
        });

        return cmd;
    }

    private static Command CriarCodeCommand()
    {
        var nomeArg = new Argument<string>("nome")
        {
            Description = "Nome do projeto"
        };

        var cmd = new Command("code", "Abre o projeto no VS Code")
        {
            nomeArg
        };

        cmd.SetAction(pr =>
        {
            new ProjetoService().CodarProjeto(pr.GetValue(nomeArg)!);
        });

        return cmd;
    }

    private static Command CriarSaveCommand()
    {
        var nomeArg = new Argument<string>("nome")
        {
            Description = "Nome do projeto"
        };

        var cmd = new Command("add", "Salva o diretório atual como projeto")
        {
            nomeArg
        };

        cmd.SetAction(pr =>
        {
            new ProjetoService().SalvarProjeto(pr.GetValue(nomeArg)!);
        });

        return cmd;
    }

    private static Command CriarDeleteCommand()
    {
        var nomeArg = new Argument<string>("nome")
        {
            Description = "Nome do projeto"
        };

        var cmd = new Command("rm", "Remove um projeto salvo")
        {
            nomeArg
        };

        cmd.SetAction(pr =>
        {
            new ProjetoService().DeletarProjeto(pr.GetValue(nomeArg)!);
        });

        return cmd;
    }

    private static Command CriarTerminalCommand()
    {
        var nomeArg = new Argument<string>("nome")
        {
            Description = "Nome do projeto"
        };

        var cmd = new Command("term", "Abre o terminal de um projeto salvo")
        {
            nomeArg
        };

        cmd.SetAction(pr =>
        {
            new ProjetoService().AbrirTerminal
            (pr.GetValue(nomeArg)!);
        });

        return cmd;
    }

    
}
