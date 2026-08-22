using System.CommandLine;
using Quaq.Interfaces;
using Quaq.Services.Produtividade;

namespace Quaq.Commands;

public class TarefaCommand : IComando
{

    public Command Get() =>
        new Command("tarefas", "Ferramenta gerenciadora de tarefas")
            {
                CriarNovaTarefaCommand(),
                CriarMudarStatusCommand(),
                CriarDeletarTarefaCommand(),
                CriarExibirUmaTarefaCommand(),
                CriarExibirTodasTarefasCommand(),
                CriarDeletarTodasTarefasCommand()
            };


    private Command CriarExibirTodasTarefasCommand()
    {
        var limparCmd = new Command("todas", "Exibe todas as tarefas");
        limparCmd.SetAction(_ => TarefaService.ExibirTodos());
        return limparCmd;
    }

    private Command CriarDeletarTodasTarefasCommand()
    {
        var limparCmd = new Command("limpar", "Deleta todas as tarefas");
        limparCmd.SetAction(_ => TarefaService.LimparTarefas());
        return limparCmd;
    }

    private Command CriarExibirUmaTarefaCommand()
    {
         var idArg = new Argument<int>("id")
        {
            Description = "Id da tarefa",
        };
        var exibirCmd = new Command("exibir", "Exibe uma tarefa")
        {
          idArg  
        };
        
        exibirCmd.SetAction(pr => TarefaService.ExibirTarefa(pr.GetValue(idArg)));
        return exibirCmd;
    }

    private Command CriarDeletarTarefaCommand()
    {
        var deletaCmd = new Command("deletar", "Deleta uma tarefa");
        deletaCmd.SetAction(_ => TarefaService.DeletarTarefa());
        return deletaCmd;
    }

    private Command CriarMudarStatusCommand()
    {
        var novoCmd = new Command("status", "Muda de status de Pendente pra completo ou vice-versa");
        novoCmd.SetAction(_ => TarefaService.MudarStatus());
        return novoCmd;
    }

    private Command CriarNovaTarefaCommand()
    {
        var novoCmd = new Command("nova", "Nova tarefa");
        novoCmd.SetAction(_ => TarefaService.NovaTarefa());
        return novoCmd;
    }
}
