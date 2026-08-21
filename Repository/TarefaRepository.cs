using System.Text.Json;
using Quaq.Data;
using Quaq.Services.Sistema;

namespace Quaq.Repository;

public class TarefaRepository : Repositorio
{
    public TarefaRepository(string c) : base(c) {}
    public Dictionary<int,Tarefa> BuscarTodasTarefas() =>
        JsonSerializer.Deserialize<Dictionary<int,Tarefa>>(AbrirJson()) 
        ?? new Dictionary<int,Tarefa>();

    public Tarefa? BuscarTarefa(int id)
    {
        var json = JsonSerializer.Deserialize<Dictionary<int,Tarefa>>(AbrirJson()) 
            ?? new Dictionary<int,Tarefa>();
        if(!json.ContainsKey(id))
            return null;   
        return json[id];
    }

    internal void MudarStatus(int id)
    {
        var tarefas = BuscarTodasTarefas();
        string status = tarefas[id].status;

        if(status == "Incompleto") 
            tarefas[id].status = "Completo";
         if(status == "Completo") 
            tarefas[id].status = "Incompleto";
        
        UiService.OkUi($"Seu status foi mudado para {tarefas[id].status}");

        SalvarJsonTarefa(tarefas);
    }

     internal void DeletarTarefa(int id)
    {
        var tar = BuscarTodasTarefas();
            if(tar.ContainsKey(id))
            {
                UiService.OkUi("contato encontrado, quer mesmo deletar (y/n)");
                ConsoleKeyInfo tecla = Console.ReadKey();

                if (tecla.Key == ConsoleKey.Y)
                {
                    tar.Remove(id);
                    Console.WriteLine();
                    UiService.OkUi("Deletado com sucesso");
                }
                else
                    UiService.OkUi("Cancelado.");
                
            }
            string texto = JsonSerializer.Serialize(tar, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(caminho, texto);
    }

    public void SalvarJsonTarefa(Tarefa tarefa)
    {
        var json = JsonSerializer.Deserialize<Dictionary<int, Tarefa>>(AbrirJson())
            ?? new Dictionary<int, Tarefa>();

        int novoId = json.Count > 0
            ? json.Keys.Max() + 1
            : 1;

        json[novoId] = tarefa;

        string texto = JsonSerializer.Serialize(json, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(caminho, texto);
    }
    public void SalvarJsonTarefa(Dictionary<int, Tarefa> json)
    {
    
        string texto = JsonSerializer.Serialize(json, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(caminho, texto);
    }

}
