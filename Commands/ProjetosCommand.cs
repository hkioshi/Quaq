using System.CommandLine;
using Quaq.Services.Desenvolvimento;
using Quaq.Interfaces;

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
            CriarTerminalCommand(),
            CriarRunCommand(),
            CriarCommitCommand(),
            CriarMenuCommand()

        };

        return projetosCmd;
    }


    public Command CriarMenuCommand()
    {
        var menuCmd = new Command("menu", "Menu do gerenciador de projetos");
        menuCmd.SetAction(_ => new ProjetoService().ProjMenu());
        return menuCmd;
    }

    public Command CriarRunCommand()
    {
        var argOp = new Argument<string[]>("args")
        {
            Description = "Argumentos a serem passados para o programa",
            Arity = ArgumentArity.ZeroOrMore
        };

        var nomeArg = new Argument<string>("nome")
        {
            Description = "Nome do projeto"
        };

        var runCmd = new Command("rodar", "Roda qualquer programa com arquivo de projeto")
        {
            nomeArg,
            argOp
        };

        runCmd.SetAction(act => 
        {
            var args = act.GetValue(argOp) ?? [];
            var nome = act.GetValue(nomeArg);

            new ProjetoService().Run(nome!,args);
        });
        
        return runCmd;
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

    private static Command CriarCommitCommand()
    {
        var nomeArg = new Argument<string>("nome")
        {
            Description = "Nome do projeto"
        };

        var MensagemArg = new Argument<string>("Mensagem")
        {
            Description = "Mensagem pra commit"
        };

        var cmd = new Command("commit", "Faz o commit")
        {
            nomeArg,
            MensagemArg
        };

        cmd.SetAction(pr =>
        {
            new ProjetoService().FazerCommit(pr.GetValue(nomeArg)!,pr.GetValue(MensagemArg)! );
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
