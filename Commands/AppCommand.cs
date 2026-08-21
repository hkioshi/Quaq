using System.CommandLine;
using Quaq.Interfaces;
using Quaq.Services.Produtividade;
namespace Quaq.Commands;

public class AppCommand: IComando
{

    private static Command CriarAnotarCommand()
    {
        var nomeArg = new Argument<string>("Nome")
        {
            Description = "Nome do app"
        };

        var RaizArg = new Argument<string>("Raiz")
        {
            Description = "Raiz do comando, Ex: steam, quaq"
        };

        var ArgArg = new Argument<string[]>("Comando")
        {
            Description = "Agumentos para abrir o app"
        };

        var cmd = new Command("salvar", "Salva o comando para abrir um app")
        {
            nomeArg,
            RaizArg,
            ArgArg
        };

        cmd.SetAction(pr =>
        {
            var nome = pr.GetValue(nomeArg);
            var raiz = pr.GetValue(RaizArg);
            var args = pr.GetValue(ArgArg) ?? [];
            
            AppService.Salvar(nome!,raiz!,string.Join(" ", args));
        });

        return cmd;
    }
    private static Command CriarAbrirCommand()
    {
        var nomeArg = new Argument<string>("Nome")
        {
            Description = "Nome do app"
        };

        var cmd = new Command("app", "Abrir um app salvo")
        {
            nomeArg,
        };

        cmd.SetAction(pr =>
        {
            var nome = pr.GetValue(nomeArg);
            AppService.Abrir(nome!);
        });

        return cmd;
    }
    private static Command CriarDeleteCommand()
    {
        var nomeArg = new Argument<string>("Nome")
        {
            Description = "Nome do app"
        };

        var cmd = new Command("delete", "deletar um app salvo")
        {
            nomeArg,
        };

        cmd.SetAction(pr =>
        {
            var nome = pr.GetValue(nomeArg);
            AppService.Deletar(nome!);
        });

        return cmd;
    }
    private static Command CriarAbrirTodosCommand()
    {
        var cmd = new Command("todos", "Abrir um app salvo");
        cmd.SetAction(pr =>AppService.Lista());
        return cmd;
    }
    public Command Get() =>
        new Command("abrir", "Abre lista de apps salvos")
        {
            CriarDeleteCommand(),
            CriarAnotarCommand(),
            CriarAbrirCommand(),
            CriarAbrirTodosCommand()
        };

}
