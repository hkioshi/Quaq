using Quaq.Data;
using Quaq.Repository;
using Quaq.Services.Sistema;
using Spectre.Console;

namespace Quaq.Services.Produtividade;
public class TarefaService
{
    private static TarefaRepository repos = new("tarefas.json");
    private static int BuscarId()
    {
        var dict = repos.BuscarTodasTarefas();

        if (dict.Count == 0)
        {
            UiService.ErroUi("Sem Tarefas salvas.");
            return -1;
        }

        List<string> listaDeTarefas = [];

        foreach (var tarefa in dict)
        {
            string cor = tarefa.Value.status.Equals("Completo")
                ? "green"
                : "red";

            string data = tarefa.Value.data?.ToString("dd/MM/yyyy") ?? "sem data";

            listaDeTarefas.Add(
                $"{tarefa.Key}: [{cor}]{tarefa.Value.Nome}[/] " +
                $"[grey]({data})[/]"
            );
        }

        var opcao = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[bold]Selecione uma tarefa:[/]")
                .AddChoices(listaDeTarefas)
        );

        return int.Parse(opcao.Split(':')[0]);
    }

    public static void ExibirTodos()
    {
        int id = BuscarId();
        if(id != -1)
            ExibirTarefa(id);
    }

    public static void ExibirTarefa(int id)
    {
        var tarefa = repos.BuscarTarefa(id);

        if (tarefa is null)
        {
            UiService.ErroUi("Id nao encontrado");
            return;
        }

        string tarefaData = tarefa.data?.ToString("dd/MM/yyyy") ?? "null";

        UiService.ListaUi(
            tarefa.Nome,
            [
                $"Data - {tarefaData}",
                $"Descrição - {tarefa.descricao ?? ""}",
                $"Status - {tarefa.status}"
            ]);
    }

    public static void NovaTarefa()
    {
        Tarefa tarefa = new();
        DateTime data;
        
        while(true)
        {
            string escolha = "";

            UiService.LinhaUi("Escreva nome da tarefa");
            Console.Write("> ");
            
            escolha = Console.ReadLine() ?? "";
            if(escolha == "")
            {
                UiService.ErroUi("Nome invalido, tente novamente");
            }
            tarefa.Nome = escolha;
            break;
        }
        while (true)
        {
            UiService.LinhaUi("Escreva uma data limite\nformato dia/mes/ano\nenter para pular");
            Console.Write("> ");

            string escolha = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(escolha))
            {
                tarefa.data = null;
                break;
            }

            if (!DateTime.TryParse(escolha, out data))
            {
                UiService.ErroUi("Formato de data invalido");
                continue;
            }

            tarefa.data = data;
            break;
        }
        while(true)
        {
            string? escolha = "";

            UiService.LinhaUi("Escreva uma descricao");
            Console.Write("> ");
            
            escolha = Console.ReadLine();
            if(escolha is null)
            {
                tarefa.descricao = "";
                break;
            }
            else
            {
                tarefa.descricao = escolha;
                break;
            }
            
            
        }
        repos.SalvarJsonTarefa(tarefa);
    }

    internal static void DeletarTarefa()
    {
        int id = BuscarId();
        if(id != -1)
            repos.DeletarTarefa(id);
    }

    internal static void MudarStatus()
    {
        int id = BuscarId();
        if(id != -1)
        {
            repos.MudarStatus(id);
        }

    }

    internal static void LimparTarefas()
    {
        UiService.OkUi("contato encontrado, quer mesmo deletar (y/n)");
        ConsoleKeyInfo tecla = Console.ReadKey();

        if (tecla.Key == ConsoleKey.Y)
        {
            repos.SalvarJsonTarefa(new Dictionary<int,Tarefa>());
            Console.WriteLine();
            UiService.OkUi("Deletado com sucesso");
        }
        else
        {
            Console.WriteLine();
            UiService.OkUi("Cancelado.");
        }                
    }
}
