using System.Text.Json;
using Quaq.Services.Sistema;
namespace Quaq.Repository;

public class ProjetosRepositorio : Repositorio
{
    public ProjetosRepositorio(string caminho): base(caminho)
    {}

    internal Dictionary<string, string> ExibirTodosProjetos() =>
        JsonSerializer.Deserialize<Dictionary<string,string>>(AbrirJson()) 
            ?? new Dictionary<string,string>();

    internal string? ExibirCaminho(string v)
    {
        var json =JsonSerializer.Deserialize<Dictionary<string,string>>(AbrirJson()) 
        ?? new Dictionary<string,string>();

        if(json.ContainsKey(v))
            return json[v];
        
        return null;
    }
    
    internal void DeletarProjeto(string v)
    {
        var projs = ExibirTodosProjetos();
            if(projs.ContainsKey(v))
            {
                UiService.OkUi("contato encontrado, quer mesmo deletar (y/n)");
                ConsoleKeyInfo tecla = Console.ReadKey();

                if (tecla.Key == ConsoleKey.Y)
                {
                    projs.Remove(v);
                    UiService.OkUi("\nDeletado com sucesso");
                }
                else
                    UiService.OkUi("\nCancelado.");
                
            }
            string texto = JsonSerializer.Serialize(projs, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(caminho, texto);
    }


    internal void SalvarProjeto(string v1, string v2)
    {
        var projetos = ExibirTodosProjetos();
        projetos[v1] = v2;
        string texto = JsonSerializer.Serialize(projetos, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(caminho, texto);
    }
}
